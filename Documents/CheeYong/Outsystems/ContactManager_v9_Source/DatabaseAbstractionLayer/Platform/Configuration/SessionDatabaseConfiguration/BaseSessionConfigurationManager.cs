/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.IO;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {

    public abstract class BaseSessionConfigurationManager : BaseConfigurationManager, ISessionConfigurationManager {

        protected ISessionDatabaseConfiguration sessionConfiguration;

        protected const string TAG_ROWCOUNT = "[ROWCOUNT]";
        protected const string TAG_VARSROWCOUNT = "[VARSROWCOUNT]";

        public BaseSessionConfigurationManager(ISessionDatabaseConfiguration sessionConfiguration) {
            this.sessionConfiguration = sessionConfiguration;
        }

        public abstract IEnumerable<string> SessionStatements {
            get;
        }

        public abstract FileStream StreamForScriptFile {
            get;
        }

        public virtual bool RequiresElevatedPrivileges() {
            return sessionConfiguration.ImplementsElevatedPrivilegesOperations;
        }

        public virtual string GenerateSetupScript() {
            throw new NotImplementedException("Setup script generation not implemented for this database provider");
        }

        public abstract void Pre_CreateOrUpgradeSession();

        public virtual bool TestSessionConnection(out string friendlyMessage) {
            bool sucess = TestConnection(sessionConfiguration.RuntimeDatabaseConfiguration(), out friendlyMessage);
            if (!sucess) {
                string newFriendlyMessage;
                string upperCaseUser = ((BaseSessionDatabaseConfiguration)sessionConfiguration).SessionUser;
                ((BaseSessionDatabaseConfiguration)sessionConfiguration).SessionUser = upperCaseUser.ToUpperInvariant();
                sucess = TestConnection(sessionConfiguration.RuntimeDatabaseConfiguration(), out newFriendlyMessage);
                if (!sucess) {
                    ((BaseSessionDatabaseConfiguration)sessionConfiguration).SessionUser = upperCaseUser;
                } else {
                    friendlyMessage = newFriendlyMessage;
                }
            }
            return sucess;
        }

        public virtual int QueryTimeout { get; set; }
    }
}