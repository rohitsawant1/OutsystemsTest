/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.Platform.Configuration;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.Configuration {

    public class SessionConfigurationManager : BaseSessionConfigurationManager {

        public SessionConfigurationManager(ISessionDatabaseConfiguration sessionConfiguration)
            : base(sessionConfiguration) {
            PreProcessedStatements = new ArrayList();

            var config = (SessionDatabaseConfiguration)sessionConfiguration;
            
            config.SqlEngineEdition = ConfigurationManagerUtils.GetSqlEngineEdition(sessionConfiguration);
        }

        private IPlatformDatabaseConfiguration platformConfiguration;

        public SessionConfigurationManager(ISessionDatabaseConfiguration sessionConfiguration, IPlatformDatabaseConfiguration platformConfiguration)
            : base(sessionConfiguration) {
            PreProcessedStatements = new ArrayList();
            this.platformConfiguration = platformConfiguration;

            var config = (SessionDatabaseConfiguration)sessionConfiguration;

            config.SqlEngineEdition = ConfigurationManagerUtils.GetSqlEngineEdition(sessionConfiguration);
        }

        public override FileStream StreamForScriptFile {
            get {
                string path = Path.Combine(Script_Path, "session_model_sqlserver.sql");
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
        }

        private FileStream StreamForSetupScriptFile {
            get {
                string path = Path.Combine(Script_Path, "session_creation_sqlserver.sql");
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
        }

        public override string StatementSeparator {
            get {
                return "GO";
            }
        }

        private ArrayList PreProcessedStatements;

        private void NormalizeWindowsUser() {
            var sessionConf = (SessionDatabaseConfiguration)sessionConfiguration;

            if (sessionConf.AuthenticationMode != AuthenticationType.Windows_Authentication) {
                return;
            }

            sessionConf.SessionUser = WindowsUser.Normalize(sessionConf.SessionUser);
        }

        private void NormalizeAdminWindowsUser() {
            var platformConf = (PlatformDatabaseConfiguration)platformConfiguration;

            if (platformConf.AuthenticationMode != AuthenticationType.Windows_Authentication) {
                return;
            }

            platformConf.AdminUser = WindowsUser.Normalize(platformConf.AdminUser);
        }


        public override bool RequiresElevatedPrivileges() {
            return true;
        }

        public override string GenerateSetupScript() {
            NormalizeWindowsUser();
            NormalizeAdminWindowsUser();
            string catalog = ((SessionDatabaseConfiguration) sessionConfiguration).Catalog;
            string sessionUser = ((SessionDatabaseConfiguration) sessionConfiguration).SessionUser;
            string sessionPassword = ((SessionDatabaseConfiguration) sessionConfiguration).SessionPassword;
            int deleteRowCount = ((SessionDatabaseConfiguration)sessionConfiguration).DeleteExpiredSessionsAvoidLockRowCount;
            int deleteVarsRowCount = ((SessionDatabaseConfiguration)sessionConfiguration).DeleteExpiredSessionVarsAvoidLockRowCount;
            string adminUsername = ((PlatformDatabaseConfiguration) platformConfiguration).AdminUser;
            bool windowsAuth = ((SessionDatabaseConfiguration) sessionConfiguration).AuthenticationMode == AuthenticationType.Windows_Authentication;


            //for P10 the setup script is going to be generated by the conf tool to avoid duplication
            StringBuilder sb = new StringBuilder(ReadScriptFile(StreamForSetupScriptFile));
            sb.Replace(TAG_CATALOG, catalog);
            sb.Replace(TAG_USERNAME, sessionUser);
            sb.Replace(TAG_PASSWORD, sessionPassword);
            sb.Replace(TAG_ROWCOUNT, Convert.ToString(deleteRowCount));
            sb.Replace(TAG_VARSROWCOUNT, Convert.ToString(deleteVarsRowCount));
            sb.Replace(TAG_AUTH, windowsAuth ? "windows" : "sql");
            sb.Replace(TAG_OSADMINUSERNAME, adminUsername);

            return sb.ToString();
        }

        public override void Pre_CreateOrUpgradeSession() {

            NormalizeWindowsUser();

            var elevated = (IElevatedUserConfiguration)sessionConfiguration;

            var masterElevated = ConfigurationManagerUtils.ConfigurationToMaster(elevated);

            var runtimeElevated = (RuntimeDatabaseConfiguration)elevated.ElevatedRuntimeDatabaseConfiguration();

            bool isAzureDB = ConfigurationManagerUtils.IsDatabaseAzure(masterElevated);

            ConfigurationManagerUtils.CheckIfUserHasNecessaryElevatedPermissions(masterElevated, runtimeElevated);

            if (!isAzureDB) {
                ConfigurationManagerUtils.CreateSqlServerCatalogIfDoesntExist(masterElevated, runtimeElevated.Catalog);
            } else {
                // We will not support automatically creating Azure databases.
                // An appropriate message is displayed.
                ConfigurationManagerUtils.CheckIfAzureDatabaseExists(masterElevated, runtimeElevated.Catalog);
            }

            // Prepare statements
            PreProcessedStatements.Add(ConfigurationManagerUtils.GrantSessionUserPermissions(
                (SessionDatabaseConfiguration)sessionConfiguration,
                (PlatformDatabaseConfiguration)platformConfiguration));

            // Azure does not support changing the recovery model
            if (!isAzureDB) {
                try {
                    // Set database recovery model to Simple
                    ConfigurationManagerUtils.SetRecoveryModel(masterElevated, runtimeElevated.Catalog, "Simple");
                } catch (Exception exception) {
                    throw new ConfigurationOperationException("After the Configuration Tool closes, you must set the '" + runtimeElevated.Catalog + "' database recovery model to simple.", exception);
                }
            }
        }

        protected const string TAG_CATALOG = "[CATALOG]";
        protected const string TAG_USERNAME = "[USERNAME]";
        protected const string TAG_PASSWORD = "[PASSWORD]";
        protected const string TAG_AUTH = "[AUTH]";
        protected const string TAG_OSADMINUSERNAME = "[OSADMIN_USERNAME]";

        public override IEnumerable<string> SessionStatements {
            get {
                NormalizeWindowsUser();
                string catalog = ((SessionDatabaseConfiguration)sessionConfiguration).Catalog;
                string sessionUser = ((SessionDatabaseConfiguration)sessionConfiguration).SessionUser;
                int deleteRowCount = ((SessionDatabaseConfiguration)sessionConfiguration).DeleteExpiredSessionsAvoidLockRowCount;
                int deleteVarsRowCount = ((SessionDatabaseConfiguration)sessionConfiguration).DeleteExpiredSessionVarsAvoidLockRowCount;

                string script;
                using (var stream = StreamForScriptFile) {
                    script = ReadScriptFile(stream);
                }

                StringBuilder str = new StringBuilder();

                // read the entire script
                var reader = new StringReader(script);
                string line = reader.ReadLine();
                while (line != null) {
                    if (line.Trim() == StatementSeparator) {
                        //Add to the list of commands
                        string command = str.ToString();
                        command = command.Replace(TAG_CATALOG, catalog);
                        command = command.Replace(TAG_USERNAME, sessionUser);
                        command = command.Replace(TAG_ROWCOUNT, Convert.ToString(deleteRowCount));
                        command = command.Replace(TAG_VARSROWCOUNT, Convert.ToString(deleteVarsRowCount));
                        yield return command;

                        str = new StringBuilder();
                    } else if (line != "") {
                        str.AppendLine(line);
                    }
                    line = reader.ReadLine();
                }

                // Add pre processed statements
                foreach (string preProcessedStatement in PreProcessedStatements) {
                    yield return preProcessedStatement;
                }
            }
        }

        public override bool TestSessionConnection(out string friendlyMessage) {
            NormalizeWindowsUser();
            bool result = base.TestSessionConnection(out friendlyMessage);
            ConfigurationManagerUtils.CheckSessionRoles(sessionConfiguration, out friendlyMessage);
            return result;
        }

        public override int QueryTimeout {
            set {
                ConfigurationManagerUtils.QueryTimeout = value;
            }
        }
    }
}