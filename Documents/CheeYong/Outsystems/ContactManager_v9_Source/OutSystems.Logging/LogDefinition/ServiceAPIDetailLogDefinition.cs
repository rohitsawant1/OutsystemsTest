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
using OutSystems.RuntimeCommon;

namespace OutSystems.Logging.LogDefinition {
    [Serializable]
    public class ServiceAPIDetailLogDefinition : AbstractLogDefinition {
         
        public string Id;
        public DateTime Instant;
        public int TenantId;
        public string Message;
        public string Detail;
        public string DetailLabel;

        public const int MAX_ID_SIZE = 50;
        public const int MAX_MESSAGE_SIZE = 2000;
        public const int MAX_DETAIL_SIZE = 5000000; // A bit less than 5MB, will also be limited by Log_MaxMessagesSizeInKbForLargeContentQueues (default 1Mb)
        public const int MAX_DETAIL_LABEL_SIZE = 50;

        public ServiceAPIDetailLogDefinition() { }

        public ServiceAPIDetailLogDefinition(string id, DateTime instant, int tenant_Id, string message, string detail, string detailLabel) {
            Id = id;
            Instant = instant;
            TenantId = tenant_Id;
            Message = message;
            Detail = detail;
            DetailLabel = detailLabel;
        }

        public ServiceAPIDetailLogDefinition(ServiceAPIDetailLogDefinition log) : 
            this(log.Id, log.Instant, log.TenantId, log.Message, log.Detail, log.DetailLabel) { 
        }

        public override object Clone() {
            return new ServiceAPIDetailLogDefinition(this);
        }

        public void Write() {
            RuntimeLogger.Log(this);
        }

        public static string StaticWrite(DateTime instant, int tenant_Id, string message, string detail, string detailLabel) {
            return StaticWrite(GenerateLogId(), instant, tenant_Id, message, detail, detailLabel);
        }

        public static string StaticWrite(string id, DateTime instant, int tenant_Id, string message, string detail, string detailLabel) {
            ServiceAPIDetailLogDefinition log = new ServiceAPIDetailLogDefinition(id, instant, tenant_Id, message, detail, detailLabel);
            log.Write();

            return log.Id;
        }

        public static string GenerateLogId() {
            return Guid.NewGuid().ToString();
        }
    }
}
