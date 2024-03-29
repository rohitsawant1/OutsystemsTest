/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Data;
using System.Runtime.CompilerServices;
using OutSystems.HubEdition.Extensibility.Data.Platform.QueryProvider;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.ObfuscationProperties;

namespace OutSystems.Scheduler.Core {

    [DoNotObfuscateType]
    [DatabaseProviderSpecificImplementationFor("MySQL")]
    internal class DBSchedulerMySQL : DBScheduler {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public override void DeleteEmailContentIfNeeded(Transaction trans, int id) {
            Command cmd = trans.CreateCommand(
                "DELETE ec FROM OSSYS_EMAIL_CONTENT AS ec INNER JOIN " +
                "(SELECT EMAIL.ID FROM OSSYS_EMAIL EMAIL WHERE EMAIL.ID = @ID AND EMAIL.STORE_CONTENT = 0 ) AS ecf on ec.id=ecf.id");
            cmd.CreateParameter("@ID", DbType.Int32, id);
            cmd.ExecuteNonQuery();
        }

        /*
         * The optimization done in DBScheduler.cs (RPD-2988) for SQL Server and Oracle is not directly compatible with MySQS
         * because MySQL has no support for CTE in the DB version supported by the platform (5.6.x). This has only
         * become available in MySQL 8.0. That's why the old query was kept.
         */
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override IDataReader GetCyclicJobsForFrontend(Transaction trans, string frontendName) {
            string sql =
                @"SELECT COALESCE(CJ.ID, CJSHARED.META_CYCLIC_JOB_ID) ID, 
                META.SS_KEY, 
                META.IS_SHARED,
                META.NAME META_CYCLIC_JOB_NAME, 
                OSSYS_ESPACE.NAME ESPACE_NAME, 
                OSSYS_ESPACE.ID ESPACE_ID, 
                OSSYS_ESPACE.SS_KEY ESPACE_KEY, 
                OSSYS_ESPACE.IS_MULTITENANT, 
                (CASE WHEN OSSYS_ESPACE.USER_PROVIDER_KEY = '' OR OSSYS_ESPACE.USER_PROVIDER_KEY = ' ' THEN OSSYS_ESPACE.SS_KEY ELSE OSSYS_ESPACE.USER_PROVIDER_KEY END) USER_PROVIDER_KEY, 
                OSSYS_TENANT.NAME TENANT_NAME, 
                OSSYS_TENANT.ID TENANT_ID, 
                COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) NEXT_RUN, 
                COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) SCHEDULE,
                COALESCE(CJ.LAST_RUN, CJSHARED.LAST_RUN) LAST_RUN, 
                (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END) REAL_TIMEOUT,
                (CASE COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) WHEN '" + Constants.TimerScheduleWhenPublished + @"' THEN 1 ELSE META.PRIORITY END) PRIORITY
                FROM OSSYS_META_CYCLIC_JOB META
                INNER JOIN OSSYS_ESPACE ON OSSYS_ESPACE.ID = META.ESPACE_ID AND OSSYS_ESPACE.IS_ACTIVE = 1 AND META.IS_ACTIVE = 1
                INNER JOIN OSSYS_MODULEFRONTEND ON OSSYS_MODULEFRONTEND.MODULEKEY = OSSYS_ESPACE.SS_KEY
                LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = META.ESPACE_ID
                LEFT JOIN OSSYS_CYCLIC_JOB CJ ON META.ID = CJ.META_CYCLIC_JOB_ID AND META.IS_SHARED = 0
                LEFT JOIN OSSYS_ESPACE_TENANT ON OSSYS_ESPACE_TENANT.ESPACE_ID = META.ESPACE_ID AND OSSYS_ESPACE_TENANT.TENANT_ID = CJ.TENANT_ID
                LEFT JOIN OSSYS_TENANT ON OSSYS_TENANT.ID = OSSYS_ESPACE_TENANT.TENANT_ID AND OSSYS_TENANT.IS_ACTIVE = 1 
                LEFT JOIN OSSYS_CYCLIC_JOB_SHARED CJSHARED ON META.ID = CJSHARED.META_CYCLIC_JOB_ID AND META.IS_SHARED = 1
                WHERE 
                (@FRONTENDNAME = " + trans.DatabaseServices.DMLService.DefaultValues.Text + @" OR OSSYS_MODULEFRONTEND.FRONTENDNAME = @FRONTENDNAME)
                AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0)
                AND (CJ.ID IS NULL OR OSSYS_TENANT.ID IS NOT NULL) AND 
                (COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE) IS NULL OR GETDATE() > " +
                trans.DatabaseServices.DMLService.Functions.AddMinutes("COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE)", "1.2 * (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END)") + @")
                AND COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) <= GETDATE() 
                ORDER BY META.PRIORITY ASC, COALESCE(CJ.LAST_DURATION, CJSHARED.LAST_DURATION) ASC, COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) ASC";
            var cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@FRONTENDNAME", DbType.String, frontendName ?? trans.DatabaseServices.DMLService.DefaultValues.Text);
            return cmd.ExecuteReader();
        }

        /*
         * The optimization done in DBScheduler.cs (RPD-2988) for SQL Server and Oracle is not directly compatible with MySQS
         * because MySQL has no support for CTE in the DB version supported by the platform (5.6.x). This has only
         * become available in MySQL 8.0. That's why the old query was kept.
         */
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override IDataReader GetCyclicJobsForApplication(Transaction trans, ObjectKey applicationKey) {
            string sql =
                @"SELECT COALESCE(CJ.ID, CJSHARED.META_CYCLIC_JOB_ID) ID, 
                META.SS_KEY, 
                META.IS_SHARED,
                META.NAME META_CYCLIC_JOB_NAME, 
                OSSYS_ESPACE.NAME ESPACE_NAME, 
                OSSYS_ESPACE.ID ESPACE_ID, 
                OSSYS_ESPACE.SS_KEY ESPACE_KEY, 
                OSSYS_ESPACE.IS_MULTITENANT, 
                (CASE WHEN OSSYS_ESPACE.USER_PROVIDER_KEY = '' OR OSSYS_ESPACE.USER_PROVIDER_KEY = ' ' THEN OSSYS_ESPACE.SS_KEY ELSE OSSYS_ESPACE.USER_PROVIDER_KEY END) USER_PROVIDER_KEY, 
                OSSYS_TENANT.NAME TENANT_NAME, 
                OSSYS_TENANT.ID TENANT_ID, 
                COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) NEXT_RUN, 
                COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) SCHEDULE,
                COALESCE(CJ.LAST_RUN, CJSHARED.LAST_RUN) LAST_RUN, 
                (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END) REAL_TIMEOUT,
                (CASE COALESCE(CJ.SCHEDULE, CJSHARED.SCHEDULE) WHEN '" + Constants.TimerScheduleWhenPublished + @"' THEN 1 ELSE META.PRIORITY END) PRIORITY
                FROM OSSYS_META_CYCLIC_JOB META
                INNER JOIN OSSYS_ESPACE ON OSSYS_ESPACE.ID = META.ESPACE_ID AND OSSYS_ESPACE.IS_ACTIVE = 1 AND META.IS_ACTIVE = 1
                INNER JOIN OSSYS_MODULE ON OSSYS_ESPACE.ID = OSSYS_MODULE.ESPACE_ID
                INNER JOIN OSSYS_APP_DEFINITION_MODULE ON OSSYS_APP_DEFINITION_MODULE.MODULE_ID = OSSYS_MODULE.ID
                INNER JOIN OSSYS_APPLICATION ON OSSYS_APPLICATION.ID = OSSYS_APP_DEFINITION_MODULE.APPLICATION_ID
                LEFT JOIN OSSYS_ESPACE_RUNTIME RUNTIME ON RUNTIME.ESPACE_ID = META.ESPACE_ID
                LEFT JOIN OSSYS_CYCLIC_JOB CJ ON META.ID = CJ.META_CYCLIC_JOB_ID AND META.IS_SHARED = 0
                LEFT JOIN OSSYS_ESPACE_TENANT ON OSSYS_ESPACE_TENANT.ESPACE_ID = META.ESPACE_ID AND OSSYS_ESPACE_TENANT.TENANT_ID = CJ.TENANT_ID
                LEFT JOIN OSSYS_TENANT ON OSSYS_TENANT.ID = OSSYS_ESPACE_TENANT.TENANT_ID AND OSSYS_TENANT.IS_ACTIVE = 1 
                LEFT JOIN OSSYS_CYCLIC_JOB_SHARED CJSHARED ON META.ID = CJSHARED.META_CYCLIC_JOB_ID AND META.IS_SHARED = 1
                WHERE 
                OSSYS_APPLICATION." + trans.DatabaseServices.DMLService.Identifiers.EscapeIdentifier("KEY") + @" = @APPLICATIONKEY
                AND (RUNTIME.ID IS NULL OR RUNTIME.DISABLED = 0)
                AND (CJ.ID IS NULL OR OSSYS_TENANT.ID IS NOT NULL) AND 
                (COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE) IS NULL OR GETDATE() > " +
                trans.DatabaseServices.DMLService.Functions.AddMinutes("COALESCE(CJ.IS_RUNNING_SINCE, CJSHARED.IS_RUNNING_SINCE)", "1.2 * (CASE META.EFFECTIVE_TIMEOUT WHEN 0 THEN META.TIMEOUT ELSE META.EFFECTIVE_TIMEOUT END)") + @")
                AND COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) <= GETDATE() 
                ORDER BY META.PRIORITY ASC, COALESCE(CJ.LAST_DURATION, CJSHARED.LAST_DURATION) ASC, COALESCE(CJ.NEXT_RUN, CJSHARED.NEXT_RUN) ASC";
            var cmd = trans.CreateCommand(sql);
            cmd.CreateParameter("@APPLICATIONKEY", DbType.String, applicationKey);
            return cmd.ExecuteReader();
        }
    }
}
