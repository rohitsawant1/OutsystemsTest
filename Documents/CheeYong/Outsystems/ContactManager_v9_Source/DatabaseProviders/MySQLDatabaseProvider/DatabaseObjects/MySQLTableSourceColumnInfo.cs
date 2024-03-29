/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.DatabaseObjects {
    public class MySQLTableSourceColumnInfo : ITableSourceColumnInfo {

        public MySQLTableSourceColumnInfo(ITableSourceInfo tableSource, string name, IDataTypeInfo dataType, bool isMandatory, bool isPrimaryKey, bool isAutoGenerated, bool isUnsigned) {
            TableSource = tableSource;
            Name = name;
            DataType = dataType;
            IsMandatory = isMandatory;
            IsPrimaryKey = isPrimaryKey;
            IsAutoGenerated = isAutoGenerated;
            IsUnsigned = isUnsigned;
        }

        public MySQLTableSourceColumnInfo(ITableSourceInfo tableSource, string name, IDataTypeInfo dataType, bool isMandatory, bool isPrimaryKey, bool isAutoGenerated) {
            TableSource = tableSource;
            Name = name;
            DataType = dataType;
            IsMandatory = isMandatory;
            IsPrimaryKey = isPrimaryKey;
            IsAutoGenerated = isAutoGenerated;
        }

        public ITableSourceInfo TableSource { get; private set; }
        public string Name { get; private set; }
        public virtual IDataTypeInfo DataType { get; private set; }
        public bool IsMandatory { get; private set; }
        public bool IsPrimaryKey { get; internal set; }
        public bool IsAutoGenerated { get; private set; }
        public bool IsUnsigned { get; private set; }
    }
}
