/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.Logging.LogDefinition;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.Log {

    [Serializable]
    public class IntegrationLog {
        private IntegrationLogDefinition log;

        public string Id {
            get {
                return log.Id;
            } set {
                log.Id = value;
            }
        }

        public DateTime Instant {
            get {
                return log.Instant;
            }
            set {
                log.Instant = value;
            }
        }

        public int Duration {
            get {
                return log.Duration;
            }
            set {
                log.Duration = value;
            }
        }

        public string Source {
            get {
                return log.Source;
            }
            set {
                log.Source = value;
            }
        }

        public string Endpoint {
            get {
                return log.Endpoint;
            }
            set {
                log.Endpoint = value;
            }
        }

        public string Action {
            get {
                return log.Action;
            }
            set {
                log.Action = value;
            }
        }

        public string Type {
            get {
                return log.Type;
            }
            set {
                log.Type = value;
            }
        }

        public int EspaceId {
            get {
                return log.EspaceId;
            }
            set {
                log.EspaceId = value;
            }
        }

        public int TenantId {
            get {
                return log.TenantId;
            }
            set {
                log.TenantId = value;
            }
        }

        public string ErrorId {
            get {
                return log.ErrorId;
            }
            set {
                log.ErrorId = value;
            }
        }

        public string ExecutedBy {
            get {
                return log.ExecutedBy;
            }
            set {
                log.ExecutedBy = value;
            }
        }

        public bool IsExpose {
            get {
                return log.IsExpose;
            }
            set {
                log.IsExpose = value;
            }
        }

        public string RequestKey {
            get {
                return log.RequestKey;
            }
            set {
                log.RequestKey = value;
            }
        }

        public string EspaceName {
            get {
                return log.EspaceName;
            }
            set {
                log.EspaceName = value;
            }
        }

        public string ApplicationName {
            get {
                return log.ApplicationName;
            }
            set {
                log.ApplicationName = value;
            }
        }

        public ObjectKey ApplicationKey {
            get {
                return log.ApplicationKey;
            }
            set {
                log.ApplicationKey = value;
            }
        }


        public const int MAX_ID_SIZE = IntegrationLogDefinition.MAX_ID_SIZE;
        public const int MAX_SOURCE_SIZE = IntegrationLogDefinition.MAX_SOURCE_SIZE;
        public const int MAX_ENDPOINT_SIZE = IntegrationLogDefinition.MAX_ENDPOINT_SIZE;
        public const int MAX_ACTION_SIZE = IntegrationLogDefinition.MAX_ACTION_SIZE;
        public const int MAX_TYPE_SIZE = IntegrationLogDefinition.MAX_TYPE_SIZE;
        public const int MAX_ERROR_ID_SIZE = IntegrationLogDefinition.MAX_ERROR_ID_SIZE;
        

        public IntegrationLog() {
            log = new IntegrationLogDefinition();
        }

        public IntegrationLog(IAppInfo appInfo, string id, DateTime instant, int duration, string source, string endpoint, string action, string type,
            string errorId, string executedBy, bool isExpose) {
            log = new IntegrationLogDefinition();

            Id = id;
            Instant = instant;
            Duration = duration;
            Source = source?.Left(MAX_SOURCE_SIZE) ?? string.Empty;
            Endpoint = endpoint?.Left(MAX_ENDPOINT_SIZE) ?? string.Empty;
            Action = action;
            Type = type;
            EspaceId = appInfo?.eSpaceId ?? 0;
            TenantId = appInfo?.TenantId ?? 0;
            ErrorId = errorId;
            ExecutedBy = executedBy;
            IsExpose = isExpose;
            EspaceName = appInfo?.eSpaceName;
            ApplicationName = appInfo?.ApplicationName;
            ApplicationKey = appInfo?.ApplicationUIDAsKey;

            RequestTracer reqTracer = RuntimePlatformUtils.GetRequestTracer();
            if (reqTracer != null) {
                RequestKey = reqTracer.RequestKey;
            }
        }



        public IntegrationLog(IntegrationLog obj) {
            log = new IntegrationLogDefinition();

            Id = IntegrationLogDefinition.GenerateLogId();
            Instant = obj.Instant;
            Duration = obj.Duration;
            Source = obj.Source;
            Endpoint = obj.Endpoint;
            Action = obj.Action;
            Type = obj.Type;
            EspaceId = obj.EspaceId;
            TenantId = obj.TenantId;
            ErrorId = obj.ErrorId;
            ExecutedBy = obj.ExecutedBy;
            IsExpose = obj.IsExpose;
            RequestKey = obj.RequestKey;
            EspaceName = obj.EspaceName;
            ApplicationName = obj.ApplicationName;
            ApplicationKey = obj.ApplicationKey;
        }

        public IntegrationLog(WebServiceLog obj) {
            log = new IntegrationLogDefinition();

            Id = IntegrationLogDefinition.GenerateLogId();
            Instant = obj.Instant;
            Duration = obj.Duration;
            Source = obj.Client_IP;
            Endpoint = String.Empty;
            Action = obj.Method;
            Type = String.Empty;
            EspaceId = obj.EspaceId;
            TenantId = obj.TenantId;
            ErrorId = obj.ErrorId;
            ExecutedBy = obj.ExecutedBy;
            IsExpose = true;
        }

        public IntegrationLog(WebReferenceLog obj) {
            log = new IntegrationLogDefinition();

            Id = IntegrationLogDefinition.GenerateLogId();
            Instant = obj.Instant;
            Duration = obj.Duration;
            Source = String.Empty;
            Endpoint = obj.URL;
            Action = obj.Method;
            Type = String.Empty;
            EspaceId = obj.EspaceId;
            TenantId = obj.TenantId;
            ErrorId = obj.ErrorId;
            ExecutedBy = obj.Executed_By;
            IsExpose = false;
        }

        public object Clone() {
            return new IntegrationLog(this);
        }

        public static string StaticWrite(IAppInfo appInfo, DateTime instant, int duration, string source, string endpoint, string action, string type,
            string errorId, bool isExpose) {
            IntegrationLog log = new IntegrationLog();
            log.Write(appInfo, IntegrationLogDefinition.GenerateLogId(), instant, duration, source, endpoint, action, type, errorId, isExpose);
            return log.Id;
        }

        public void Write(IAppInfo appInfo, string id, DateTime instant, int duration, string source, string endpoint, string action, string type,
            string errorId, bool isExpose) {
            Id = id;
            Instant = instant;
            Duration = duration;
            Source = source?.Left(MAX_SOURCE_SIZE) ?? string.Empty;
            Endpoint = endpoint?.Left(MAX_ENDPOINT_SIZE) ?? string.Empty;
            Action = action;
            Type = type;
            EspaceId = appInfo?.eSpaceId ?? 0;
            TenantId = appInfo?.TenantId ?? 0;
            ErrorId = errorId;
            ExecutedBy = RuntimeEnvironment.MachineName;
            IsExpose = isExpose;
            EspaceName = appInfo?.eSpaceName;
            ApplicationName = appInfo?.ApplicationName;
            ApplicationKey = appInfo?.ApplicationUIDAsKey;

            RequestTracer reqTracer = RuntimePlatformUtils.GetRequestTracer();
            if (reqTracer != null) {
                RequestKey = reqTracer.RequestKey;
            }

            log.Write();
        }
    }
}