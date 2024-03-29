/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Text.RegularExpressions;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.ConfigurationService {

    public sealed class RuntimeDatabaseConfiguration : IRuntimeDatabaseConfiguration {
        private static readonly Regex CATALOG_REGEX = new Regex(@"initial catalog=\s*([^;]+?)\s*;", 
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        private static readonly Regex CATALOG_REPLACE_REGEX = new Regex(@"(initial catalog=\s*)([^;]+?)(\s*;)", 
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
		
        private readonly IDatabaseProvider databaseProvider;

        public IDatabaseProvider DatabaseProvider {
            get { return databaseProvider; }
        }

        [ConfigurationParameter(Persist=false)]
        public string Username {
            get {
                return ConnectionStringsHelper.ExtractUsername(ConnectionString);
            }
            set {
                ConnectionString = ConnectionStringsHelper.ReplaceUsername(ConnectionString, value);
            }
        }

        [ConfigurationParameter(Persist=false)]
        public string Password {
            get {
                return ConnectionStringsHelper.ExtractPassword(ConnectionString);
            }
            set {
                ConnectionString = ConnectionStringsHelper.ReplacePassword(ConnectionString, value);
            }
        }

        [ConfigurationParameter(Encrypt=true)]
        public string ConnectionString {
            get;
            set;
        }

        public string DatabaseIdentifier {
            get {
                return Catalog;
            }
        }

        [ConfigurationParameter]
        public bool DatabaseUnicodeSupport {
            get;
            set;
        }

        [ConfigurationParameter(Persist=false)]
        public string Catalog {
            get {
                string dbCatalog = "";

			    if (ConnectionString != null) {
			        Match m = CATALOG_REGEX.Match(ConnectionString);

			        if (m.Success && m.Groups[1].Success) {
			            dbCatalog = m.Groups[1].Value;
			        }
			    }

                return dbCatalog;
            }
            set {
                if (value.IsNullOrEmpty()) {
                    return;
                }

                if (ConnectionString == null) {
                    ConnectionString = "";
                    return;
                }

                ConnectionString = CATALOG_REPLACE_REGEX.Replace(ConnectionString, m => m.Groups[1].Value + value + m.Groups[3].Value);
            }
        }

        public RuntimeDatabaseConfiguration(IDatabaseProvider databaseProvider) {
            this.databaseProvider = databaseProvider;
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            var other = (RuntimeDatabaseConfiguration) obj;

            return
                DatabaseProvider == other.DatabaseProvider
                && ConnectionString == other.ConnectionString
                && DatabaseUnicodeSupport == other.DatabaseUnicodeSupport;
        }

        public override int GetHashCode() {
            int hash = 17;
            if (ConnectionString != null) {
                hash = hash * 31 + ConnectionString.GetHashCode();
            }
            if (Catalog != null) {
                hash = hash * 31 + Catalog.GetHashCode();
            }
            hash = hash * 31 + DatabaseUnicodeSupport.GetHashCode();
            return hash;
        }

        public override string ToString() {
            return ConnectionStringsHelper.ReplacePassword(ConnectionString, "********");
        }
    }
}
