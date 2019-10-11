/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.ObjectKeys;

namespace OutSystems.Logging.LogDefinition {
    [Serializable]
    public class ServiceAPILogDefinition : AbstractLogDefinition {
                        
        public string Id;
        public DateTime Instant;
        public string SessionId;
        public int UserId;
        public string LoginId;
        public int EspaceId;
        public int TenantId;
        public string ErrorId;
        public string ExecutedBy;
        public string RequestKey;
        public string EntryPointName;
        public string Action;
        public int Duration;
        public string Source;
        public string Endpoint;
        public string EspaceName;
        public string ApplicationName;
        public ObjectKey ApplicationKey;
        public string Username;
        public string OriginalRequestKey;

        public const int MAX_ID_SIZE = 50;
        public const int MAX_SOURCE_SIZE = 1000;
        public const int MAX_ENDPOINT_SIZE = 1000;
        public const int MAX_ACTION_SIZE = 60;
        public const int MAX_LOGIN_ID_SIZE = 60;
        public const int MAX_ERROR_ID_SIZE = 50;
        public const int MAX_SESSION_ID_SIZE = 50;
        public const int MAX_ESPACE_NAME_SIZE = 50;
        public const int MAX_APPLICATION_NAME_SIZE = 50;
        public const int MAX_USERNAME_SIZE = 250;
        public const int MAX_EXECUTED_BY_SIZE = 50;
        public const int MAX_ENTRY_POINT_NAME_SIZE = 60;
        public const int MAX_ORIGINAL_REQUEST_KEY = 36;
        public const int MAX_REQUEST_KEY = 36;
        
        public ServiceAPILogDefinition() { }

        public ServiceAPILogDefinition(ServiceAPILogDefinition obj) {
            Id = obj.Id;
            Instant = obj.Instant;
            SessionId = obj.SessionId;
            UserId = obj.UserId;
            LoginId = obj.LoginId;
            EspaceId = obj.EspaceId;
            TenantId = obj.TenantId;
            ErrorId = obj.ErrorId;
            ExecutedBy = obj.ExecutedBy;
            RequestKey = obj.RequestKey;
            EntryPointName = obj.EntryPointName;
            Action = obj.Action;
            Duration = obj.Duration;
            Source = obj.Source;
            Endpoint = obj.Endpoint;
            EspaceName = obj.EspaceName;
            ApplicationName = obj.ApplicationName;
            ApplicationKey = obj.ApplicationKey;
            Username = obj.Username;
            OriginalRequestKey = obj.OriginalRequestKey;
        }

        public override object Clone() {
            return new ServiceAPILogDefinition(this);
        }

        public void Write() {
            RuntimeLogger.Log(this);
        }

        public static string GenerateLogId() {
            return Guid.NewGuid().ToString();
        }
    }
}
