/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.DatabaseProvider.SqlServer.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.Platform.DatabaseObjects;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.DatabaseObjects {
    public class PlatformTableSourceColumnInfo : TableSourceColumnInfo, IPlatformTableSourceColumnInfo {
        
        public PlatformTableSourceColumnInfo(ITableSourceInfo tableSource, string name, IPlatformDataTypeInfo dataType, bool isMandatory, bool isPrimaryKey, bool isAutoGenerated) : base(tableSource, name, dataType, isMandatory, isPrimaryKey, isAutoGenerated) {}

        public new IPlatformDataTypeInfo DataType {
            get { return (IPlatformDataTypeInfo)base.DataType; }
        }
    }
}
