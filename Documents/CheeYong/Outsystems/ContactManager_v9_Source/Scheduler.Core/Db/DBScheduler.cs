/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Runtime.CompilerServices;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;
using OutSystems.HubEdition.Extensibility.Data.Platform.QueryProvider;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Processes;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.ObfuscationProperties;

namespace OutSystems.Scheduler.Core {
    [DoNotObfuscateType]
    public class DBScheduler : BaseQueryProvider<DBScheduler, DBScheduler.Qualifier> {

        public class Qualifier : IQueryProviderQualifier {
            public IDatabaseProvider DatabaseProvider {
                get { return DatabaseAccess.ForSystemDatabase.DatabaseServices.DatabaseConfiguration.DatabaseProvider; }
            }
            public Type[] ProviderSpecificTypes {
                get { return new[] { typeof(DBSchedulerOracle), typeof(DBSchedulerMySQL) }; }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual IDataReader GetCyclicJobsForFrontend(Transaction trans, string frontendName) {
            string sql =
                @"WITH CJ AS (
                    SELECT ID, META_CYCLIC_JOB_ID, NEXT_RUN, SCHEDULE, LAST_RUN, IS_RUNNING_SINCE, LAST_DURATION, TENANT_ID
                    FROM OSSYS_CYCLIC_JOB
                    WHERE NEXT_RUN <= GETDATE()
                ), CJSHARED AS (
                    SELECT META_CYCLIC_JOB_ID, NEXT_RUN, SCHEDULE, LAST_RUN, IS_RUNNING_SINCE, LAST_DURATION
                    FROM OSSYS_CYCLIC_JOB_SHARED
                    WHERE NEXT_RUN <= GETDATE()
                )
                SELECT
                    COALESCE(CJ.ID, CJSHARED.META_CYCLIC_JOB_ID) ID,
                    META.SS_KEY,
                    META.IS_SHARED,
                    META.NAME META_CYCLIC_JOB_NAME,
                    ESPACE.NAME ESPACE_NAME,
                    ESPACE.ID ESPACE_ID,
                    ESPACE.SS_KEY ESPACE_KEY,
                    ESPACE.IS_MULTITENANT,
                    (CASE WHEN ESPACE.USER_PROVIDER_KEY = '' OR ESPACE.USER_PROVIDER_KEY = ' ' THEN ESPACE.SS_KEY ELSE ESPACE.USER_PROVIDER_KEY END) USER_PROVIDER_KEY,
                    TENANT.NAME TENANT_NAME,
                    TENANT.ID TENANT_ID,
                    COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) NEXT_RUN,
                    COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) SCHEDULE,
                    COALESCE(CJ.LAST_RUN, CJSHARED.LAST_RUN) LAST_RUN,
                    (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END) REAL_TIMEOUT,
                    (CASE COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) WHEN '" + Constants.TimerScheduleWhenPublished + @"' THEN 1 ELSE META.PRIORITY END) PRIORITY
                FROM
                    OSSYS_META_CYCLIC_JOB META
                    INNER JOIN OSSYS_ESPACE ESPACE ON ESPACE.ID = META.ESPACE_ID AND ESPACE.IS_ACTIVE = 1 AND META.IS_ACTIVE = 1
                    INNER JOIN OSSYS_MODULEFRONTEND ON OSSYS_MODULEFRONTEND.MODULEKEY = ESPACE.SS_KEY
                    LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = META.ESPACE_ID
                    LEFT JOIN CJ ON META.ID = CJ.META_CYCLIC_JOB_ID AND META.IS_SHARED = 0
                    LEFT JOIN OSSYS_ESPACE_TENANT ET ON ET.ESPACE_ID = META.ESPACE_ID AND ET.TENANT_ID = CJ.TENANT_ID
                    LEFT JOIN OSSYS_TENANT TENANT ON TENANT.ID = ET.TENANT_ID AND TENANT.IS_ACTIVE = 1 
                    LEFT JOIN CJSHARED ON META.ID = CJSHARED.META_CYCLIC_JOB_ID AND META.IS_SHARED = 1
                WHERE 
                    (@FRONTENDNAME = " + trans.DatabaseServices.DMLService.DefaultValues.Text + @" OR OSSYS_MODULEFRONTEND.FRONTENDNAME = @FRONTENDNAME)
                    AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0)
                    AND (CJ.ID IS NULL OR TENANT.ID IS NOT NULL)
                    AND (COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE) IS NULL OR GETDATE() > " +
                    trans.DatabaseServices.DMLService.Functions.AddMinutes("COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE)", "1.2 * (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END)") + @")
                    AND COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) <= GETDATE()
                ORDER BY
                    META.PRIORITY ASC,
                    COALESCE(CJ.LAST_DURATION, CJSHARED.LAST_DURATION) ASC,
                    COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) ASC";
            var cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@FRONTENDNAME", DbType.String, frontendName ?? trans.DatabaseServices.DMLService.DefaultValues.Text);
            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual IDataReader GetCyclicJobsForApplication(Transaction trans, ObjectKey applicationKey) {
            string sql =
                @"WITH CJ AS (
                    SELECT ID, META_CYCLIC_JOB_ID, NEXT_RUN, SCHEDULE, LAST_RUN, IS_RUNNING_SINCE, LAST_DURATION, TENANT_ID
                    FROM OSSYS_CYCLIC_JOB
                    WHERE NEXT_RUN <= GETDATE()
                ), CJSHARED AS (
                    SELECT META_CYCLIC_JOB_ID, NEXT_RUN, SCHEDULE, LAST_RUN, IS_RUNNING_SINCE, LAST_DURATION
                    FROM OSSYS_CYCLIC_JOB_SHARED
                    WHERE NEXT_RUN <= GETDATE()
                )
                SELECT
                    COALESCE(CJ.ID, CJSHARED.META_CYCLIC_JOB_ID) ID,
                    META.SS_KEY,
                    META.IS_SHARED,
                    META.NAME META_CYCLIC_JOB_NAME,
                    ESPACE.NAME ESPACE_NAME,
                    ESPACE.ID ESPACE_ID,
                    ESPACE.SS_KEY ESPACE_KEY,
                    ESPACE.IS_MULTITENANT,
                    (CASE WHEN ESPACE.USER_PROVIDER_KEY = '' OR ESPACE.USER_PROVIDER_KEY = ' ' THEN ESPACE.SS_KEY ELSE ESPACE.USER_PROVIDER_KEY END) USER_PROVIDER_KEY,
                    TENANT.NAME TENANT_NAME,
                    TENANT.ID TENANT_ID,
                    COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) NEXT_RUN,
                    COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) SCHEDULE,
                    COALESCE(CJ.LAST_RUN, CJSHARED.LAST_RUN) LAST_RUN,
                    (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END) REAL_TIMEOUT,
                    (CASE COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) WHEN '" + Constants.TimerScheduleWhenPublished + @"' THEN 1 ELSE META.PRIORITY END) PRIORITY
                FROM
                    OSSYS_META_CYCLIC_JOB META
                    INNER JOIN OSSYS_ESPACE ESPACE ON ESPACE.ID = META.ESPACE_ID AND ESPACE.IS_ACTIVE = 1 AND META.IS_ACTIVE = 1
                    INNER JOIN OSSYS_MODULE ON ESPACE.ID = OSSYS_MODULE.ESPACE_ID
                    INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                    INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                    LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = META.ESPACE_ID
                    LEFT JOIN CJ ON META.ID = CJ.META_CYCLIC_JOB_ID AND META.IS_SHARED = 0
                    LEFT JOIN OSSYS_ESPACE_TENANT ET ON ET.ESPACE_ID = META.ESPACE_ID AND ET.TENANT_ID = CJ.TENANT_ID
                    LEFT JOIN OSSYS_TENANT TENANT ON TENANT.ID = ET.TENANT_ID AND TENANT.IS_ACTIVE = 1 
                    LEFT JOIN CJSHARED ON META.ID = CJSHARED.META_CYCLIC_JOB_ID AND META.IS_SHARED = 1
                WHERE
                    OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + @" = @APPLICATIONKEY
                    AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0)
                    AND (CJ.ID IS NULL OR TENANT.ID IS NOT NULL)
                    AND (COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE) IS NULL OR GETDATE() > " +
                    trans.DatabaseServices.DMLService.Functions.AddMinutes("COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE)", "1.2 * (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END)") + @")
                    AND COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) <= GETDATE()
                ORDER BY
                    META.PRIORITY ASC,
                    COALESCE(CJ.LAST_DURATION, CJSHARED.LAST_DURATION) ASC,
                    COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) ASC";
            var cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [TestSyntaxValues(Values = new[] { TestSyntaxValues.AUTO, TestSyntaxValues.AUTO, "false" },
                          Values2 = new[] { TestSyntaxValues.AUTO, TestSyntaxValues.AUTO, "true" })]
        public IDataReader GetCyclicJobForUpdate(Transaction trans, int id, bool isShared) {
            if (isShared) {
                return GetJobForUpdate(trans, id, "OSSYS_CYCLIC_JOB_SHARED", "META_CYCLIC_JOB_ID", "META_CYCLIC_JOB_ID, NEXT_RUN, IS_RUNNING_SINCE, IS_RUNNING_BY");
            } else {
                return GetJobForUpdate(trans, id, "OSSYS_CYCLIC_JOB", "ID", "ID, NEXT_RUN, IS_RUNNING_SINCE, IS_RUNNING_BY");
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IDataReader GetActivityJobForUpdate(Transaction trans, int id) {
            return GetJobForUpdate(trans, id, "OSSYS_BPM_ACTIVITY", "ID", "ID, NEXT_RUN, IS_RUNNING_SINCE, IS_RUNNING_AT");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected virtual IDataReader GetJobForUpdate(Transaction trans, int id, string table, string idAttribute, string fields) {
            var tableSource = trans.DatabaseServices.ObjectFactory.CreateTableSourceInfo(table);
            var placeholders = trans.DatabaseServices.DMLService.GetEntityActions(tableSource).SQLPlaceholderValuesForGetForUpdate();
            string sql = placeholders.GetPlaceholderValue(SelectPlaceholder.BeforeStatement) +
                         " SELECT " + placeholders.GetPlaceholderValue(SelectPlaceholder.AfterSelectKeyword) +
                         " " + fields + " " +
                         placeholders.GetPlaceholderValue(SelectPlaceholder.BeforeFromKeyword) + " FROM " +
                         placeholders.GetPlaceholderValue(SelectPlaceholder.AfterFromKeyword, true, false) + table +
                         placeholders.GetPlaceholderValue(SelectPlaceholder.BeforeWhereKeyword, false, true) + " WHERE " +
                         placeholders.GetPlaceholderValue(SelectPlaceholder.AfterWhereKeyword) +
                         idAttribute + " = " + id + " " +
                         placeholders.GetPlaceholderValue(SelectPlaceholder.AfterStatement);
            Command cmd = trans.CreateCommand(sql);
            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [TestSyntaxValues(Values = new[] { TestSyntaxValues.AUTO, TestSyntaxValues.AUTO, TestSyntaxValues.AUTO, "2.0", "20000" })]
        public void RequeueEmail(Transaction trans, int id, string errorId, decimal backoffConstant, int retryBaseSec) {
            string errorCountColumn = trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("ERROR_COUNT");
            string sql = "UPDATE OSSYS_EMAIL_STATUS SET IS_RUNNING_SINCE=NULL, IS_RUNNING_AT=NULL " +
                ", NEXT_RUN = " + DBRuntimePlatform.Instance.GetNextRunErrorBackoffStatement(trans.DatabaseServices.DMLService.Functions, errorCountColumn, "@BACKOFF", "@RETRYBASESEC") +
                ", " + errorCountColumn + " = " + errorCountColumn + " + 1" +
                ", LAST_ERROR_ID = @ERRORID " +
                "WHERE ID=@ID";

            Command cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.CreateParameter("@BACKOFF", DbType.Decimal, backoffConstant);
            cmd.CreateParameter("@RETRYBASESEC", DbType.Int32, retryBaseSec);
            cmd.CreateParameter("@ERRORID", DbType.String, errorId);

            cmd.ExecuteNonQuery();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MarkEmailAsSent(Transaction trans, int id) {
            Command cmd = trans.CreateCommand(
                "UPDATE OSSYS_EMAIL_STATUS SET IS_RUNNING_SINCE=NULL, IS_RUNNING_AT=NULL, NEXT_RUN = NULL, SENT = GETDATE() WHERE ID=@ID");
            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.ExecuteNonQuery();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearEmailNextRun(Transaction trans, int id) {
            Command cmd = trans.CreateCommand("UPDATE OSSYS_EMAIL_STATUS SET IS_RUNNING_SINCE=NULL, IS_RUNNING_AT=NULL, NEXT_RUN = NULL WHERE ID=@ID");
            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.ExecuteNonQuery();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IDataReader GetCreatedAndCurrentDate(Transaction trans, int id) {
            Command cmd = trans.CreateCommand("SELECT CREATED, GETDATE() NOW FROM OSSYS_EMAIL WHERE ID=@ID");
            cmd.CreateParameter("@ID", DbType.Int32, id);

            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetEspaceIdFromEmailId(Transaction trans, int id) {
            Command cmd = trans.CreateCommand(
                "SELECT ESPACE_ID FROM OSSYS_EMAIL_DEFINITION EMAILDEF " +
                "INNER JOIN OSSYS_EMAIL EMAIL ON EMAIL.EMAIL_DEFINITION_ID = EMAILDEF.ID " +
                "WHERE EMAIL.ID=@EMAILID");
            cmd.CreateParameter("@EMAILID", DbType.Int32, id);
            return DataReaderUtils.SafeGet<int>(cmd.ExecuteScalar());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetTenantIdFromEmailId(Transaction trans, int id) {
            Command cmd = trans.CreateCommand(
                "SELECT T.ID FROM OSSYS_EMAIL_DEFINITION EMAILDEF " +
                "INNER JOIN OSSYS_EMAIL EMAIL ON EMAIL.EMAIL_DEFINITION_ID = EMAILDEF.ID " +
                "INNER JOIN OSSYS_TENANT T ON T.ESPACE_ID = EMAILDEF.ESPACE_ID " +
                "WHERE EMAIL.ID=@EMAILID");
            cmd.CreateParameter("@EMAILID", DbType.Int32, id);
            return DataReaderUtils.SafeGet<int>(cmd.ExecuteScalar());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [TestSyntaxValues(Values = new[] { TestSyntaxValues.AUTO, "0", TestSyntaxValues.AUTO },
                          Values2 = new[] { TestSyntaxValues.AUTO, "1", TestSyntaxValues.AUTO })]
        public IDataReader GetPendingActivitiesForApplication(Transaction trans, int batch, ObjectKey applicationKey) {
            string selectClause = @"OSSYS_ESPACE.NAME ESPACE_NAME, 
                            OSSYS_ESPACE.ID ESPACE_ID, 
                            OSSYS_ESPACE.SS_KEY ESPACE_KEY,
                            OSSYS_ESPACE.IS_MULTITENANT, 
                            OSSYS_TENANT.NAME TENANT_NAME, 
                            OSSYS_TENANT.ID TENANT_ID, 
                            OSSYS_BPM_ACTIVITY_DEFINITION.SS_KEY, 
                            OSSYS_BPM_ACTIVITY_DEFINITION.NAME ACTIVITY_NAME, 
                            OSSYS_BPM_ACTIVITY.ID ACTIVITY_ID, 
                            OSSYS_BPM_ACTIVITY.PROCESS_ID, 
                            OSSYS_BPM_ACTIVITY.NEXT_RUN,
                            OSSYS_BPM_ACTIVITY_DEFINITION.KIND,
                            OSSYS_BPM_ACTIVITY.STATUS_ID";
            string fromClause = @"OSSYS_BPM_ACTIVITY
                            INNER JOIN OSSYS_BPM_PROCESS ON OSSYS_BPM_PROCESS.ID = OSSYS_BPM_ACTIVITY.PROCESS_ID
                            INNER JOIN OSSYS_BPM_ACTIVITY_DEFINITION ON OSSYS_BPM_ACTIVITY_DEFINITION.ID = OSSYS_BPM_ACTIVITY.ACTIVITY_DEF_ID AND OSSYS_BPM_ACTIVITY_DEFINITION.IS_ACTIVE = 1
                            INNER JOIN OSSYS_BPM_PROCESS_DEFINITION ON OSSYS_BPM_PROCESS_DEFINITION.ID = OSSYS_BPM_ACTIVITY_DEFINITION.PROCESS_DEF_ID AND OSSYS_BPM_PROCESS_DEFINITION.IS_ACTIVE = 1 AND OSSYS_BPM_PROCESS_DEFINITION.IS_LOCKED = 0
                            INNER JOIN OSSYS_ESPACE ON OSSYS_ESPACE.ID = OSSYS_BPM_PROCESS_DEFINITION.ESPACE_ID AND OSSYS_ESPACE.IS_ACTIVE = 1 AND OSSYS_ESPACE.IS_LOCKED = 0
                            INNER JOIN OSSYS_MODULE ON OSSYS_ESPACE.ID = OSSYS_MODULE.ESPACE_ID
                            INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                            INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                            INNER JOIN OSSYS_TENANT ON OSSYS_TENANT.ID = OSSYS_BPM_PROCESS.TENANT_ID AND OSSYS_TENANT.IS_ACTIVE = 1
                            LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = OSSYS_ESPACE.ID";
            string whereClause =
                            @"OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + @" = @APPLICATION_KEY
                            AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0) 
                            AND (IS_RUNNING_SINCE IS NULL OR IS_RUNNING_SINCE = @NULLDATE)
                            AND (NEXT_RUN IS NOT NULL AND NEXT_RUN <> @NULLDATE AND NEXT_RUN <= GETDATE())
                            AND OSSYS_BPM_ACTIVITY.STATUS_ID NOT IN (" + (int)ActivityStatus.Closed + ", " + (int)ActivityStatus.Discarded + ", " + (int)ActivityStatus.Blocked + ", " + (int)ActivityStatus.Terminated + ") " +
                           "AND OSSYS_BPM_PROCESS.STATUS_ID NOT IN (" + (int)ProcessStatus.Closed + ", " + (int)ProcessStatus.Suspended + ", " + (int)ProcessStatus.Terminated + ") ";
            string orderByClause = "NEXT_RUN ASC";

            string sql = batch > 0
                ? trans.DatabaseServices.DMLService.Queries.GetMaxRecordsSQL(batch, selectClause, fromClause, whereClause, orderByClause)
                : string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3}", selectClause, fromClause, whereClause, orderByClause);

            Command cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@NULLDATE", DbType.DateTime, BuiltInFunction.NullDate());
            cmd.CreateParameter("@APPLICATION_KEY", DbType.String, applicationKey);

            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [TestSyntaxValues(Values = new[] { TestSyntaxValues.AUTO, "0", TestSyntaxValues.AUTO },
                          Values2 = new[] { TestSyntaxValues.AUTO, "1", TestSyntaxValues.AUTO })]
        public IDataReader GetPendingActivitiesForFrontend(Transaction trans, int batch, string frontendName) {
            string selectClause = @"OSSYS_ESPACE.NAME ESPACE_NAME, 
                            OSSYS_ESPACE.ID ESPACE_ID, 
                            OSSYS_ESPACE.SS_KEY ESPACE_KEY,
                            OSSYS_ESPACE.IS_MULTITENANT, 
                            OSSYS_TENANT.NAME TENANT_NAME, 
                            OSSYS_TENANT.ID TENANT_ID, 
                            OSSYS_BPM_ACTIVITY_DEFINITION.SS_KEY, 
                            OSSYS_BPM_ACTIVITY_DEFINITION.NAME ACTIVITY_NAME, 
                            OSSYS_BPM_ACTIVITY.ID ACTIVITY_ID, 
                            OSSYS_BPM_ACTIVITY.PROCESS_ID, 
                            OSSYS_BPM_ACTIVITY.NEXT_RUN,
                            OSSYS_BPM_ACTIVITY_DEFINITION.KIND,
                            OSSYS_BPM_ACTIVITY.STATUS_ID";
            string fromClause = @"OSSYS_BPM_ACTIVITY
                            INNER JOIN OSSYS_BPM_PROCESS ON OSSYS_BPM_PROCESS.ID = OSSYS_BPM_ACTIVITY.PROCESS_ID
                            INNER JOIN OSSYS_BPM_ACTIVITY_DEFINITION ON OSSYS_BPM_ACTIVITY_DEFINITION.ID = OSSYS_BPM_ACTIVITY.ACTIVITY_DEF_ID AND OSSYS_BPM_ACTIVITY_DEFINITION.IS_ACTIVE = 1
                            INNER JOIN OSSYS_BPM_PROCESS_DEFINITION ON OSSYS_BPM_PROCESS_DEFINITION.ID = OSSYS_BPM_ACTIVITY_DEFINITION.PROCESS_DEF_ID AND OSSYS_BPM_PROCESS_DEFINITION.IS_ACTIVE = 1 AND OSSYS_BPM_PROCESS_DEFINITION.IS_LOCKED = 0
                            INNER JOIN OSSYS_ESPACE ON OSSYS_ESPACE.ID = OSSYS_BPM_PROCESS_DEFINITION.ESPACE_ID AND OSSYS_ESPACE.IS_ACTIVE = 1 AND OSSYS_ESPACE.IS_LOCKED = 0
                            INNER JOIN OSSYS_MODULEFRONTEND ON OSSYS_MODULEFRONTEND.MODULEKEY = OSSYS_ESPACE.SS_KEY
                            INNER JOIN OSSYS_TENANT ON OSSYS_TENANT.ID = OSSYS_BPM_PROCESS.TENANT_ID AND OSSYS_TENANT.IS_ACTIVE = 1
                            LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = OSSYS_ESPACE.ID";
            string whereClause =
                            @"(@FRONTENDNAME = " + trans.DatabaseServices.DMLService.DefaultValues.Text + @" OR OSSYS_MODULEFRONTEND.FRONTENDNAME = @FRONTENDNAME)
                            AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0) 
                            AND (IS_RUNNING_SINCE IS NULL OR IS_RUNNING_SINCE = @NULLDATE)
                            AND (NEXT_RUN IS NOT NULL AND NEXT_RUN <> @NULLDATE AND NEXT_RUN <= GETDATE())
                            AND OSSYS_BPM_ACTIVITY.STATUS_ID NOT IN (" + (int)ActivityStatus.Closed + ", " + (int)ActivityStatus.Discarded + ", " + (int)ActivityStatus.Blocked + ", " + (int)ActivityStatus.Terminated + ") " +
                           "AND OSSYS_BPM_PROCESS.STATUS_ID NOT IN (" + (int)ProcessStatus.Closed + ", " + (int)ProcessStatus.Suspended + ", " + (int)ProcessStatus.Terminated + ") ";
            string orderByClause = "NEXT_RUN ASC";

            string sql = batch > 0
                ? trans.DatabaseServices.DMLService.Queries.GetMaxRecordsSQL(batch, selectClause, fromClause, whereClause, orderByClause)
                : string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3}", selectClause, fromClause, whereClause, orderByClause);

            Command cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@NULLDATE", DbType.DateTime, BuiltInFunction.NullDate());
            cmd.CreateParameter("@FRONTENDNAME", DbType.String, frontendName ?? string.Empty);

            return cmd.ExecuteReader();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void DeleteEmailContentIfNeeded(Transaction trans, int id) {
            Command cmd = trans.CreateCommand(
                "DELETE FROM OSSYS_EMAIL_CONTENT WHERE OSSYS_EMAIL_CONTENT.ID IN " +
                "(SELECT EMAIL.ID FROM OSSYS_EMAIL EMAIL WHERE EMAIL.ID = @ID AND EMAIL.STORE_CONTENT = 0)");
            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.ExecuteNonQuery();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void GetEmail(Transaction trans, int id, out byte[] content, out string from, out string to, out string cc, out string bcc) {
            string fromColumn = trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("FROM");
            string toColumn = trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("TO");
            Command cmd = trans.CreateCommand(
                "SELECT CONTENT, " + fromColumn + ", " + toColumn + ", CC, BCC FROM OSSYS_EMAIL_CONTENT C, OSSYS_EMAIL E WHERE C.ID=@EMAILID AND E.ID=@EMAILID");
            cmd.CreateParameter("@EMAILID", DbType.Int32, id);
            using (IDataReader reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    content = reader.GetValue(0) as byte[];
                    from = reader.GetString(1);
                    to = reader.GetString(2);
                    cc = reader.GetString(3);
                    bcc = reader.GetString(4);
                } else {
                    content = null;
                    from = null;
                    to = null;
                    cc = null;
                    bcc = null;
                }
            }
        }


        protected const string DequeueEmailsProcedureNameForFrontend = "DEQUEUE_EMAILS_FOR_FRONTEND";
        protected const string DequeueEmailsProcedureNameForApplication = "DEQUEUE_EMAILS_FOR_APP";

        protected virtual string GetDequeueEmailsParamName() {
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IDataReader DequeueEmails(Transaction trans, int batch, string frontendName, int hangInterval) {
            Command cmd = trans.CreateCommand(DequeueEmailsProcedureNameForFrontend);

            cmd.CreateParameter("@BATCHSIZE", DbType.Int32, batch);
            cmd.CreateParameter("@NULLDATE", DbType.DateTime, BuiltInFunction.NullDate());
            cmd.CreateParameter("@RECOVERINTERVALINMINS", DbType.Int32, hangInterval);
            cmd.CreateParameter("@FRONTENDNAME", DbType.String, frontendName);

            return cmd.ExecuteStoredProcedureWithResultSet(GetDequeueEmailsParamName());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public IDataReader DequeueEmails(Transaction trans, int batch, string frontendName, ObjectKey applicationKey, int hangInterval) {
            Command cmd = trans.CreateCommand(DequeueEmailsProcedureNameForApplication);

            cmd.CreateParameter("@BATCHSIZE", DbType.Int32, batch);
            cmd.CreateParameter("@NULLDATE", DbType.DateTime, BuiltInFunction.NullDate());
            cmd.CreateParameter("@RECOVERINTERVALINMINS", DbType.Int32, hangInterval);
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            cmd.CreateParameter("@FRONTENDNAME", DbType.String, frontendName);

            return cmd.ExecuteStoredProcedureWithResultSet(GetDequeueEmailsParamName());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DoNotTestSyntax("Throws exception when id is not found")]
        public void UpdateActivityNextRunWithError(Transaction tran, int id, string errorId, decimal backoffConstant, int retryBaseSec) {
            // #RPD-2091 - Implement exponential backoff for the next retry time.
            IDMLIdentifiers identifiers = tran.DatabaseServices.DMLService.Identifiers;
            string errorCountColumn = identifiers.EscapeIdentifier("ERROR_COUNT");

            Command cmd = tran.CreateCommand("UPDATE OSSYS_BPM_ACTIVITY SET " +
                ("NEXT_RUN = " + DBRuntimePlatform.Instance.GetNextRunErrorBackoffStatement(tran.DatabaseServices.DMLService.Functions, errorCountColumn, "@BACKOFF", "@RETRYBASESEC")) +
                ", LAST_ERROR_ID = @SSERRORID" +
                ", " + errorCountColumn + " = " + errorCountColumn + " + 1" +
                ", LAST_MODIFIED = GETDATE() WHERE ID=@ID");

            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.CreateParameter("@SSERRORID", DbType.String, errorId);
            cmd.CreateParameter("@BACKOFF", DbType.Decimal, backoffConstant);
            cmd.CreateParameter("@RETRYBASESEC", DbType.Int32, retryBaseSec);

            if (cmd.ExecuteNonQuery() == 0) {
                throw new DataBaseException("Unable to update activity. No rows affected");
            }
        }

        public bool ApplicationHasEmailDefinitions(Transaction trans, ObjectKey applicationKey) {
            Command cmd = trans.CreateCommand(@"SELECT COUNT(OSSYS_EMAIL_DEFINITION.ID) COUNT
                FROM OSSYS_EMAIL_DEFINITION
                        INNER JOIN OSSYS_MODULE ON OSSYS_EMAIL_DEFINITION.ESPACE_ID = OSSYS_MODULE.ESPACE_ID
                        INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                        INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                WHERE OSSYS_EMAIL_DEFINITION.IS_ACTIVE = 1
                        AND OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + " = @APPLICATIONKEY");
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            using (var reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    return reader.SafeGet<int>("COUNT") > 0;
                }
            }

            return false;
        }

        public bool ApplicationHasCyclicJobs(Transaction trans, ObjectKey applicationKey) {
            Command cmd = trans.CreateCommand(@"SELECT COUNT(OSSYS_META_CYCLIC_JOB.ID) COUNT
                FROM OSSYS_META_CYCLIC_JOB
                        INNER JOIN OSSYS_MODULE ON OSSYS_META_CYCLIC_JOB.ESPACE_ID = OSSYS_MODULE.ESPACE_ID
                        INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                        INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                WHERE OSSYS_META_CYCLIC_JOB.IS_ACTIVE = 1
                        AND OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + " = @APPLICATIONKEY");
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            using (var reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    return reader.SafeGet<int>("COUNT") > 0;
                }
            }

            return false;
        }

        public bool ApplicationHasActivities(Transaction trans, ObjectKey applicationKey) {
            Command cmd = trans.CreateCommand(@"SELECT COUNT(OSSYS_BPM_ACTIVITY_DEFINITION.ID) COUNT
                FROM OSSYS_BPM_ACTIVITY_DEFINITION
                        INNER JOIN OSSYS_BPM_PROCESS_DEFINITION ON OSSYS_BPM_PROCESS_DEFINITION.ID = OSSYS_BPM_ACTIVITY_DEFINITION.Process_Def_Id
                        INNER JOIN OSSYS_MODULE ON OSSYS_BPM_PROCESS_DEFINITION.Espace_Id = OSSYS_MODULE.ESPACE_ID
                        INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                        INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                WHERE OSSYS_BPM_ACTIVITY_DEFINITION.IS_ACTIVE = 1
                        AND OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + " = @APPLICATIONKEY");
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            using (var reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    return reader.SafeGet<int>("COUNT") > 0;
                }
            }

            return false;
        }

        public bool ApplicationHasProcesses(Transaction trans, ObjectKey applicationKey) {
            Command cmd = trans.CreateCommand(@"SELECT COUNT(OSSYS_BPM_PROCESS_DEFINITION.ID) COUNT
                FROM OSSYS_BPM_PROCESS_DEFINITION
                        INNER JOIN OSSYS_MODULE ON OSSYS_BPM_PROCESS_DEFINITION.Espace_Id = OSSYS_MODULE.ESPACE_ID
                        INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                        INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                WHERE OSSYS_BPM_PROCESS_DEFINITION.IS_ACTIVE = 1
                        AND OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + " = @APPLICATIONKEY");
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            using (var reader = cmd.ExecuteReader()) {
                if (reader.Read()) {
                    return reader.SafeGet<int>("COUNT") > 0;
                }
            }

            return false;
        }
    }
}