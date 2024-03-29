/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Net;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.Platform.Configuration;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.Configuration {

    internal class ConnectionStringUtils {

        private const string _usernamePart = "user id={0};";
        private const string _passwordPart = "password={0};";
        private const string _datasourcePart = "data source={0};";
        private const string _catalogPart = "initial catalog={0};";
        private const string IntegratedAuthPart = "Integrated Security=SSPI; ";

        private static string Credentials(NetworkCredential cred, AuthenticationType at) {
            if (at == AuthenticationType.Windows_Authentication) {
                string username = cred.UserName.ToLowerInvariant();

                if (!string.IsNullOrEmpty(cred.Domain)) {
                    username = cred.Domain + "\\" + username;
                }

                return string.Format(_usernamePart, username) +
                       IntegratedAuthPart;
            } else {
                return string.Format(_usernamePart, cred.UserName) +
                       string.Format(_passwordPart, cred.Password);
            }
        }

        private static string DataSource(string server, string catalog) {
            return string.Format(_datasourcePart, server) +
                   string.Format(_catalogPart, catalog);
        }

        private static string Advanced(string advanced) {
            return advanced;
        }

        internal static string Make(NetworkCredential cred, AuthenticationType at, string server, string catalog, string adv) {
            return Credentials(cred, at) + DataSource(server, catalog) + Advanced(adv);
        }

        internal static string Make(NetworkCredential cred, AuthenticationType at, string server, string catalog) {
            return Credentials(cred, at) + DataSource(server, catalog);
        }
    }
}