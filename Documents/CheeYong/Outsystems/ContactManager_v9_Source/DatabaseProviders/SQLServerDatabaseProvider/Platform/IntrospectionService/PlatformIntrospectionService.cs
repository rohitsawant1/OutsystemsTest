/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.DatabaseObjects;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.DMLService;
using OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.Platform;
using OutSystems.HubEdition.Extensibility.Data.Platform.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.Platform.IntrospectionService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.SqlServer.Platform.IntrospectionService {
    public class PlatformIntrospectionService : SqlServer.IntrospectionService.IntrospectionService, IPlatformIntrospectionService {

        private IDictionary<string, IPlatformTableSourceEventTriggerInfo> Triggers;

        IPlatformDatabaseServices IPlatformIntrospectionService.DatabaseServices { get { return (IPlatformDatabaseServices) DatabaseServices; } }

        public PlatformIntrospectionService(IPlatformDatabaseServices databaseServices) : base(databaseServices) {}


        private bool IsAzure() {
            using (var conn = DatabaseServices.TransactionService.CreateConnection()) {
                using (var cmd = DatabaseServices.ExecutionService.CreateCommand(conn, "SELECT SERVERPROPERTY('EngineEdition')")) {
                    return Convert.ToInt32(cmd.ExecuteScalar()) == 5;
                }
            }
        }

        public override IEnumerable<IDatabaseInfo> ListDatabases() {
            return ListDatabases(!IsAzure()); // linked servers are not supported in azure
        }

        public IDictionary<ITableSourceInfo, IPlatformTableSourceInfo> GetTableSourcesDetails(params ITableSourceInfo[] tables) {
            IDictionary<ITableSourceInfo, IPlatformTableSourceInfo> tablesDetails =
                new Dictionary<ITableSourceInfo, IPlatformTableSourceInfo>();

            IList<ITableSourceInfo> tableSourceList = tables.ToList();
            if (tableSourceList.IsNullOrEmpty()) {
                return tablesDetails;
            }

            InitializeTriggers(tableSourceList);

            foreach (var tableSource in tableSourceList) {
                tablesDetails.Add(tableSource, GetTableInfo(tableSource));
            }

            return tablesDetails;
        }

        private PlatformTableSourceInfo GetTableInfo(ITableSourceInfo tableSource) {
            TableSourceInfo tableSourceInfo = tableSource as TableSourceInfo;
            if (tableSourceInfo == null) {
                return null;
            }

            PlatformTableSourceInfo tableSourceDetails = new PlatformTableSourceInfo(tableSourceInfo);
            tableSourceDetails.Columns = GetColumns(tableSourceInfo);
            tableSourceDetails.ForeignKeys = GetForeignKeys(tableSourceInfo);
            tableSourceDetails.Indexes = GetIndexes(tableSourceInfo, tableSourceDetails.Columns);
            tableSourceDetails.EventTrigger = Triggers.GetValueOrDefault(tableSourceInfo.Name.ToUpperInvariant());
            return tableSourceDetails;
        }

        private void InitializeTriggers(IEnumerable<ITableSourceInfo> tableSources) {
            Triggers = new Dictionary<string, IPlatformTableSourceEventTriggerInfo>();
            using (IDbConnection conn = DatabaseServices.TransactionService.CreateConnection()) {
                IEnumerable<ITableSourceInfo> tableSourceList = tableSources.ToList();

                using (IDataReader reader = GetTriggers(conn, tableSourceList)) {
                    while (reader.Read()) {
                        string tableName = Convert.ToString(reader["table_name"]).ToUpperInvariant();
                        string triggerName = Convert.ToString(reader["trigger_name"]).ToUpperInvariant();
                        var tableSource = tableSourceList.First(t => ((TableSourceInfo)t).Name.EqualsIgnoreCase(tableName)) as TableSourceInfo;

                        Triggers[tableName] = new PlatformTableSourceTriggerInfo(tableSource, triggerName);
                    }
                }
            }
        }

        private IDataReader GetTriggers(IDbConnection conn, IEnumerable<ITableSourceInfo> tableSources) {
            DatabaseInfo dbInfo = DatabaseServices.ObjectFactory.CreateLocalDatabaseInfo() as DatabaseInfo;
            if (dbInfo == null) {
                return null;
            }
            
            string tableNames = "'" + tableSources.Select(t => t.Name).StrCat("','") + "'";
            string sql = string.Format(@"SELECT trig.name trigger_name, tab.Name table_name
                FROM {0}.sys.triggers trig
                INNER JOIN {0}.sys.tables tab ON tab.object_id = trig.parent_id
                WHERE tab.Name IN ({1}) and UPPER(trig.name) LIKE '{2}%'", DMLIdentifiers.EscapeIdentifierInner(dbInfo.Catalog), tableNames, 
                PlatformDatabaseObjectConstants.EventTriggerPrefix);
            
            IDbCommand cmd = DatabaseServices.ExecutionService.CreateCommand(conn, sql);
            cmd.CommandTimeout = QueryTimeout;
            return DatabaseServices.ExecutionService.ExecuteReader(cmd);
        }

        private IEnumerable<IPlatformTableSourceIndexInfo> GetIndexes(TableSourceInfo tableSource, IEnumerable<IPlatformTableSourceColumnInfo> columns) {
            IDictionary<string, IPlatformTableSourceIndexInfo> indexes = new Dictionary<string, IPlatformTableSourceIndexInfo>();
            using (IDbConnection conn = DatabaseServices.TransactionService.CreateConnection()) {
                using (IDataReader reader = GetTableSourceIndexes(conn, tableSource)) {
                    while (reader.Read()) {
                        string indexName = Convert.ToString(reader["idxName"]);
                        if (indexName.StartsWith("_WA_SYS_")) { // _WA_SYS_* are statistics, not indexes 
                            continue;
                        }

                        bool isUnique = (bool)reader["isUnique"];
                        bool isPrimaryKey = (bool)reader["isPrimaryKey"];
                        string columnName = Convert.ToString(reader["colName"]);

                        if (!indexName.IsNullOrEmpty()) {
                            IPlatformTableSourceIndexInfo index;
                            if (!indexes.TryGetValue(indexName, out index)) {
                                index = new PlatformTableSourceIndexInfo(tableSource, indexName, isUnique, isPrimaryKey);
                                indexes.Add(indexName, index);
                            }
                            IPlatformTableSourceColumnInfo column = columns.Single(c => c.Name.EqualsIgnoreCase(columnName));
                            ((PlatformTableSourceIndexInfo)index).AddColumn(column);
                        }
                    }
                    return indexes.Values.ToList();
                }
            }
        }

        private IDataReader GetTableSourceIndexes(IDbConnection conn, TableSourceInfo tableSource) {
            string paramPrefix = DatabaseServices.ExecutionService.ParameterPrefix;
            string sql = String.Format(@"SELECT TheTable.name, TheIndex.name idxName, TheIndex.is_unique isUnique, TheIndex.is_primary_key isPrimaryKey, Cols.name colName 
                          FROM {0}.sys.indexes TheIndex 
                          INNER JOIN {0}.sys.index_columns vIdxK ON TheIndex.index_id = vIdxK.index_id AND TheIndex.object_id = vIdxK.object_id 
                          INNER JOIN {0}.sys.objects TheTable ON TheTable.object_id = TheIndex.object_id 
                          INNER JOIN {0}.sys.columns Cols ON vIdxK.column_id = Cols.column_id and vIdxK.object_id = Cols.object_id 
                          WHERE TheIndex.is_unique_constraint = 0 
                              AND TheTable.name = " + paramPrefix + "tableName", DMLIdentifiers.EscapeIdentifierInner(tableSource.Database.Catalog));

            IDbCommand cmd = DatabaseServices.ExecutionService.CreateCommand(conn, sql);
            cmd.CommandTimeout = QueryTimeout;
            DatabaseServices.ExecutionService.CreateParameter(cmd, paramPrefix + "tableName", DbType.String, tableSource.Name);
            return DatabaseServices.ExecutionService.ExecuteReader(cmd);
        }

        private IEnumerable<IPlatformTableSourceColumnInfo> GetColumns(TableSourceInfo tableSource) {
            HashSet<string> primaryKeyColumns = GetPrimaryKeyColumns(tableSource);
            HashSet<string> autoGeneratedColumns = GetAutoGeneratedColumns(tableSource);

            using (IDbConnection conn = DatabaseServices.TransactionService.CreateConnection()) {
                using (IDataReader reader = GetTableSourceColumns(conn, tableSource)) {
                    while (reader.Read()) {
                        string columnName = Convert.ToString(reader["COLUMN_NAME"]);
                        string dataType = Convert.ToString(reader["DATA_TYPE"]);
                        int decimalDigits = Convert.ToInt32(reader["NUMERIC_SCALE"]);
                        int length = Convert.ToInt32(reader["CHARACTER_MAXIMUM_LENGTH"]);
                        int precision = Convert.ToInt32(reader["NUMERIC_PRECISION"]);

                        IPlatformDataTypeInfo type = CreateDataTypeInfo(dataType, decimalDigits, length, precision);

                        bool isMandatory = !Convert.ToString(reader["IS_NULLABLE"]).EqualsIgnoreCase("YES");
                        bool isPrimaryKey = primaryKeyColumns.Contains(columnName);
                        bool isAutoGenerated = autoGeneratedColumns.Contains(columnName);
                        yield return new PlatformTableSourceColumnInfo(tableSource, columnName, type, isMandatory, isPrimaryKey, isAutoGenerated);
                    }
                }
            }
        }

        private IDataReader GetTableSourceColumns(IDbConnection conn, TableSourceInfo tableSource) {
            string paramPrefix = DatabaseServices.ExecutionService.ParameterPrefix;
            string sql = string.Format(@"select vCols.column_name, vCols.data_type, isnull(vCols.CHARACTER_MAXIMUM_LENGTH, 0) CHARACTER_MAXIMUM_LENGTH, 
                                  isnull(vCols.NUMERIC_PRECISION, 0) NUMERIC_PRECISION, isnull(vCols.NUMERIC_SCALE, 0) NUMERIC_SCALE,
                                  vCols.is_nullable 
                           from {0}.INFORMATION_SCHEMA.COLUMNS vCols 
                           where vCols.TABLE_SCHEMA = 'dbo' AND vCols.TABLE_NAME=" + paramPrefix + @"tableName 
                           order by vCols.column_name asc", DMLIdentifiers.EscapeIdentifierInner(tableSource.Database.Catalog));

            IDbCommand cmd = DatabaseServices.ExecutionService.CreateCommand(conn, sql);
            cmd.CommandTimeout = QueryTimeout;
            DatabaseServices.ExecutionService.CreateParameter(cmd, paramPrefix + "tableName", DbType.String, tableSource.Name);
            return cmd.ExecuteReader();
        }

        private IPlatformDataTypeInfo CreateDataTypeInfo(string dataType, int decimalDigits, int length, int precision) {
            int fLength = 0;
            int fDecimals = 0;
            DBDataType type;

            switch (dataType) {
                case "int":
                    type = DBDataType.INTEGER;
                    break;
                case "bigint":
                    type = DBDataType.LONGINTEGER;
                    break;
                case "varchar":
                case "nvarchar":
                    fLength = (length < 0 ? int.MaxValue : length);
                    type = DBDataType.TEXT;
                    break;
                case "datetime":
                case "time":
                    type = DBDataType.DATE_TIME;
                    break;
                case "bit":
                    type = DBDataType.BOOLEAN;
                    break;
                case "decimal":
                    fLength = precision;
                    fDecimals = decimalDigits;
                    type = DBDataType.DECIMAL;
                    break;
                case "text":
                case "ntext":
                    fLength = int.MaxValue;
                    type = DBDataType.TEXT;
                    break;
                case "image":
                    type = DBDataType.BINARY_DATA;
                    break;
                case "varbinary":
                    type = length < 0 ? DBDataType.BINARY_DATA : DBDataType.UNKNOWN;
                    break;
                default:
                    type = DBDataType.UNKNOWN;
                    break;
            }
            return new PlatformDataTypeInfo(type, dataType, fLength, fDecimals);
        }

        public IDictionary<string, bool> CheckTableSourcesExist(params string[] tableSourcesNames) {
            DatabaseInfo dbInfo = DatabaseServices.ObjectFactory.CreateLocalDatabaseInfo() as DatabaseInfo;
            if (dbInfo == null) {
                return null;
            }
            
            HashSet<string> tableSourcesFound = new HashSet<string>();
            IList<string> tableSourceNamesList = tableSourcesNames.ToList();
            if (tableSourceNamesList.IsNullOrEmpty()) {
                return null;
            }

            using (IDbConnection conn = DatabaseServices.TransactionService.CreateConnection()) {
                string tableCondition;
                string paramPrefix = DatabaseServices.ExecutionService.ParameterPrefix;
                if (tableSourceNamesList.Count == 1) {
                    tableCondition = "=" + paramPrefix + "tablename";
                } else {
                    tableCondition = " IN ('" + tableSourceNamesList.StrCat("','").ToUpper() + "')";
                }
                string sql = string.Format(@"(SELECT TABLE_NAME 
                                              FROM {0}.INFORMATION_SCHEMA.TABLES 
                                              WHERE TABLE_NAME {1})
                                             UNION
                                             (SELECT TABLE_NAME 
                                              FROM {0}.INFORMATION_SCHEMA.VIEWS
                                              WHERE TABLE_NAME {1})", DMLIdentifiers.EscapeIdentifierInner(dbInfo.Catalog), tableCondition);

                using (IDbCommand cmd = DatabaseServices.ExecutionService.CreateCommand(conn, sql)) {
                    if (tableSourceNamesList.Count == 1) {
                        DatabaseServices.ExecutionService.CreateParameter(cmd,
                            paramPrefix + "tablename", DbType.String, tableSourceNamesList.First().ToUpper());
                    }
                    cmd.CommandTimeout = QueryTimeout;
                    using (IDataReader reader = DatabaseServices.ExecutionService.ExecuteReader(cmd)) {
                        while (reader.Read()) {
                            tableSourcesFound.Add(Convert.ToString(reader["TABLE_NAME"]).ToUpper());
                        }
                    }
                }
            }

            IDictionary<string, bool> result = new Dictionary<string, bool>();
            foreach (var tableSource in tableSourceNamesList) {
                result.Add(tableSource, tableSourcesFound.Contains(tableSource.ToUpper()));
            }
            return result;
        }

        public int GetDatabaseObjectsDefinitionHash(string objectNameFilter) {
            int hashResult = -1;
            DatabaseInfo dbInfo = DatabaseServices.ObjectFactory.CreateLocalDatabaseInfo() as DatabaseInfo;
            if (dbInfo == null) {
                return hashResult;
            }

            using (IDbConnection conn = DatabaseServices.TransactionService.CreateConnection()) {
                IDMLIdentifiers identifiers = DatabaseServices.DMLService.Identifiers;
                string sql = string.Format(@"SELECT BINARY_CHECKSUM(max(modify_date) + count(name))
                                             FROM {0}.sys.all_objects
                                             WHERE name LIKE '%{1}%'", identifiers.EscapeIdentifier(dbInfo.Catalog), objectNameFilter);
                using (IDbCommand cmd = DatabaseServices.ExecutionService.CreateCommand(conn, sql)) {
                    cmd.CommandTimeout = QueryTimeout;
                    hashResult = Convert.ToInt32(DatabaseServices.ExecutionService.ExecuteScalar(cmd));
                }
            }
            return hashResult;
        }
    }
}
