/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.DMLService {
    public class MySQLDMLEntityActions : BaseDMLEntityActions {

        internal MySQLDMLEntityActions(IDMLService dmlService, ITableSourceInfo tableSourceInfo) : base(dmlService, tableSourceInfo) { }

        private volatile IDictionary<SelectPlaceholder, string> getForUpdatePlaceholderValues;
        private volatile IDictionary<InsertPlaceholder, string> createAndRetrieveIdPlaceholderValues;


        public override IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForGetForUpdate() {
            if (getForUpdatePlaceholderValues == null) {
                lock (this) {
                    if (getForUpdatePlaceholderValues == null) {
                        getForUpdatePlaceholderValues = new Dictionary<SelectPlaceholder, string>();
                        getForUpdatePlaceholderValues.Add(SelectPlaceholder.AfterStatement, " FOR UPDATE");
                    }
                }
            }
            return getForUpdatePlaceholderValues;
        }

        public override IDictionary<InsertPlaceholder, string> SQLPlaceholderValuesForCreateAndRetrieveId(string idColumnName, string outputParameterName, out RetrieveIdMethod retrieveIdMethod) {
            retrieveIdMethod = RetrieveIdMethod.ReturnValue;
            if (createAndRetrieveIdPlaceholderValues == null) {
                lock (this) {
                    if (createAndRetrieveIdPlaceholderValues == null) {
                        createAndRetrieveIdPlaceholderValues = new Dictionary<InsertPlaceholder, string>();
                        createAndRetrieveIdPlaceholderValues.Add(InsertPlaceholder.AfterStatement, "; SELECT LAST_INSERT_ID()");
                    }
                }
            }
            return createAndRetrieveIdPlaceholderValues;
        }
    }
}
