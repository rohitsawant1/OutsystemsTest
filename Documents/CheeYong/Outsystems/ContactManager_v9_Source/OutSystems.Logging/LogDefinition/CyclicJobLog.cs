/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;

namespace OutSystems.Logging.LogDefinition {

    [Serializable]
    public class CyclicJobLogDefinition : AbstractLogDefinition {

        public DateTime Instant;
        public int Duration;
        public ObjectKey CyclicJobKey;
        public int EspaceId;
        public int TenantId;
        public string ExecutedBy;
        public string ErrorId;
        public DateTime ShouldHaveRunAt;
        public DateTime NextRun;
        public string RequestKey;
        public string EspaceName;
        public string ApplicationName;
        public ObjectKey ApplicationKey;
        public string CyclicJobName;

        public const int MAX_EXECUTED_BY_SIZE = 50;
        public const int MAX_ERROR_ID_SIZE = 50;

        public CyclicJobLogDefinition() { }

        public CyclicJobLogDefinition(DateTime instant, int duration, ObjectKey cyclicJobKey, int espaceId, int tenantId, string executedBy,
                                        string errorId, DateTime shouldHaveRunAt, DateTime nextRun, string requestKey,
                                        string eSpaceName, string applicationName, ObjectKey applicationKey, string cyclicJobName) {
            Instant = instant;
            Duration = duration;
            CyclicJobKey = cyclicJobKey;
            EspaceId = espaceId;
            TenantId = tenantId;
            ExecutedBy = executedBy?.Left(MAX_EXECUTED_BY_SIZE) ?? string.Empty;
            ErrorId = errorId?.Left(MAX_ERROR_ID_SIZE) ?? string.Empty;
            ShouldHaveRunAt = shouldHaveRunAt;
            NextRun = nextRun;
            RequestKey = requestKey;
            EspaceName = eSpaceName;
            ApplicationName = applicationName;
            ApplicationKey = applicationKey;
            CyclicJobName = cyclicJobName;
        }

        public CyclicJobLogDefinition(CyclicJobLogDefinition obj) : 
            this(obj.Instant, obj.Duration, obj.CyclicJobKey, obj.EspaceId, obj.TenantId, obj.ExecutedBy,
                    obj.ErrorId, obj.ShouldHaveRunAt, obj.NextRun, obj.RequestKey,
                    obj.EspaceName, obj.ApplicationName, obj.ApplicationKey, obj.CyclicJobName) { 
        }

        public override object Clone() {
            return new CyclicJobLogDefinition(this);
        }

        public void Write(DateTime instant, int duration, ObjectKey cyclicJobKey, int espaceId, int tenantId, string executedBy,
                            string errorId, DateTime shouldHaveRunAt, DateTime nextRun, string requestKey,
                            string eSpaceName, string applicationName, ObjectKey applicationKey, string cyclicJobName) {
            Instant = instant;
            Duration = duration;
            CyclicJobKey = cyclicJobKey;
            EspaceId = espaceId;
            TenantId = tenantId;
            ExecutedBy = executedBy?.Left(MAX_EXECUTED_BY_SIZE) ?? string.Empty;
            ErrorId = errorId?.Left(MAX_ERROR_ID_SIZE) ?? string.Empty;
            ShouldHaveRunAt = shouldHaveRunAt;
            NextRun = nextRun;
            RequestKey = requestKey;
            EspaceName = eSpaceName;
            ApplicationName = applicationName;
            ApplicationKey = applicationKey;
            CyclicJobName = cyclicJobName;

            Write();
        }

        public void Write() {
            RuntimeLogger.Log(this);
        }
        
        public static void StaticWrite(DateTime instant, int duration, ObjectKey cyclicJobKey, int espaceId, int tenantId, string executedBy,
            string errorId, DateTime shouldHaveRunAt, DateTime nextRun, string requestKey, string eSpaceName, string applicationName, ObjectKey applicationKey, string cyclicJobName) {
            CyclicJobLogDefinition log = new CyclicJobLogDefinition(instant, duration, cyclicJobKey, espaceId, tenantId, executedBy,
                errorId, shouldHaveRunAt, nextRun, requestKey, eSpaceName, applicationName, applicationKey, cyclicJobName);
            log.Write();
        }
    }
}
