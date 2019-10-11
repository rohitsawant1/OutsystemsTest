/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.DatabaseProvider.MySQL.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.Platform.DatabaseObjects;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.Platform.DatabaseObjects {
    public class MySQLPlatformTableSourceColumnInfo : MySQLTableSourceColumnInfo, IPlatformTableSourceColumnInfo {

        public MySQLPlatformTableSourceColumnInfo(ITableSourceInfo tableSource, string name, IPlatformDataTypeInfo dataType, bool isMandatory, bool isPrimaryKey, bool isAutoNumber) : base(tableSource, name, dataType, isMandatory, isPrimaryKey, isAutoNumber) {}

        public new IPlatformDataTypeInfo DataType {
            get { return (IPlatformDataTypeInfo)base.DataType; }
        }
    }
}
