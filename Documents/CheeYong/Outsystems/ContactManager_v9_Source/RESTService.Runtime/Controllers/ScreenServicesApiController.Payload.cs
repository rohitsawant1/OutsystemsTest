/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace OutSystems.RESTService.Controllers {
    public abstract partial class ScreenServicesApiController {

        public class Payload {

           public class RequestVersionInfo {
                [JsonProperty("moduleVersion")]
                public string ModuleVersionHash;

                [JsonProperty("apiVersion")]
                public string ApiVersionHash;
            }

            public class ResponseVersionInfo {
                [JsonProperty("hasModuleVersionChanged")]
                public readonly bool HasModuleVersionChanged;

                [JsonProperty("hasApiVersionChanged")]
                public readonly bool HasApiVersionChanged;

                public ResponseVersionInfo(RequestVersionInfo CurrentVersion, string newModuleVersionHash, string newApiVersionHash) {
                    HasModuleVersionChanged = CurrentVersion == null || CurrentVersion.ModuleVersionHash != newModuleVersionHash;
                    HasApiVersionChanged = newApiVersionHash != null && (CurrentVersion == null || CurrentVersion.ApiVersionHash != newApiVersionHash);
                }
            }

            public class RequestPayload {

                [JsonProperty("versionInfo")]
                public RequestVersionInfo VersionInfo;

                [JsonProperty("viewName")]
                public string ViewName;

                [JsonProperty("screenData")]
                public JObject ScreenData;

                [JsonProperty("inputParameters")]
                public JObject InputParameters;
            }


            public class ResponsePayload {

                [JsonProperty("versionInfo")]
                public ResponseVersionInfo VersionInfo;

                [JsonProperty("data")]
                public object Data;
                //public IDataPayload Data;
                
                [JsonProperty("exception")]
                public ExceptionPayload Exception;


                [JsonProperty("rolesInfo")]
                public string RolesInfo;

                public ResponsePayload(ResponseVersionInfo versionInfo,
                                       object data,
                                       ExceptionPayload exception, 
                                       string rolesInfo) {

                    this.VersionInfo = versionInfo;
                    this.Data = data;
                    this.Exception = exception;
                    this.RolesInfo = rolesInfo;
                }
            }

            public interface IDataPayload { }

            public class EmptyDataPayload : IDataPayload { }
        }
    }
}
