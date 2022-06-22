/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.Platform.Configuration;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.Configuration {

    public class BusinessDatabaseConfiguration : TwoUserDatabaseConfiguration {

        public override string CatalogDefaultName { get { return "outsystems"; } }

        public override void Set(IPlatformDatabaseConfiguration conf) {
            if (conf != null) {
                var other = (PlatformDatabaseConfiguration)conf;

                Server = other.Server;
                Catalog = other.Catalog;
                Unicode = other.Unicode;
                AuthenticationMode = other.AuthenticationMode;
                RuntimeUser = other.RuntimeUser;
                RuntimePassword = other.RuntimePassword;
                AdminUser = other.AdminUser;
                AdminPassword = other.AdminPassword;
                RuntimeAdvancedSettings = other.RuntimeAdvancedSettings;
                ElevatedAuthenticationCredential = other.ElevatedAuthenticationCredential;
                SqlEngineEdition = other.SqlEngineEdition;
                UsedAuthenticationMode = other.UsedAuthenticationMode;
                ElevatedUserAuthenticationMode = other.ElevatedUserAuthenticationMode;
            }
        }
    }
}