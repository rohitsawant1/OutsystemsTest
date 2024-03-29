/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.Logging.LogDefinition;
using OutSystems.ObjectKeys;

namespace OutSystems.HubEdition.RuntimePlatform.Log {

    [Serializable]
    public class GeneralLog {

        private GeneralLogDefinition log;

        public DateTime Instant {
            get {
                return log.Instant;
            }
            set {
                log.Instant = value;
            }
        }

        public string SessionId {
            get {
                return log.SessionId;
            }
            set {
                log.SessionId = value;
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

        public int UserId {
            get {
                return log.UserId;
            }
            set {
                log.UserId = value;
            }
        }

        public string Message {
            get {
                return log.Message;
            }
            set {
                log.Message = value;
            }
        }

        public string MessageType {
            get {
                return log.MessageType;
            }
            set {
                log.MessageType = value;
            }
        }

        public string ModuleName {
            get {
                return log.ModuleName;
            }
            set {
                log.ModuleName = value;
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

        public string RequestKey {
            get {
                return log.RequestKey;
            }
            set {
                log.RequestKey = value;
            }
        }

        public string EntrypointName {
            get {
                return log.EntrypointName;
            }
            set {
                log.EntrypointName = value;
            }
        }

        public string ActionName {
            get {
                return log.ActionName;
            }
            set {
                log.ActionName = value;
            }
        }

        public string ClientIP {
            get {
                return log.ClientIP;
            }
            set {
                log.ClientIP = value;
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

        public string Username {
            get {
                return log.Username;
            }
            set {
                log.Username = value;
            }
        }

        public const int MAX_ACTION_NAME = GeneralLogDefinition.MAX_ACTION_NAME;
        public const int MAX_SESSION_ID_SIZE = GeneralLogDefinition.MAX_SESSION_ID_SIZE;
        public const int MAX_MESSAGE_SIZE = GeneralLogDefinition.MAX_MESSAGE_SIZE;
        public const int MAX_MESSAGE_TYPE_SIZE = GeneralLogDefinition.MAX_MESSAGE_TYPE_SIZE;
        public const int MAX_MODULE_NAME_SIZE = GeneralLogDefinition.MAX_MODULE_NAME_SIZE;
        public const int MAX_ERROR_ID_SIZE = GeneralLogDefinition.MAX_ERROR_ID_SIZE;
        public const int MAX_CLIENT_IP_SIZE = GeneralLogDefinition.MAX_CLIENT_IP_SIZE;

        public GeneralLog() {
            log = new GeneralLogDefinition();
        }

        public GeneralLog(DateTime instant, string sessionId, int espaceId, int tenantId, int userId, string message, string messageType, string moduleName, string errorId) {
            string requestKey, actionName, entryPointName, clientIp;
            requestKey = actionName = entryPointName = clientIp = String.Empty;

            RequestTracer reqTracer = RuntimePlatformUtils.GetRequestTracer();
            if (reqTracer != null) {
                requestKey = reqTracer.RequestKey;
                actionName = reqTracer.EntryActionName;
                entryPointName = reqTracer.EntryEndpointName;
            }
            clientIp = RuntimePlatformUtils.GetRequestSourceForLogging();

            GetEspaceDetails(espaceId, userId, out string eSpaceName, out string applicationName, out ObjectKey applicationKey, out string username);

            log = new GeneralLogDefinition(instant, sessionId, espaceId, tenantId, userId, message, messageType, moduleName,
                                            errorId, requestKey, actionName, entryPointName, clientIp,
                                            eSpaceName, applicationName, applicationKey, username);
        }

        public GeneralLog(GeneralLog obj) {
            log = new GeneralLogDefinition(obj.Instant, obj.SessionId, obj.EspaceId, obj.TenantId, obj.UserId, obj.Message, 
                    obj.MessageType, obj.ModuleName, obj.ErrorId, obj.RequestKey, obj.ActionName, obj.EntrypointName, obj.ClientIP,
                    obj.EspaceName, obj.ApplicationName, obj.ApplicationKey, obj.Username);
        }

        public object Clone() {
            return new GeneralLog(this);
        }

        public static void StaticWrite(DateTime instant, string sessionId, int espaceId, int tenantId, int userId,
                string message, string messageType, string moduleName, string errorId) {
            GeneralLog log = new GeneralLog();
            log.Write(instant, sessionId, espaceId, tenantId, userId, message, messageType, moduleName, errorId);
        }

        public void Write(DateTime instant, string sessionId, int espaceId, int tenantId, int userId,
            string message, string messageType, string moduleName, string errorId) {

            GetEspaceDetails(espaceId, userId, out string eSpaceName, out string applicationName, out ObjectKey applicationKey, out string username);

            Write(instant, sessionId, espaceId, tenantId, userId,
                message, messageType, moduleName, errorId,
                eSpaceName, applicationName, applicationKey, username);
        }

        public void GetEspaceDetails(int eSpaceId, int userId, out string eSpaceName, out string applicationName, out ObjectKey applicationKey, out string username) {
            eSpaceName = null;
            applicationName = null;
            applicationKey = null;
            username = null;

            try {
                var appInfo = AppInfo.GetAppInfo();
                var sessionInfo = appInfo?.OsContext?.Session;

                // ensure the AppInfo matches the eSpaceID passed as parameter
                if (appInfo?.eSpaceId == eSpaceId) {
                    eSpaceName = eSpaceName ?? appInfo?.eSpaceName;
                    applicationName = applicationName ?? appInfo?.ApplicationName;
                    applicationKey = applicationKey ?? appInfo?.ApplicationUIDAsKey;
                }

                // ensure that the current user matches the userId defined in the log
                if (userId == sessionInfo?.UserId) {
                    username = username ?? sessionInfo?.UserName;
                }
            } catch { }
        }

        public void Write(DateTime instant, string sessionId, int espaceId, int tenantId, int userId,
            string message, string messageType, string moduleName, string errorId,
            string eSpaceName, string applicationName, ObjectKey applicationKey, string username) {
            string requestKey = RequestKey;
            string actionName = ActionName;
            string entryPointName = EntrypointName;
            string clientIp = ClientIP;

            RequestTracer reqTracer = RuntimePlatformUtils.GetRequestTracer();
            if (reqTracer != null) {
                requestKey = reqTracer.RequestKey;
                actionName = reqTracer.EntryActionName;
                entryPointName = reqTracer.EntryEndpointName;
            }
            clientIp = RuntimePlatformUtils.GetRequestSourceForLogging();

            log.Write(instant, sessionId, espaceId, tenantId, userId, message, messageType, moduleName,
                        errorId, requestKey, actionName, entryPointName, clientIp,
                        eSpaceName, applicationName, applicationKey, username);
        }

        public void Write() {
            log.Write();
        }
    }
}
