/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.DatabaseObjects {
    public class MySQLTableSourceInfo : BaseTableSourceInfo {

        public MySQLTableSourceInfo(IDatabaseServices databaseServices, MySQLDatabaseInfo database, string name, string qualifiedName)
            : base(databaseServices, database, name, qualifiedName) { }

        public new MySQLDatabaseInfo Database {
            get { return (MySQLDatabaseInfo)base.Database; }
        }

        public override bool Equals(ITableSourceInfo other) {
            return ReferenceEquals(this, other) || QualifiedName.EqualsIgnoreCase(other.QualifiedName);
        }

        public override int GetHashCode() {
            return QualifiedName.ToUpperInvariant().GetHashCode();
        }
    }
}
