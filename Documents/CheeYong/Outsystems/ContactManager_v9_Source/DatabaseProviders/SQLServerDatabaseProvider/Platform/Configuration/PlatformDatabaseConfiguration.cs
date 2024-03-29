/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Net;
using System.Text;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.ConfigurationService;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.Platform;
using OutSystems.HubEdition.Extensibility.Data.Platform.Configuration;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.Configuration {

    public class PlatformDatabaseConfiguration : BasePlatformDatabaseConfiguration, IDatabaseConfiguration, IElevatedUserConfiguration {

        public override IPlatformDatabaseProvider DatabaseProvider {
            get { return Platform.PlatformDatabaseProvider.Instance; }
        }

        public override AuthenticationType AuthenticationMode {
            get { return UsedAuthenticationMode; }
            set { }
        }
        
        public override IRuntimeDatabaseConfiguration RuntimeDatabaseConfiguration(Source source, UserType userType) {

            NetworkCredential userCredentials;

            switch (userType) {
                case UserType.Admin:
                    userCredentials = AdminAuthenticationCredential;
                    break;
                case UserType.Runtime:
                    userCredentials = RuntimeAuthenticationCredential;
                    break;
                default:
                    throw new NotSupportedException(@"Unexpected user type " + userType);
            }

            string adv = "";
            switch (source) {
                case Source.Application:
                    adv = RuntimeAdvancedSettings;
                    break;
                case Source.Services:
                    adv = ServicesAdvancedSettings;
                    break;
            }

            return new RuntimeDatabaseConfiguration(DatabaseProvider) {
                ConnectionString = ConnectionStringUtils.Make(userCredentials, AuthenticationMode, Server, Catalog, adv),
                DatabaseUnicodeSupport = Unicode
            };
        }

        #region SQLServer Advanced Settings

        private bool unicode = true;
        [ConfigurationParameter]
        public bool Unicode {
            get {return unicode; }
            set {unicode = value; }
        }

        #endregion

        #region DatabaseLocation

        [UserDefinedConfigurationParameter(Label = "Authentication", IsMandatory = true, Order = 3, Region = ParameterRegion.DatabaseLocation)]
        [HelpLinkForEnumConfigurationParameter(EnumValue = "Windows_Authentication", Text = "How-to", Url = @"http://www.outsystems.com/goto/howto-change-database-auth")]
        public AuthenticationType UsedAuthenticationMode { get; set; }

        [ConfigurationParameter(Persist=false)]
        public AuthenticationType ElevatedUserAuthenticationMode { get; set; }

        private SqlEngineEdition sqlEngineEdition = SqlEngineEdition.Unknown;
        [ConfigurationParameter]
        public SqlEngineEdition SqlEngineEdition {
            get { return sqlEngineEdition; }
            set { sqlEngineEdition = value; }
        }

        private string server;
        [UserDefinedConfigurationParameter(Label = "Server", IsMandatory = true, Order = 1, Region = ParameterRegion.DatabaseLocation)]
        public string Server { 
            get { return server ?? "localhost"; }
            set { server = value; }
        }

        private string catalog;
        [UserDefinedConfigurationParameter(Label = "Database", IsMandatory = true, Order = 2, Region = ParameterRegion.DatabaseLocation)]
        public string Catalog {
            get { return catalog ?? "outsystems"; }
            set { catalog = value; }
        }
        #endregion

        #region IElevatedUserConfiguration Members

        public NetworkCredential ElevatedAuthenticationCredential { get; set; }

        public IRuntimeDatabaseConfiguration ElevatedRuntimeDatabaseConfiguration() {
            return new RuntimeDatabaseConfiguration(DatabaseProvider) {
                ConnectionString = ConnectionStringUtils.Make(ElevatedAuthenticationCredential, ElevatedUserAuthenticationMode, Server, Catalog, ServicesAdvancedSettings),
                DatabaseUnicodeSupport = Unicode,
            };
        }

        #endregion
        public override bool Equals(ITwoUserDatabaseConfiguration obj) {
            
            if ((object)this == (object)obj) {
                return true;
            }

            if (obj == null) {
                return false;
            }

            if (GetType() != obj.GetType()) {
                return false;
            }

            var other = (PlatformDatabaseConfiguration)obj;

            return Server == other.Server
                && Catalog == other.Catalog
                && Unicode == other.Unicode
                && ImplementsElevatedPrivilegesOperations == other.ImplementsElevatedPrivilegesOperations
                && AuthenticationMode == other.AuthenticationMode
                && RuntimeUser == other.RuntimeUser
                && RuntimePassword == other.RuntimePassword
                && AdminUser == other.AdminUser
                && AdminPassword == other.AdminPassword
                && LogUser == other.LogUser
                && LogPassword == other.LogPassword
                && RuntimeAdvancedSettings == other.RuntimeAdvancedSettings
                && ServicesAdvancedSettings == other.ServicesAdvancedSettings;
        }
    }
}