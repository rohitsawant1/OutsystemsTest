/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.Http;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RESTService.Behaviors;
using OutSystems.RESTService.ErrorHandling;
using OutSystems.RESTService.Formatters;
using System.Net.Http;
using OutSystems.Internal.Db;
using Newtonsoft.Json;
using OutSystems.RuntimeCommon;
using System.Collections.Generic;

namespace OutSystems.RESTService.Controllers {
    public abstract partial class RestServiceApiController : ApiController {

        protected const string AuthorizationPayloadKey = "Authorization";
        protected const string ApplicationNotEnabledMessage = "Application Backend Unavailable";
        protected readonly IBehaviorsConfiguration BehaviorsConfiguration;

        public RestServiceApiController() {
            var config = (RestServiceControllerConfiguration)this.GetType().GetCustomAttributes(typeof(RestServiceControllerConfiguration), true).FirstOrDefault();
            if (config != null) {
                this.BehaviorsConfiguration = config;
            } else {
                this.BehaviorsConfiguration = new RestServiceControllerConfiguration();
            }
        }

        protected DefaultValuesBehavior DefaultValuesBehavior {
            get { return this.BehaviorsConfiguration.DefaultValuesBehavior; }
        }

        protected JsonMediaTypeFormatter JsonMediaTypeFormater {
            get {
                return CustomJsonMediaTypeFormatter.GetInstance(this.BehaviorsConfiguration);
            }
        }

        public void ValidateRequestSecurity() {
            var useSSL = BehaviorsConfiguration.HTTPSecurity == HTTPSecurity.SSL;
            if (useSSL || ShouldEnforceSecureRequests(AppInfo.GetAppInfo())) {
                if(!RuntimePlatformUtils.RequestIsSecure(HttpContext.Current.Request, !useSSL)) {
                    throw new ExposeRestException("HTTPS connection required.", HttpStatusCode.Forbidden);
                }
            }

            if (BehaviorsConfiguration.InternalAccessOnly) {
                if (!RuntimePlatformUtils.InternalAddressIdentification(HttpContext.Current.Request)) {
                    throw new ExposeRestException("Access Denied.", HttpStatusCode.Forbidden);
                }
            }
        }

        private static bool ShouldEnforceSecureRequests(AppInfo appInfo) {
            return appInfo != null && appInfo.IsForcingSecurityForIntegrations();
        }

        /// <summary>
        /// Parses an  Authorization Header that contains Basic Authentication and sets Username and Password decoded from Base64.
        /// </summary>
        /// <remarks>The Auth Header is obtained from the current HttpRequest.</remarks>
        /// <param name="originalHeader">The Basic Authentication Header. Format: basic base64(user:pass)</param>
        /// <param name="username">The username retreived from the header.</param>
        /// <param name="password">The password retreived from the header.</param>
        /// <exception cref="ExposeRestException">If no BasicAuth header is present or not well formated</exception>
        public void ParseBasicAuthHeader(out string username, out string password) {
            string basicAuthHeader = RestServiceHttpUtils.TryGetRequestHeader(this.Request, AuthorizationPayloadKey);

            // No auth header, send challenge
            if (string.IsNullOrEmpty(basicAuthHeader)) {
                this.SetHeader("WWW-Authenticate", "Basic realm=\"" + this.Url.Request.RequestUri.Host + "\"");
                throw new ExposeRestException("Basic Authentication required.", HttpStatusCode.Unauthorized, /*isLoggable*/false);
            }

            if (!TryParseBasicToken(basicAuthHeader, out username, out password)) {
                throw new ExposeRestException($"{AuthorizationPayloadKey} header not well formed.", HttpStatusCode.BadRequest);
            }
        }

        private bool TryParseBasicToken(string basicAuthHeader, out String username, out String password) {
            username = null;
            password = null;

            try {
                // Incorrect string format (should be Basic base64(user:pass) )
                if (!basicAuthHeader.Trim().StartsWith("basic ", StringComparison.InvariantCultureIgnoreCase)) {
                    return false;
                }

                string[] headerParts = basicAuthHeader.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (headerParts.Length != 2) {
                    return false;
                }

                // according to the spec, it's ISO-8859-1
                // however, not all browsers use this. Some use UTF-8.
                string decodedAuth = Base64Decode(headerParts[1], Encoding.GetEncoding("ISO-8859-1"));
                if (!decodedAuth.Contains(':')) {
                    return false;
                }

                // according to RFC 2617, password can have : but username can't
                int splitIndex = decodedAuth.IndexOf(':');
                username = decodedAuth.Substring(0, splitIndex);
                password = decodedAuth.Substring(splitIndex + 1); //since : exists (check above), this will return "" if empty password

                return true;

            } catch {
                return false;
            }
        }

        public string Base64Decode(string base64EncodedData, Encoding encodingFormat) {
            if (encodingFormat == null) {
                encodingFormat = Encoding.UTF8;
            }
            return encodingFormat.GetString(Convert.FromBase64String(base64EncodedData));
        }

        public virtual bool IsSwaggerRequest(string currentRoute) {
            return false;
        }

        protected IHttpActionResult SwaggerJson(String serviceName) {
            this.ValidateRequestSecurity();
            var stream = GetType().Assembly.GetManifestResourceStream(serviceName + "Swagger.json");
            if (stream != null) {
                HttpResponseMessage responseMessage = new HttpResponseMessage(RestServiceHttpUtils.GetCurrentStatusCode());
                responseMessage.Content = new StreamContent(stream, (int)((stream.Length > 256 || stream.Length == 0) ? 256 : stream.Length));
                responseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                responseMessage.Content.Headers.ContentType.CharSet = Encoding.UTF8.WebName;
                return this.ResponseMessage(responseMessage);
            }
            
            return this.GetResponseResult("Can't find or open file '" + serviceName + "Swagger.json'.");
        }

        protected IHttpActionResult SwaggerDoc(String serviceName) {
            if (!this.Request.RequestUri.AbsoluteUri.EndsWith("/")) {
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.MovedPermanently);
                response.Headers.Location = new Uri(this.Request.RequestUri.AbsoluteUri + "/");
                return this.ResponseMessage(response);
            }
            
            this.ValidateRequestSecurity();
            var stream = GetType().Assembly.GetManifestResourceStream("swagger-doc.html");
            if (stream != null) {
                HttpResponseMessage responseMessage = new HttpResponseMessage(RestServiceHttpUtils.GetCurrentStatusCode());
                responseMessage.Content = new StreamContent(stream, (int)((stream.Length > 256 || stream.Length == 0) ? 256 : stream.Length));
                responseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/html");
                responseMessage.Content.Headers.ContentType.CharSet = Encoding.UTF8.WebName;
                return this.ResponseMessage(responseMessage);
            }

            return this.GetResponseResult("Can't find or open file 'swagger-doc.html'.");
        }

        // This needs to be ordered, subclasses first
        protected static readonly Pair<Type, string>[] BaseExceptionsTypesMapping = {
            Pair.Create(typeof(UserException), "UserException"),
            Pair.Create(typeof(InvalidLoginException), "InvalidLoginException"),
            Pair.Create(typeof(NotRegisteredException), "NotRegisteredException"),
            Pair.Create(typeof(SecurityException), "SecurityException"),
            Pair.Create(typeof(AbortActivityChangeException), "AbortActivityChangeException"),
            Pair.Create(typeof(ApplicationBackendUnavailableException), "ApplicationBackendUnavailableException"),
            Pair.Create(typeof(DataBaseException), "DataBaseException"),
            Pair.Create(typeof(System.Data.Common.DbException), "DataBaseException"),
            Pair.Create(typeof(CommunicationException), "CommunicationException"),
            Pair.Create(typeof(Exception), "ServerException"),
            Pair.Create(typeof(LicensingException), "LicensingException")
        };

        protected static readonly Type[] BaseExceptionsWithSpecificTypes = {
            typeof(UserException),
            typeof(NotRegisteredException),
            typeof(DataBaseException),
            typeof(System.Data.Common.DbException),
            typeof(Exception)
        };

        public class ExceptionPayload {
            // Used by Screen Services and Microservices

            [JsonProperty("name")]
            public string Name;

            [JsonProperty("specificType")]
            public string SpecificType;

            [JsonProperty("message")]
            public string Message;
            public ExceptionPayload(string type, string specificType, string message) {
                this.Name = type;
                this.SpecificType = specificType;
                this.Message = message;
            }

            public ExceptionPayload() {
                this.Name = "";
                this.SpecificType = "";
                this.Message = "";
            }
        }

        protected ExceptionPayload GetExceptionPayload(Exception ex) {
            if (ex == null) {
                return null;
            }

            var payload = new ExceptionPayload();
            payload.Message = ex.Message;

            var exType = ex.GetType();
            foreach (var mapping in BaseExceptionsTypesMapping) {
                if (mapping.First.IsAssignableFrom(exType)) {
                    payload.Name = mapping.Second;

                    if (BaseExceptionsWithSpecificTypes.Contains(mapping.First)) {
                        OSException osException = ex as OSException;
                        if (osException != null) {
                            payload.SpecificType = osException.GetUniqueName();
                        } else {
                            payload.SpecificType = exType.FullName;
                        }
                    }
                    break;
                }
            }

            if (payload.Name == null) {
                throw new InvalidOperationException("Failed to find exception mapping for " + exType.Name);
            }

            return payload;
        }

        protected ExposeRestException GetBadRequestException(string message) {
            return new ExposeRestException(message, HttpStatusCode.BadRequest);
        }

        protected ExposeRestException GetBadRequestException(List<string> messages) {
            return new ExposeRestException(messages, HttpStatusCode.BadRequest);
        }

        protected ExposeRestException GetBadRequestException(string message, Exception ex) {
            return new ExposeRestException(message, HttpStatusCode.BadRequest, ex);
        }
    }

}
