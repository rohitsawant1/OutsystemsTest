/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;
using OutSystems.Internal.Db;
using OutSystems.RuntimeCommon.ObfuscationProperties;

namespace OutSystems.HubEdition.RuntimePlatform {

    [DoNotObfuscate]
    internal class ProcessDeletion {
    
        private int? processId, bulkSizeLimit, processDefinitionId;
        private DateTime? olderThan;

        [DoNotObfuscate]
        internal ProcessDeletion(int processId) {
            this.processId = processId;
        }

        internal ProcessDeletion(DateTime olderThan) : this(olderThan, null, null) { }

        internal ProcessDeletion(DateTime olderThan, int? bulkSizeLimit) : this(olderThan, bulkSizeLimit, null) { }

        [DoNotObfuscate]
        internal ProcessDeletion(DateTime olderThan, int? bulkSizeLimit, int? processDefinitionId) {
            this.olderThan = olderThan;

            if (bulkSizeLimit.HasValue) {
                if (bulkSizeLimit > 0) {
                    this.bulkSizeLimit = bulkSizeLimit;
                } else if (bulkSizeLimit < 0) {
                    throw new OutSystems.RuntimePublic.Processes.ProcessDeletion.InvalidBulkSizeLimitException();
                }
            }

            this.processDefinitionId = (!processDefinitionId.HasValue || (processDefinitionId == 0))? null: processDefinitionId;            
        }

        /// <summary>
        /// Construct the select that gather which are the actual processes that will be deleted
        /// </summary>
        private string ProcessesToDeleteQuery(IDatabaseServices databaseServices, bool isDeletingTopProcesses) {
                string processesFilter;

                if (IsBulkDeletion) {
                    // Construct the select to gather the list of 1st level (Processes that have no parent process) ProcessIds to delete
                    string topLevelProcessesQuery;

                    if (bulkSizeLimit.HasValue) {
                        var maxRecordsPlaceholders = databaseServices.DMLService.Queries.SQLPlaceholderValuesForMaxRecords("@bulkSizeLimit");
                        topLevelProcessesQuery =
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.BeforeStatement) +
                            " SELECT " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.AfterSelectKeyword) +
                            " p.ID " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.BeforeFromKeyword) +
                            " FROM " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.AfterFromKeyword) +
                            " OSSYS_BPM_PROCESS p INNER JOIN OSSYS_BPM_PROCESS_STATUS status ON p.STATUS_ID = status.ID " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.BeforeWhereKeyword) +
                            " WHERE " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.AfterWhereKeyword) +
                            " status.IS_TERMINAL = 1 AND p.PARENT_PROCESS_ID IS NULL AND p.LAST_MODIFIED < @olderThan " +
                            (processDefinitionId.HasValue ? " AND p.PROCESS_DEF_ID = @processDefinitionId" : "") +
                            " ORDER BY LAST_MODIFIED " +
                            maxRecordsPlaceholders.GetPlaceholderValue(SelectPlaceholder.AfterStatement);

                        // Due to MySQL limitations using IN with subqueries we have to use an outer query in the statement
                        topLevelProcessesQuery = String.Format("SELECT * FROM ({0}) TopProcIds", topLevelProcessesQuery);
                    } else {
                        topLevelProcessesQuery = @"select p.ID
		                    from OSSYS_BPM_PROCESS p inner join OSSYS_BPM_PROCESS_STATUS status on p.STATUS_ID = status.ID 
		                    where status.IS_TERMINAL = 1 and p.PARENT_PROCESS_ID is null and p.LAST_MODIFIED < @olderThan";

                        if (processDefinitionId.HasValue) {
                            topLevelProcessesQuery += " and p.PROCESS_DEF_ID = @processDefinitionId";
                        }
                    }

                    processesFilter = String.Format("{0} IN ({1})", isDeletingTopProcesses ? "ID" : "TOP_PROCESS_ID", topLevelProcessesQuery);
                } else {
                    processesFilter = String.Format("{0} = @processId", isDeletingTopProcesses ? "ID" : "TOP_PROCESS_ID");
                }
                // Due to MySQL limitations using IN with subqueries we have to use an outer query in the statement
                return String.Format("SELECT ProcId FROM (SELECT ID as ProcId FROM OSSYS_BPM_PROCESS WHERE {0}) ProcIds", processesFilter);
        }

        private bool IsBulkDeletion { get { return !processId.HasValue; } }

        private Command CreateSQLCommand(Transaction trans, string sqlFormat, params string[] sqlFormatParams) {
            Command cmd = trans.CreateCommand(String.Format(sqlFormat, sqlFormatParams));
            
            try {
                if (IsBulkDeletion) {
                    cmd.CreateParameter("@olderThan", DbType.DateTime, olderThan);

                    if (processDefinitionId.HasValue) {
                        cmd.CreateParameter("@processDefinitionId", DbType.Int32, processDefinitionId);
                    }

                    if (bulkSizeLimit.HasValue) {
                        cmd.CreateParameter("@bulkSizeLimit", DbType.Int32, bulkSizeLimit);
                    }
                } else {
                    cmd.CreateParameter("@processId", DbType.Int32, processId.Value);
                }

                return cmd;
            } catch {
                cmd.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Deletes all the logged information of the instances of Processes that fit the criteria specified in the constructor.
        /// The information that is deleted is all the logging of: process instances, activities instances, input parameters values, output parameters values, processes instances executed within other process instances, etc.
        /// </summary>
        /// <param name="trans">Transaction to use</param>
        /// <returns>True if the operation deleted all the processes that fit the criteria.</returns>
        [DoNotObfuscate]
        internal bool DeleteProcesses(Transaction trans) {
            if (!IsBulkDeletion) {
                string sql = @"select PARENT_PROCESS_ID, IS_TERMINAL
                    from OSSYS_BPM_PROCESS p inner join OSSYS_BPM_PROCESS_STATUS ps on p.STATUS_ID = ps.ID
                    where p.ID = @processId";

                using (Command cmd = CreateSQLCommand(trans, sql)) {
                    using (IDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            if (reader.SafeGet<int>("PARENT_PROCESS_ID") != 0) {
                                throw new OutSystems.RuntimePublic.Processes.ProcessDeletion.ProcessNotTopLevelException();
                            }

                            if (!reader.SafeGet<bool>("IS_TERMINAL")) {
                                throw new OutSystems.RuntimePublic.Processes.ProcessDeletion.InvalidProcessStatusException();
                            }
                        } else {
                            throw new OutSystems.RuntimePublic.Processes.ProcessDeletion.ProcessNotFoundException();
                        }
                    }
                }
            }

            string processesToDeleteSQL = ProcessesToDeleteQuery(trans.DatabaseServices, /*isDeletingTopProcesses*/false);
            // remove circular reference in top process id
            using (Command cmd = CreateSQLCommand(trans, "UPDATE OSSYS_BPM_PROCESS SET PARENT_ACTIVITY_ID = NULL WHERE TOP_PROCESS_ID IN ({0})", processesToDeleteSQL)) {
                cmd.ExecuteNonQuery();
            }
            
            // Remove sub processes
            string subProcessesSQL =
                string.Format(@"FROM OSSYS_BPM_PROCESS 
                                WHERE ID <> TOP_PROCESS_ID 
                                  AND ID NOT IN (
                                    SELECT PARENTID 
                                    FROM (
                                        SELECT DISTINCT PARENT_PROCESS_ID AS PARENTID 
                                        FROM OSSYS_BPM_PROCESS 
                                        WHERE PARENT_PROCESS_ID IS NOT NULL
                                    ) PARENTPROCS
                                  ) AND TOP_PROCESS_ID IN ({0})", processesToDeleteSQL);
            bool moreSubProcessesToDelete = true;
            while (moreSubProcessesToDelete) {
                using (Command cmd = CreateSQLCommand(trans, "SELECT COUNT(*) " + subProcessesSQL)) {
                    moreSubProcessesToDelete = DataReaderUtils.SafeGet<bool>(cmd.ExecuteScalar());
                }
                if (moreSubProcessesToDelete) {
                    using (Command cmd = CreateSQLCommand(trans, "DELETE " + subProcessesSQL)) {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            // Remove circular references in TOP_PROCESS_ID
            using (Command cmd = CreateSQLCommand(trans, "UPDATE OSSYS_BPM_PROCESS SET TOP_PROCESS_ID = NULL WHERE ID IN ({0})", processesToDeleteSQL)) {
                cmd.ExecuteNonQuery();
            }

            // Delete top processes
            processesToDeleteSQL = ProcessesToDeleteQuery(trans.DatabaseServices, /*isDeletingTopProcesses*/true);
            using (Command cmd = CreateSQLCommand(trans, "DELETE FROM OSSYS_BPM_PROCESS WHERE ID IN ({0})", processesToDeleteSQL)) {
                int deleted = cmd.ExecuteNonQuery();
                AppInfo info = AppInfo.GetAppInfo();
                if (info != null) {
                    GenericExtendedActions.LogMessage(info.OsContext, 
                        IsBulkDeletion ? 
                            string.Format("Bulk deleted {0} top processes older than {1} (ProcessDefinitionId = {2})", deleted, olderThan.Value.ToString(FormatInfo.GetOutputDateFormatString()), processDefinitionId.HasValue ? processDefinitionId.ToString() : "NULL") :
                            string.Format("Deleted top-process #{0}", processId), 
                        "BPT_API");
                }
            }

            if (IsBulkDeletion) {
                return HasProcessesToDelete(trans);
            }
            return false;
        }

        [DoNotObfuscate]
        internal bool HasProcessesToDelete(Transaction trans) {
            string processesToDeleteSQL = ProcessesToDeleteQuery(trans.DatabaseServices, true);
            using (Command cmd = CreateSQLCommand(trans, processesToDeleteSQL)) {
                using (IDataReader reader = cmd.ExecuteReader()) {
                    return reader.Read();
                }
            }
        }
    }
}
