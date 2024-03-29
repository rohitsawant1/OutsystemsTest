/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.DatabaseObjects {
    public class MySQLTableSourceForeignKeyInfo : ITableSourceForeignKeyInfo {

        public MySQLTableSourceForeignKeyInfo(ITableSourceInfo tableSource, string name, string columnName, ITableSourceInfo referencedTableSource, string referencedColumnName, bool isCascadeDelete) {
            TableSource = tableSource;
            Name = name;
            ColumnName = columnName;
            ReferencedTableSource = referencedTableSource;
            ReferencedColumnName = referencedColumnName;
            IsCascadeDelete = isCascadeDelete;
        }

        public ITableSourceInfo TableSource { get; private set; }
        public string Name { get; private set; }
        public string ColumnName { get; private set; }
        public ITableSourceInfo ReferencedTableSource { get; private set; }
        public string ReferencedColumnName { get; private set; }
        public bool IsCascadeDelete { get; private set; }

    }
}
