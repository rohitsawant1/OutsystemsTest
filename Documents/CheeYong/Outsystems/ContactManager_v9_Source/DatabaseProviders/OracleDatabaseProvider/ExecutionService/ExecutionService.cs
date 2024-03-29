/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Text.RegularExpressions;
using Oracle.ManagedDataAccess.Types;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.ObfuscationProperties;
using System;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;
using OutSystems.RuntimeCommon.Log;

namespace OutSystems.HubEdition.DatabaseProvider.Oracle.ExecutionService {
    [DoNotObfuscate]
    public class ExecutionService: BaseExecutionService {
        public const int MAX_VARCHAR_PARAM_LENGTH = 4000;
        protected const short FETCH_SIZE_INCREASE_FACTOR = 4;

        public override string ParameterPrefix {
            get {
                return ":";
            }
        }

		protected override void SetCorrectDBType(DbType dbType, IDbDataParameter param) {
            // In Oracle the datetime type needs to be added as a timestamp (#16705)
			// In Oracle, there is no Unicode support (#42383)			
            if (this.IsDateType(dbType)) {
                ((OracleParameter)param).OracleDbType = OracleDbType.TimeStamp;
                return;
            }

            if (this.IsUnicodeStringType(dbType)) {
                param.DbType = DbType.AnsiString;
                return;
            }

            if (dbType == DbType.Boolean) {
                param.DbType = DbType.Byte;
                return;
            }

            base.SetCorrectDBType(dbType, param);
		}

        protected override IDbCommand CreateCommand(IDbConnection connection) {
            OracleCommand cmd = base.CreateCommand(connection) as OracleCommand;
            if (cmd == null) {
                return null;
            }
            cmd.BindByName = true;
            cmd.InitialLONGFetchSize = -1;
            cmd.AddToStatementCache = false; /*do not add this statement to the driver's cache*/
            return cmd;
        }

        public override void SetParameterValue(IDbDataParameter param, DbType dbType, object paramValue) {
            var paramValueArray = paramValue as Array;

            if ((paramValueArray != null) && (paramValueArray.Length == 0)) {
                // 2004-11-08 MRC Oracle doesn't like empty arrays
                param.Value = DBNull.Value;
                param.Size = 0;
            } else {
                if ((this.IsUnicodeStringType(dbType) || (dbType == DbType.AnsiString))) {
                    var paramStr = paramValue as string;

                    if ((paramStr != null) && (paramStr.Length > MAX_VARCHAR_PARAM_LENGTH)) {
                        ((OracleParameter) param).OracleDbType = OracleDbType.Clob;
                    }
                }
            
                base.SetParameterValue(param, dbType, paramValue);
            }
        }

        public override DbType ConvertToDbType(DBDataType type, string providerType) {
            if (DBDataType.TEXT == type) {
                //Remove extra info from name (ex: "NCHAR(10)")
                var providerTypeOnly = providerType.IsNullOrEmpty() ? "" : providerType.Split('(')[0];
                switch (providerTypeOnly.ToUpper()) {
                    case "NCHAR":
                    case "NVARCHAR2":
                    case "NCLOB":
                        return DbType.String;
                    case "FLOAT":
                    case "BINARY_FLOAT":
                        return DbType.Single;
                    case "BINARY_DOUBLE":
                        return DbType.Double;
                    case "NUMBER":
                        return DbType.Decimal;
                    default:
                        return DbType.AnsiString;
                }
            }

            if (DBDataType.TIME == type) {
                throw new NotSupportedException("Unable to convert " + type.ToString() + " to DbType");
            }

            return base.ConvertToDbType(type, providerType);
        }

        public override object TransformRuntimeToDatabaseValue(DbType dbType, object value) {

            var valueString = value as string;

            if (IsStringOrAnsiStringDbType(dbType) && (valueString != null) && (valueString.Length == 0)) {
                return " ";
            }

            return base.TransformRuntimeToDatabaseValue(dbType, value);
        }

        public ExecutionService(IDatabaseServices databaseServices) : base(databaseServices) {}

        [DoNotObfuscate]
        public void ForceCSASSetting(IDbConnection conn) {
            string commandText = "ALTER SESSION SET NLS_COMP=BINARY NLS_SORT=BINARY";
            IDbCommand cmd = CreateCommand(conn, commandText);
            cmd.ExecuteNonQuery();
        }

        [DoNotObfuscate]
        public void ForceCSASSetting(IDbTransaction trans) {
            string commandText = "ALTER SESSION SET NLS_COMP=BINARY NLS_SORT=BINARY";
            IDbCommand cmd = CreateCommand(trans, commandText);
            cmd.ExecuteNonQuery();
        }

        [DoNotObfuscate]
        public void ForceCIAISetting(IDbTransaction trans) {
            string commandText = "ALTER SESSION SET NLS_COMP=LINGUISTIC NLS_SORT=BINARY_AI";
            IDbCommand cmd = CreateCommand(trans, commandText);
            cmd.ExecuteNonQuery();
        }

        [DoNotObfuscate]
        public void RestoreComparisonSettings(IDbTransaction trans) {
            TransactionService.RestoreComparisonSettings(trans, this);
        }

        public OutSystems.HubEdition.DatabaseProvider.Oracle.TransactionService.TransactionService TransactionService { 
            get {
                return (OutSystems.HubEdition.DatabaseProvider.Oracle.TransactionService.TransactionService) DatabaseServices.TransactionService;
            }
        }

        public override bool IsConnectionException(DbException e) {
            return ((OracleException)e).Number == 12571;
        }

        public bool IsConnectedUser(IDbConnection conn, string userName) {
            if (conn == null || userName.IsNullOrEmpty() || conn.ConnectionString.IsNullOrEmpty()) {
                return false;
            }
            Regex pattern = new Regex("user id\\s*=\\s*([^;]+)");
            Match m = pattern.Match(conn.ConnectionString.ToLowerInvariant());
            if (m.Groups.Count > 0) {
                return (m.Groups[1].Value == userName.ToLowerInvariant());
            }
            return false;
        }

        public override IDataReader ExecuteReader(IDbCommand cmd) {
            try {
                var reader = (OracleDataReader)cmd.ExecuteReader();
                if (reader.HasRows) {
                    SetDataReaderFetchSize(reader);
                }
                return new OracleDataReaderWrapper(reader, this);
            } catch (DbException e) {
                OSTrace.Error("Error executing ExecuteReader (" + e.Message + ") with statement:" + Environment.NewLine + cmd.CommandText);
                throw;
            }
        }

        protected virtual void SetDataReaderFetchSize(OracleDataReader reader) {
            reader.FetchSize = reader.FetchSize * FETCH_SIZE_INCREASE_FACTOR;
        }

        // Overcome cast issues by using our OracleDataReaderWrapper to fetch the scalar value
        public override object ExecuteScalar(IDbCommand cmd) {
            OracleCommand oracleCommand = (OracleCommand) cmd;
            oracleCommand.FetchSize = 1;
            using (var reader = ExecuteReader(oracleCommand)) {
                if (reader.Read()) {
                    return reader.GetValue(0);
                }
            }
            return null;
        }

        public override void SetParameterDirection(IDbDataParameter param, ParameterDirection direction) {
            if (direction == ParameterDirection.Output) {
                var oracleParam = param as OracleParameter;

                if ((oracleParam != null) && (oracleParam.OracleDbType == OracleDbType.TimeStampLTZ)) {
                    // Fix the oracle type for output parameters...
                    oracleParam.OracleDbType = OracleDbType.TimeStampTZ;
                }
            }

            base.SetParameterDirection(param, direction);
        }
       
        public override object TransformDatabaseToRuntimeValue(object value) {
            if (value == null || value == DBNull.Value) {
                return value;
            }

            var valueAsString = value as string;
            if (valueAsString != null) {
                // Fix empty string
                return OracleTypeHelper.FixEmptyString(valueAsString);
            }

            var valueAsNullable = value as INullable;
            if (valueAsNullable != null && valueAsNullable.IsNull) {
                return DBNull.Value;
            }

            var valueAsConvertible = value as IConvertible;
            if (valueAsConvertible != null) {
                return valueAsConvertible;
            }

            // Common types

            var isString = value is OracleString;
            if (isString) {
                return OracleTypeHelper.FixEmptyString(((OracleString)value).Value);
            }

            var isDecimal = value is OracleDecimal;
            if (isDecimal) {
                // Fix decimal precision
                try {
                    return OracleTypeHelper.FixDecimalPrecision((OracleDecimal)value);
                } catch (Exception) { // In this case we are mapping the column to Text
                    return value.ToString();
                }
                
            }

            var isTimestamp = value is OracleTimeStamp;
            if (isTimestamp) {
                return ((OracleTimeStamp)value).Value;
            }

            var clobValue = value as OracleClob;
            if (clobValue != null) {
                return clobValue.Value;
            }

            var blobValue = value as OracleBlob;
            if (blobValue != null) {
                return blobValue.Value;
            }

            // Other types

            var isDate = value is OracleDate;
            if (isDate) {
                return ((OracleDate)value).Value;
            }

            var isTimestampTZ = value is OracleTimeStampTZ;
            if (isTimestampTZ) {
                return ((OracleTimeStampTZ)value).Value;
            }

            var isTimestampLTZ = value is OracleTimeStampLTZ;
            if (isTimestampLTZ) {
                return ((OracleTimeStampLTZ)value).Value;
            }

            var isIntervalDS = value is OracleIntervalDS;
            if (isIntervalDS) {
                return ((OracleIntervalDS)value).Value;
            }

            var isIntervalYM = value is OracleIntervalYM;
            if (isIntervalYM) {
                return ((OracleIntervalYM)value).Value;
            }

            var isBinary = value is OracleBinary;
            if (isBinary) {
                return ((OracleBinary)value).Value;
            }

            var bFileValue = value as OracleBFile;
            if (bFileValue != null) {
                return bFileValue.Value;
            }

            var xmlValue = value as OracleXmlType;
            if (xmlValue != null) {
                return xmlValue.Value;
            }

            return value;
        }

        public override void BulkInsert(DataTable tab) {
            using (var con = DatabaseServices.TransactionService.CreateConnection()) {
                try {
                    BulkCopy(con, tab);
                } catch (OracleException) {
                    if (!DatabaseServices.TransactionService.IsClosed(con)) {
                        BulkCopy(con, tab);
                    }
                    throw;
                }
            }
        }

        private static OracleDbType ConvertDbTypeToOracleDbType(DbType t, int maxlength) {
            switch (t) {
                case DbType.String:
                    // fix for ORA-01461 bug
                    return maxlength > 1000 ? OracleDbType.Clob : OracleDbType.Varchar2;
                case DbType.Int32:
                    return OracleDbType.Int32;
                case DbType.Int64:
                    return OracleDbType.Int64;
                case DbType.DateTime:
                    return OracleDbType.TimeStamp;
                case DbType.AnsiString:
                    return OracleDbType.Varchar2;
                case DbType.Decimal:
                    return OracleDbType.Decimal;
                case DbType.Boolean:
                    return OracleDbType.Int32;
                default:
                    throw new NotSupportedException("Unable to convert " + t.ToString() + " to OracleDbType");
            }
        }

        public void BulkCopy(IDbConnection con, DataTable tab) {

            int rowsWithoutErrors = 0;
            IDbTransaction tran = null;
            try {
                tran = con.BeginTransaction();

                string strValue;
                int maxLength;
                string columns = "";
                string parameters = "";
                string prepend = "";

                foreach (DataRow r in tab.Rows) {
                    if (string.IsNullOrEmpty(r.RowError)) {
                        rowsWithoutErrors++;
                    }
                }
                if (rowsWithoutErrors == 0) {
                    return;
                }

                using (OracleCommand cmd = (OracleCommand) con.CreateCommand()) {

                    foreach (DataColumn col in tab.Columns) {
                        maxLength = 0;
                        columns += prepend + DatabaseServices.DMLService.Identifiers.EscapeIdentifier(col.ColumnName);
                        parameters += prepend + ":" + (col.Ordinal + 1);
                        prepend = ",";
                        DbType dbType = ConvertToDbType(col.DataType);
                        object[] paramValues = new object[rowsWithoutErrors];
                        int paramIndex = 0;
                        for (int tabIndex = 0; tabIndex < tab.Rows.Count; tabIndex++) {
                            if (string.IsNullOrEmpty(tab.Rows[tabIndex].RowError)) {
                                paramValues[paramIndex] = TransformRuntimeToDatabaseValue(dbType, tab.Rows[tabIndex][col]);

                                strValue = paramValues[paramIndex] as string;

                                if (strValue != null && maxLength < strValue.Length) {
                                    maxLength = strValue.Length;
                                }

                                paramIndex++;
                            }
                        }

                        cmd.Parameters.Add(col.ColumnName,
                            ConvertDbTypeToOracleDbType(dbType, maxLength),
                            paramValues, ParameterDirection.Input);
                    }

                    cmd.ArrayBindCount = rowsWithoutErrors;
                    cmd.BindByName = false;
                    cmd.CommandText = "INSERT INTO " + tab.TableName + " (" + columns + ") VALUES (" + parameters + ")";

                    try {
                        cmd.ExecuteNonQuery();
                    } catch (OracleException e) {
                        switch (e.Number) {
                            case 24381: //ORA-24381: error(s) in array DML
                                for (int i = 1; i < e.Errors.Count; i++) {
                                    tab.Rows[e.Errors[i].ArrayBindIndex].RowError = e.Errors[i].Message;
                                    try {
                                        string details = "Entity " + tab.TableName + " Values:\r\n";

                                        foreach (DataColumn col in tab.Columns) {
                                            object val = tab.Rows[e.Errors[i].ArrayBindIndex][col];
                                            details += col.ColumnName + "='" + Convert.ToString(val, System.Globalization.CultureInfo.InvariantCulture).Replace("'", "''") + "'\r\n";
                                        }
                                        EventLogger.WriteError(e.Errors[i].Message + Environment.NewLine + "Details:" + Environment.NewLine + details);
                                    } catch {
                                    }
                                }
                                tran.Commit();
                                return;

                            case 942:  // ORA-00942: connectivity problems in Oracle RAC (#140942)
                            case 3114: // ORA-03114: not connected to ORACLE (#144672)
                                try {
                                    if (tran != null) {
                                        tran.Rollback();
                                    }
                                } catch {
                                } finally {

                                    try {
                                        con.Close();
                                        con.Dispose();
                                    } catch {
                                    }
                                }
                                throw;

                            default:
                                try {
                                    if (tran != null) {
                                        tran.Rollback();
                                    }
                                } catch {
                                }
                                throw;
                        }
                    }
                }
                tran.Commit();
            } finally {
                if (tran != null) {
                    tran.Dispose();
                }
            }
        }
    }
}
