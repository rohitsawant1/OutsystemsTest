/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.RuntimeCommon {
    [Obsolete("No longer used by new APIs. Use OutSystems.RuntimePublic.Db.DatabaseAccess class to access a database and its services")]
    public sealed class ConnectionString {
        private readonly string connectionString;
        private readonly string onsConfig;

        public ConnectionString(string connectionString) {
            this.connectionString = connectionString;
            this.onsConfig = "";
        }

        public ConnectionString(string connectionString, string onsClusterConfig) {
            this.connectionString = connectionString;
            this.onsConfig = onsClusterConfig;
        }

        public string GetConnectionString() {
            return connectionString;
        }

        public string GetOnsConfig() {
            return onsConfig;
        }

        public ConnectionString Join(string connectionStringExtras) {
            return new ConnectionString(
                Join(connectionString, connectionStringExtras),
                onsConfig
            );
        }

        private static string Join(string connectionString, string parameters) {
            if (!connectionString.TrimEnd().EndsWith(";")) {
                connectionString += ";";
            }

            return connectionString + (parameters ?? string.Empty);
        }

        public override bool Equals(object obj) {
            var other = obj as ConnectionString;
            return ((other != null) && connectionString.Equals(other.connectionString) && onsConfig.Equals(other.onsConfig));
        }

        public override int GetHashCode() {
            return connectionString.GetHashCode() ^ onsConfig.GetHashCode();
        }
    }
}
