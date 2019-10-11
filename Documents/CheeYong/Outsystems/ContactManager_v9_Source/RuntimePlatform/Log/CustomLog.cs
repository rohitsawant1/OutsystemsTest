/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.HubEdition.RuntimePlatform.MetaInformation;
using OutSystems.Internal.Db;
using OutSystems.Logging.LogDefinition;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.Log {

    [Serializable]
    public class CustomLog {
        private CustomLogDefinition log;

        public string PhysicalTableName {
            get { return log.PhysicalTableName; }
        }

        public string EntityName {
            get { return log.EntityName; }
        }

        public int EntityGeneration {
            get { return log.EntityGeneration; }
        }

        public string DBConnection {
            get { return log.DBConnection; }
        }

        public string DbCatalog {
            get { return log.DbCatalog; }
        }

        private string GenerateTableUniqueKey() {
            return PhysicalTableName + "|" + EntityGeneration + "|" + DbCatalog + "|" + DBConnection + "|";
        }

        private IDictionary<string, CustomLogDefinition.CustomLogFieldDefinition> Fields {
            get {
                return log.Fields;
            }
        }

        public CustomLog(object ssRecord) {

            if (ssRecord is IRecord) {
                // Record inspection:
                // - get structure field from record
                // - get its EntityRecordDetails attribute
                // - there must be a single structure in the record (this is an entity record and not a recordjoin)
                EntityRecordDetails entityDetails = null;
                if (ssRecord is ISimpleRecord) {
                    entityDetails = ssRecord.GetType().GetCustomAttributes(typeof(EntityRecordDetails), false).FirstOrDefault() as EntityRecordDetails;
                } else {

                    var entAttr = ssRecord.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)
                                           .Select(
                                               field =>
                                                   new {
                                                       Field = field,
                                                       EntityDetails = field.FieldType.GetCustomAttributes(typeof(EntityRecordDetails), false).FirstOrDefault()
                                                   })
                                           .Where(fa => fa.EntityDetails != null)
                                           .FirstIfSingleOrDefault();
                    if (entAttr != null) {
                        entityDetails = (EntityRecordDetails)entAttr.EntityDetails;
                        ssRecord = entAttr.Field.GetValue(ssRecord);
                    }
                }


                if (entityDetails != null) {

                    var entityName = entityDetails.Name;
                    var entityGeneration = entityDetails.Generation;
                    var physicalTableName = entityDetails.PhysicalTableName;
                    var dbConnection = entityDetails.DBConnection;

                    var structAttrs = ssRecord.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                    // This method uses cache
                    var dbCatalog = DatabaseAccess.ForEspaceDatabase(ObjectKeyUtils.DatabaseValue(ObjectKey.Parse(entityDetails.OwnerKey))).DatabaseServices.DatabaseConfiguration.DatabaseIdentifier;

                    log = new CustomLogDefinition(entityName: entityName,
                                                  physicalTableName: physicalTableName,
                                                  dbConnection: dbConnection,
                                                  entityGeneration: entityGeneration,
                                                  dbCatalog: dbCatalog);

                    for (int i = 0; i < structAttrs.Length; i++) {
                        var attrs = (Attribute[])structAttrs[i].GetCustomAttributes(typeof(EntityAttributeDetails), false);
                        if (attrs.Length == 1) {
                            EntityAttributeDetails entityAttributeDetails = (EntityAttributeDetails)attrs[0];
                            if (!entityAttributeDetails.IsAutonumber) {
                                var customLogField = new CustomLogDefinition.CustomLogFieldDefinition(structAttrs[i].GetValue(ssRecord), entityAttributeDetails.IsEntityReference, entityAttributeDetails.IsMandatory);
                                log.Fields.Add(entityAttributeDetails.Name, customLogField);
                            }

                        }
                    }
                    return;
                }
            }

            throw new InvalidCastException("Unable to convert to record");
        }

        public void Write() {
            this.log.Write();
        }

        // Do not delete this method, it's used in the AsynchronousLogging extension
        public static void Write(CustomLog log) {
            log.Write();
        }

        // Do not delete this method, it's used in the PlatformRuntime_API extension
        public static void SynchronousWrite(CustomLog log) {
            SynchronousWrite(new List<CustomLog>() { log });
        }

        public static void SynchronousWrite(List<CustomLog> logList) {
            IEnumerable<DataTable> tables = ConvertToDataTable(logList);
            foreach (CustomLogDataTable tab in tables) {
                var databaseAccessProvider = RuntimePlatformServices.RuntimeLoggingDatabaseService.Instance.GetProviderFor(tab);
                databaseAccessProvider.DatabaseServices.ExecutionService.BulkInsert(tab);
            }
        }

        private static IEnumerable<DataTable> ConvertToDataTable(IEnumerable<CustomLog> logList) {
            // Aggregate by message kind
            var tables = new Dictionary<string, CustomLogDataTable>();

            foreach (CustomLog log in logList) {
                var key = log.GenerateTableUniqueKey();

                CustomLogDataTable table;
                if (!tables.TryGetValue(key, out table)) {
                    table = new CustomLogDataTable(log.PhysicalTableName) {
                        DbConnection = log.DBConnection,
                        DbCatalog = log.DbCatalog,
                    };

                    foreach (var field in log.Fields) {
                        var customLogField = field.Value;
                        table.Columns.Add(field.Key, customLogField.Value.GetType());
                    }

                    tables.Add(key, table);
                }

                var row = table.NewRow();
                foreach (var field in log.Fields) {
                    object valueAux = null;
                    //#1026097 - When the entity attribute is an EntityReference, is not mandatory and its value is '0'
                    //replace the value by a BDNULL to avoid hitting the foreign key constraint.
                    var customLogField = field.Value;
                    if (customLogField.IsEntityReference && !customLogField.IsMandatory && customLogField.Value.Equals(0)) {
                        valueAux = DBNull.Value;
                    } else {
                        valueAux = customLogField.Value;
                    }
                    row[field.Key] = valueAux;
                }
                table.Rows.Add(row);
            }

            return tables.Values.Cast<DataTable>();
        }

        private sealed class CustomLogDataTable : DataTable, ICustomLogInformation {
            public string DbConnection { get; set; }
            public string DbCatalog { get; set; }
            public CustomLogDataTable(string physicalTableName)
                : base(physicalTableName) {
            }
        }

    }

}
