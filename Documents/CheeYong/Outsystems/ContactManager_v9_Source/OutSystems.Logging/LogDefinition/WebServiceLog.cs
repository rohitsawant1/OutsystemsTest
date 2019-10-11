/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.Logging.LogDefinition {
    [Serializable]
    public class WebServiceLogDefinition : AbstractLogDefinition {
        public DateTime Instant;
        public int Duration;
        public string Name;
        public string Method;
        public int EspaceId;
        public int TenantId;
        public string Client_IP;
        public string ExecutedBy;
        public string ErrorId;

        public WebServiceLogDefinition() {
        }

        public WebServiceLogDefinition(DateTime instant, int duration, string name, string method, int espaceId, int tenantId, string client_ip, string executedBy, string errorId) {
            Instant = instant;
            Duration = duration;
            Name = name;
            Method = method;
            EspaceId = espaceId;
            TenantId = tenantId;
            Client_IP = client_ip;
            ExecutedBy = executedBy;
            ErrorId = errorId;
        }

        public WebServiceLogDefinition(WebServiceLogDefinition obj) {
            Instant = obj.Instant;
            Duration = obj.Duration;
            Name = obj.Name;
            Method = obj.Method;
            EspaceId = obj.EspaceId;
            TenantId = obj.TenantId;
            Client_IP = obj.Client_IP;
            ExecutedBy = obj.ExecutedBy;
            ErrorId = obj.ErrorId;
        }

        public override object Clone() {
            return new WebServiceLogDefinition(this);
        }

        public static void StaticWrite(DateTime instant, int duration, string name, string method, int espaceId, int tenantId,
            string client_ip, string executedBy, string errorId) {
            WebServiceLogDefinition log = new WebServiceLogDefinition();
            log.Write(instant, duration, name, method, espaceId, tenantId, client_ip, executedBy, errorId);
        }

        public void Write(DateTime instant, int duration, string name, string method, int espaceId, int tenantId, string client_ip,
            string executedBy, string errorId) {
            Instant = instant;
            Duration = duration;
            Name = name;
            Method = method;
            EspaceId = espaceId;
            TenantId = tenantId;
            Client_IP = client_ip;
            ExecutedBy = executedBy;
            ErrorId = errorId;

            Write();
        }

        public void Write() {
        }
    }
}
