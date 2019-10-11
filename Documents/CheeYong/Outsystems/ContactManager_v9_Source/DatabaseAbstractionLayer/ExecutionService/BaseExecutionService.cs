/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.Extensibility.Data.ExecutionService {
    /// <summary>
    ///Base implementation of a database service that handles the execution of statements made while connected to a database.
    /// </summary>
    public abstract class BaseExecutionService : IExecutionService {

        private const int TimeoutErrorCode = -2;
        
        /// <summary>
        /// Gets the prefix used to qualify command parameters (e.g. @)
        /// </summary>
        public abstract string ParameterPrefix { get; }

        /// <summary>
        /// Method called by the consumers of this service when an execution exception occurs.
        /// It is used to handle edge cases where cleaning up is required.
        /// NOTE: This method should handle the exception and not rethrow it.
        /// </summary>
        /// <param name="e">Exception thrown during execution.</param>
        /// <param name="cmd">Command that was running when the exception was raised.</param>
        /// <param name="reader">Reader created from executing the command, if applicable.</param>
        /// <param name="conn">Connection that creates the transaction where the exception occurred, if applicable.</param>
        /// <param name="trans">Transaction where the exception was produced, if applicable.</param>
        /// <param name="manager">Transaction manager associated with this command, if applicable.</param>
        public virtual void OnExecuteException(DbException e, IDbCommand cmd, IDataReader reader, IDbConnection conn, IDbTransaction trans, ITransactionManager manager) {
            if (IsConnectionException(e)) {
                // #70408, #112391
                // When network connection is lost and later recovered to the database all previous connections in the pool
                // become unusable. Connection opening works as expected, but once used the following exception will occur:
                // - TCP Provider, error: 0 - An existing connection was forcibly closed by the remote host.
                // There is no viable workaround to this problem (except for disabling connection pooling)
                // http://social.msdn.microsoft.com/Forums/en-US/sqlnetfx/thread/4895d56b-716f-4f82-860f-0aa161d327cc/	
                // This will affect ALL connections in the connection pool.

                // Our workaround is to release all connections in the pool when the error happens. Although the current call
                // will fail, subsequent errors like this will be avoided since new connections will have to be opened.
                DatabaseServices.TransactionService.ReleasePooledConnections(e.Message);

		        // Close reader if open
                if (reader != null && !reader.IsClosed) {
                    reader.Close();
                }

                if (manager != null && trans != null) {
                    manager.AbortTransaction(trans);
                }
            }
        }
        
        /// <summary>
        /// Checks if a type is String or AnsiString.
        /// </summary>
        /// <param name="dbType">Database type.</param>
        /// <returns>True if it is String or AnsiString, False otherwise.</returns>
		protected bool IsStringOrAnsiStringDbType(DbType dbType) {
			return dbType == DbType.AnsiString || dbType == DbType.String;
		}
		
        /// <summary>
        /// Sets a parameter with a database type.
        /// </summary>
        /// <param name="dbType">Database Type.</param>
        /// <param name="param">Parameter to change.</param>
		protected virtual void SetCorrectDBType(DbType dbType, IDbDataParameter param) {
			param.DbType = dbType;
		}

        /// <summary>
        /// Set a parameter with a value.
        /// </summary>
        /// <param name="param">Parameter to set the value with.</param>
        /// <param name="dbType">Database type of the parameter.</param>
        /// <param name="paramValue">Value to set.</param>
        public virtual void SetParameterValue(IDbDataParameter param, DbType dbType, object paramValue) {
			if (paramValue == null) {
				param.Value = DBNull.Value;
			} else {
				param.Value = paramValue;
			}
		}

        /// <summary>
        /// Checks if an exception was raised due to a connection error.
        /// </summary>
        /// <param name="e">Exception raised.</param>
        /// <returns>True if the exception was due to a connection problem, False otherwise.</returns>
		public abstract bool IsConnectionException(DbException e);

        /// <summary>
        /// Gets the <see cref="IDatabaseServices"/> instance associated with this service.
        /// </summary>
        public virtual IDatabaseServices DatabaseServices { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseExecutionService"/> class.
        /// </summary>
        /// <param name="databaseServices">The database services to be used with this execution service.</param>
		public BaseExecutionService(IDatabaseServices databaseServices) {
			DatabaseServices = databaseServices;
		}

        /// <summary>
        /// Gets the database configuration used by this service.
        /// </summary>
        /// <value>The database configuration.</value>
		public IRuntimeDatabaseConfiguration DatabaseConfiguration { get { return DatabaseServices.DatabaseConfiguration; } }

        /// <summary>
        /// Executes a command and returns the number of affected rows.
        /// This implementation does not use the <code>isApplication</code> flag, and logs exceptions.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>The number of rows affected.</returns>
		public virtual int ExecuteNonQuery(IDbCommand cmd) {
			try {
				return cmd.ExecuteNonQuery();
			} catch (DbException e) {
                OSTrace.Error("Error executing ExecuteNonQuery (" + e.Message + ") with statement:" + Environment.NewLine + cmd.CommandText);
                throw;
			}
		}
        
        /// <summary>
        /// Executes a command and returns the resulting <see cref="IDataReader"/>.
        /// This implementation logs exceptions.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>A reader with the results of executing the query command.</returns>
        public virtual IDataReader ExecuteReader(IDbCommand cmd) {
			try {
				return cmd.ExecuteReader();
			} catch (DbException e) {
                OSTrace.Error("Error executing ExecuteReader (" + e.Message + ") with statement:" + Environment.NewLine + cmd.CommandText);
                throw;
            }
		}

        /// <summary>
        /// Executes a command and returns the value of the first column of the first row in the resultset returned by the query.
        /// This implementation logs exceptions.
        /// </summary>
        /// <param name="cmd">The command to execute.</param>
        /// <returns>An object with the resulting first row and first column of the query defined in the query command.</returns>
		public virtual object ExecuteScalar(IDbCommand cmd) {
			try {
				return cmd.ExecuteScalar();
			} catch (DbException e) {
                OSTrace.Error("Error executing ExecuteScalar (" + e.Message + ") with statement:" + Environment.NewLine + cmd.CommandText);
                throw;
            }
		}
        
        /// <summary>
        /// Sets the parameter direction (Input, Output, InputOutput or ReturnValue).
        /// </summary>
        /// <param name="param">Parameter to set the direction.</param>
        /// <param name="direction">Direction to be set.</param>
		public virtual void SetParameterDirection(IDbDataParameter param, ParameterDirection direction) {
			param.Direction = direction;
		}

        /// <summary>
        /// Creates an empty SQL command to be executed in a connection.
        /// </summary>
        /// <param name="connection">The connection to create the command.</param>
        /// <returns>A an empty command.</returns>
        protected virtual IDbCommand CreateCommand(IDbConnection connection) {
            return connection.CreateCommand();
        }

        /// <summary>
        /// Creates an SQL command to be executed in a transaction.
        /// This implementation replaces <code>\r\n</code> by <code>\n</code>.
        /// </summary>
        /// <param name="trans">The transaction to execute the command.</param>
        /// <param name="sql">The SQL statement to be executed.</param>
        /// <returns>An SQL command.</returns>
		public virtual IDbCommand CreateCommand(IDbTransaction trans, string sql) {
			IDbCommand cmd;
            cmd = CreateCommand(trans.Connection);
			cmd.Transaction = trans;
			cmd.CommandText = sql.Replace("\r\n", "\n");
			return cmd;
		}

        /// <summary>
        /// Creates a transactionless command associated with the connection.
        /// This implementation does not transform the SQL statement.
        /// </summary>
        /// <param name="connection">The connection where the command is going to be executed.</param>
        /// <param name="sql">The SQL statement to be executed.</param>
        /// <returns>An SQL command.</returns>
		public virtual IDbCommand CreateCommand(IDbConnection connection, string sql) {
			IDbCommand cmd = CreateCommand(connection);
            cmd.CommandText = sql.Replace("\r\n", "\n");
			return cmd;
		}

        /// <summary>
        /// Creates and associates a new parameter to a command.
        /// If the command already has a parameter with the same name, that parameter is returned
        /// and the command parameters are not changed.
        /// </summary>
        /// <param name="cmd">The command to associate the parameter.</param>
        /// <param name="name">Parameter name.</param>
        /// <param name="dbType">Parameter type.</param>
        /// <param name="paramValue">Parameter value.</param>
        /// <returns>The parameter already associated to the command.</returns>
        public virtual IDbDataParameter CreateParameter(IDbCommand cmd, string name, DbType dbType, object paramValue) {
            IDbDataParameter param;
            if (cmd.Parameters.Contains(name)) {
                param = (IDbDataParameter)cmd.Parameters[name];
            } else {
                param = cmd.CreateParameter();
                param.ParameterName = name;
                cmd.Parameters.Add(param);
            }

            SetCorrectDBType(dbType, param);
            SetParameterValue(param, dbType, paramValue);

            return param;
        }

        /// <summary>
        /// Converts a type to its equivalent type in the database.
        /// This implementation matches:<para>string to DbType.String;</para><para>Int32 to DbType.Int32;</para><para>DateTime to DbType.DateTime;</para>
        /// <para>decimal to DbType.Decimal;</para><para>bool to DbType.Boolean;</para><para>otherwise throws a NotSupportedException.</para>
        /// </summary>
        /// <param name="type">The type to be converted.</param>
        /// <returns>A supported type by the database.</returns>
        /// <exception cref="System.NotSupportedException">When no suitable type is found.</exception>
		public virtual DbType ConvertToDbType(Type type) {
			if (type == typeof(string)) {
				return DbType.String;
			} else if (type == typeof(Int32)) {
				return DbType.Int32;
			} else if (type == typeof(DateTime)) {
				return DbType.DateTime;
			} else if (type == typeof(decimal)) {
				return DbType.Decimal;
			} else if (type == typeof(bool)) {
				return DbType.Boolean;
            } else if(type == typeof(Int64)) {
                return DbType.Int64;
			} else {
				throw new NotSupportedException("Unable to convert " + type.ToString() + " to DbType");
			}
		}

        /// <summary>
        /// Converts a type to its equivalent type in the target framework.
        /// </summary>
        /// <param name="type">The type to be converted.</param>
        /// <param name="providerType">The name of the type used by the provider.</param>
        /// <returns>A supported type by the database.</returns>
        /// <exception cref="System.NotSupportedException">When no suitable type is found.</exception>
        public virtual DbType ConvertToDbType(DBDataType type, string providerType) {
            if (DBDataType.TEXT == type)
                return DbType.String;
            if (DBDataType.INTEGER == type)
                return DbType.Int32;
            if (DBDataType.LONGINTEGER == type)
                return DbType.Int64;
            if (DBDataType.DECIMAL == type)
                return DbType.Decimal;
            if (DBDataType.DATE_TIME == type)
                return DbType.DateTime;
            if (DBDataType.DATE == type)
                return DbType.Date;
            if (DBDataType.TIME == type)
                return DbType.Time;
            if (DBDataType.BOOLEAN == type)
                return DbType.Boolean;
            if (DBDataType.BINARY_DATA == type)
                return DbType.Binary;

            throw new NotSupportedException("Unable to convert " + type.ToString() + " to DbType");
        }

        /// <summary>
        /// Checks if an exception was raised due to a timeout.
        /// This implementation checks if the exception is a <see cref="DbException"/>, and its error code is -2.
        /// </summary>
        /// <param name="exception">Exception raised.</param>
        /// <returns>True if the exception was due to a timeout, False otherwise.</returns>
		public virtual bool IsTimeoutException(Exception exception) {
			DbException dbException = exception as DbException;
			return dbException != null && dbException.ErrorCode == TimeoutErrorCode;
		}
        
        /// <summary>
        /// Transforms a database value to the equivalent runtime value.
        /// This implementation returns the value without changing it.
        /// </summary>
        /// <param name="value">Value to transform.</param>
        /// <returns>The transformed object.</returns>
        public virtual object TransformDatabaseToRuntimeValue(object value) { return value; }

        /// <summary>
        /// Transforms a runtime value to the equivalent database value.
        /// This implementation returns the value without changing it.
        /// </summary>
        /// <param name="dbType">Database type.</param>
        /// <param name="value">Value to transform.</param>
        /// <returns>The transformed object.</returns>
        public virtual object TransformRuntimeToDatabaseValue(DbType dbType, object value) {
            
            if (value != null && value.Equals(String.Empty)) {

                var numericTypes = new DbType[] {
                DbType.Int16, DbType.Int32, DbType.Int64,
                DbType.UInt16, DbType.UInt32, DbType.UInt64,
                DbType.Byte, DbType.SByte };

                var decimalTypes = new DbType[] {
                DbType.Currency, DbType.Decimal,
                DbType.Single, DbType.Double,
                DbType.VarNumeric };

                if (decimalTypes.Contains(dbType)) {
                    return new Decimal(0);
                }

                if (numericTypes.Contains(dbType)) {
                    return 0;
                }
            }

            return value;
        }

        
        /// <summary>
        /// Bulk inserts data into the database.
        /// In this base implementation, the data is inserted individually.
        /// </summary>
        /// <param name="datatable">A datatable with all information to transfer.</param>
        public virtual void BulkInsert(DataTable datatable) {
            using (var connection = DatabaseServices.TransactionService.CreateConnection()) {
                using (IDbCommand cmd = connection.CreateCommand()) {
                    string columns = "";
                    string parameters = "";
                    string prepend = "";
                    foreach (DataColumn col in datatable.Columns) {
                        columns += prepend + DatabaseServices.DMLService.Identifiers.EscapeIdentifier(col.ColumnName);
                        parameters += prepend +  DatabaseServices.ExecutionService.ParameterPrefix + col.ColumnName;
                        prepend = ",";

                        DatabaseServices.ExecutionService.CreateParameter(cmd, col.ColumnName, ConvertToDbType(col.DataType), null);
                    }
                    cmd.CommandText = "INSERT INTO " + datatable.TableName + " (" + columns + ") VALUES (" + parameters + ")";

                    foreach (DataRow row in datatable.Rows) {
                        try {
                            row.RowError = "";
                            if (row.RowState == DataRowState.Added) {
                                foreach (DataColumn col in datatable.Columns) {
                                    ((IDataParameter)cmd.Parameters[col.ColumnName]).Value = row[col];
                                }
                                cmd.ExecuteNonQuery();
                            }
                        } catch (Exception e) {
                            OSTrace.Error("Exception writing data to table " + datatable.TableName + " : " + e.Message);
                            row.RowError = e.Message;
                            try {
                                row.RowError += "\r\nValues:\r\n";
                                foreach (DataColumn col in datatable.Columns) {
                                    row.RowError += col.ColumnName + "='" + row[col].ToString().Replace("'", "''") + "'\r\n";
                                }
                            } catch (Exception) {                                
                            }
                        }
                    }
                }
            }
        }
    }
}
