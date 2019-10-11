/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Net;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.Configuration {
    public abstract class AbstractTwoUserDatabaseConfiguration : ITwoUserDatabaseConfiguration {

        /// <summary>
        /// Gets the database provider. It provides information about the database,
        /// and access to its services.
        /// </summary>
        public abstract IPlatformDatabaseProvider DatabaseProvider { get; }

        public bool ImplementsElevatedPrivilegesOperations {
            get { return this is IElevatedUserConfiguration; }
        }

        public virtual bool RequiresElevatedPrivileges {
            get { return this is IElevatedUserConfiguration; }
        }

        public abstract AuthenticationType AuthenticationMode { get; set; }

        public abstract bool Equals(ITwoUserDatabaseConfiguration other);

        protected string adminUser = null;
        protected string runtimeUser = null;

        #region Admin

        [UserDefinedConfigurationParameter(Label = "User", IsMandatory = true, Order = 1, Region = ParameterRegion.UserAdminSpecific, Prompt = "Admin username")]
        public virtual string AdminUser {
            get {
                return adminUser ?? "OSADMIN";
            }
            set {
                adminUser = value;
            }
        }

        [UserDefinedConfigurationParameter(Label = "Password", IsPassword = true, IsMandatory = true, Order = 2, Region = ParameterRegion.UserAdminSpecific, Prompt = "Admin password", Encrypt=true)]
        public virtual string AdminPassword { get; set; }

        public NetworkCredential AdminAuthenticationCredential {
            get {
                return new NetworkCredential(AdminUser, AdminPassword);
            }
            set {
                AdminUser = value.UserName;
                AdminPassword = value.Password;
            }
        }

        #endregion

        #region Runtime

        [UserDefinedConfigurationParameter(Label = "User", IsMandatory = true, Order = 1, Region = ParameterRegion.UserRuntimeSpecific, Prompt = "Runtime username")]
        public virtual string RuntimeUser {
            get {
                return runtimeUser ?? "OSRUNTIME";
            }
            set {
                runtimeUser = value;
            }
        }

        [UserDefinedConfigurationParameter(Label = "Password", IsPassword = true, IsMandatory = true, Order = 2, Region = ParameterRegion.UserRuntimeSpecific, Prompt = "Runtime password", Encrypt=true)]
        public virtual string RuntimePassword { get; set; }

        public virtual NetworkCredential RuntimeAuthenticationCredential {
            get {
                return new NetworkCredential(RuntimeUser, RuntimePassword);
            }
            set {
                RuntimeUser = value.UserName;
                RuntimePassword = value.Password;
            }
        }

        #endregion

        #region Database Advanced Settings

        [UserDefinedConfigurationParameter(Label = "Runtime Applications", Order = 1, Region = ParameterRegion.Advanced, Example = "e.g.: Max Pool Size = 100; Connection Timeout = 15;", Prompt = "Runtime TNS name")]
        public virtual string RuntimeAdvancedSettings { get; set; }

        #endregion

        public bool AdvancedConfigurationMode {
            get;
            set;
        }

        public virtual string ContextualHelpForAdvancedMode {
            get {
                return "";
            }
        }

        public virtual string ContextualHelpForBasicMode {
            get {
                return "";
            }
        }
    }
}
