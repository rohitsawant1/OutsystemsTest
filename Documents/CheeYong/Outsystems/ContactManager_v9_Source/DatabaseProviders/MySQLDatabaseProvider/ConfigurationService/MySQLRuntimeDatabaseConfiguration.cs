/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Text.RegularExpressions;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.ConfigurationService {

    public class MySQLRuntimeDatabaseConfiguration : IRuntimeDatabaseConfiguration {

        private static readonly Regex _passwordRegex = new Regex(@"(Pwd=\s*)([^ ;]+)(\s*;)", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        public IDatabaseProvider DatabaseProvider {
            get { return MySQLDatabaseProvider.Instance; }
        }

        [ConfigurationParameter]
        public string Username {
            get;
            set;
        }

        [ConfigurationParameter(Encrypt = true)]
        public string ConnectionString {
            get;
            set;
        }

        [ConfigurationParameter]
        public string Schema {
            get;
            set;
        }

        public string DatabaseIdentifier {
            get {
                return Schema;
            }
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            var other = (MySQLRuntimeDatabaseConfiguration) obj;

            return
                DatabaseProvider == other.DatabaseProvider
                && Username == other.Username
                && ConnectionString == other.ConnectionString
                && Schema == other.Schema;
        }

        public override int GetHashCode() {
            int hash = 17;
            if (Username != null) {
                hash = hash * 31 + Username.GetHashCode();
            }
            if (ConnectionString != null) {
                hash = hash * 31 + ConnectionString.GetHashCode();
            }
            if (Schema != null) {
                hash = hash * 31 + Schema.GetHashCode();
            }
            return hash;
        }

        public override string ToString() {
            return _passwordRegex.Replace(ConnectionString, m => m.Groups[1].Value + "********" + m.Groups[3].Value);
        }
    }
}
