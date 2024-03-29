/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime.Authentication;
using OutSystems.Internal.Db;
using OutSystems.RESTService.ErrorHandling;
using OutSystems.RuntimeCommon;

namespace OutSystems.RESTService.Controllers {

    public abstract partial class ScreenServicesApiController : RestServiceApiController {

        public static readonly object GlobalScreenServicesInitializationLock = new object();
        private const string RequestTokenHeaderName = "OutSystems-Request-Token";
        private const string CallContextIdHeaderName = "OutSystems-ccid";
        private const string StopImmediatelyHeaderName = "OutSystems-dbg-stop";
        private const string RunToBreakpointHeaderName = "OutSystems-dbg-bkp";

        // Helper class to proxy the static methods of the Screen Services Implementations
        public abstract class BaseScreenControllerProxy : IScreenControllerProxy {
            public abstract CheckPermissionsIndex GetPermissionIndex();
            public abstract IEnumerable<IScreenControllerProxy> GetChildControllers();
            public abstract Type GetControllerType();
            public abstract void EnsureInitialized();
            public abstract Dictionary<string, BinaryContentUtils.DbBinaryConfig> GetDbBinaryConfigs();
        }

        public static Dictionary<string, BinaryContentUtils.DbBinaryConfig> AllDbBinaryConfigs = new Dictionary<string, BinaryContentUtils.DbBinaryConfig>();

        public static void SetDatabaseBinaries(Dictionary<string, BinaryContentUtils.DbBinaryConfig> binaries) {
            // The call to this method could be triggered multiple times and by different threads,
            // since it is being handled by the ASP.NET framework
            lock (typeof(ScreenServicesApiController)) {
                AllDbBinaryConfigs.Clear();
                AllDbBinaryConfigs.AddRange(binaries);
            }
        }

        public ScreenServicesApiController() : base() { }

        protected static void InitPermissionIndexes(CheckPermissionsIndex index, IEnumerable<IScreenControllerProxy> childControllers) {
            foreach (var childControllerProxy in childControllers) {
                childControllerProxy.EnsureInitialized();
                index.AddChildIndex(childControllerProxy.GetPermissionIndex());
            }
        }

        public static IScreenControllerProxy TryGetControllerProxy(Type controllerType) {
            if (controllerType != null && (typeof(ScreenServicesApiController)).IsAssignableFrom(controllerType)) {
                try {
                    return (IScreenControllerProxy)controllerType.GetField("ProxyInstance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public).GetValue(null);
                } catch (Exception ex) {
                    OSTrace.Error("Unable to load controller proxy for " + controllerType.FullName, ex);
                }
            }
            return null;
        }

        protected static void SafeAddChildController(IScreenControllerProxy controllerProxy, HashSet<IScreenControllerProxy> childControllers) {
            childControllers.Add(controllerProxy);
        }

        protected static void SafeAddChildController(string typeStr, string assemblyName, HashSet<IScreenControllerProxy> childControllers) {
            try {
                var controllerType = Type.GetType(string.Format("{0},{1}", typeStr, assemblyName), /*throwOnError*/true);
                var controllerProxy = TryGetControllerProxy(controllerType);
                if (controllerProxy != null) {
                    SafeAddChildController(controllerProxy, childControllers);
                } else {
                    OSTrace.Error("Unable to load controller proxy for " + typeStr);
                }
            } catch (Exception ex) {
                OSTrace.Error("Unable to load controller for " + typeStr, ex);
            }
        }

        protected JsonSerializer JsonSerializer {
            get {
                var serializer = JsonSerializer.CreateDefault(JsonMediaTypeFormater.SerializerSettings);
                serializer.CheckAdditionalContent = false;
                return serializer;
            }
        }

        protected IHttpActionResult GetScreenServiceResult(HttpStatusCode status, ExceptionPayload exception) {
            return GetScreenServiceResult(status, null, null, exception, null, null, null);
        }

        [Obsolete("Use the methods that receive the HeContext instead")]
        protected IHttpActionResult GetScreenServiceResult(object dataPayload, Payload.ResponseVersionInfo versionInfo, MobileLoginInfoEndpoint loginEndpoint, LoginInfo loginInfo, Func<string> rolesInfo) {
            return GetScreenServiceResult(HttpStatusCode.OK, dataPayload, versionInfo, /*exception*/null, loginEndpoint, loginInfo, rolesInfo);
        }

        protected IHttpActionResult GetScreenServiceResult(object dataPayload, Payload.ResponseVersionInfo versionInfo, MobileLoginInfoEndpoint loginEndpoint, HeContext context) {
            return GetScreenServiceResult(HttpStatusCode.OK, dataPayload, versionInfo, /*exception*/null, loginEndpoint, context);
        }

        protected IHttpActionResult GetScreenServiceResult(HttpStatusCode status, object dataPayload, Payload.ResponseVersionInfo versionInfo, ExceptionPayload exception, MobileLoginInfoEndpoint loginEndpoint, HeContext context) {
            var hasNewRuntimeSession = context != null && context.Session != null && context.Session.HasNewRuntimeSessionStorage;
            return GetScreenServiceResult(status, dataPayload, versionInfo, exception, loginEndpoint, hasNewRuntimeSession ? context.Session.NewRuntimeLoginInfo : null, hasNewRuntimeSession ? context.Session.GetRolesInfo() : null);
        }

        // TODO JMR Remove this method and merge it with the above overload when the Obsolete overload is removed
        private IHttpActionResult GetScreenServiceResult(HttpStatusCode status, object dataPayload, Payload.ResponseVersionInfo versionInfo, ExceptionPayload exception, MobileLoginInfoEndpoint loginEndpoint, LoginInfo loginInfo, Func<string> rolesInfo) {
            var responseMessage = new HttpResponseMessage(status);

            string rolesInfoserialized = null;
            if (loginEndpoint != null && loginInfo != null) {
                if (rolesInfo != null) {
                    rolesInfoserialized = loginInfo.UpdateRolesHashAndCalculateRolesInfo(rolesInfo());
                }
                loginEndpoint.WriteLoginInfoToResponse(loginInfo);
            }

            responseMessage.Content = new ObjectContent(typeof(Payload.ResponsePayload),
                new Payload.ResponsePayload(versionInfo, dataPayload, exception, rolesInfoserialized), JsonMediaTypeFormater);

            RestServiceHttpUtils.AddNoCacheHeaders(responseMessage);

            if (DebuggerHelper.IsRunning) {
                if (DebuggerHelper.StopImmediately) {
                    RestServiceHttpUtils.AddCustomHeader(responseMessage, StopImmediatelyHeaderName, DebuggerHelper.StopImmediately.ToString());
                } else if (DebuggerHelper.RunToBreakpoint != null) {
                    RestServiceHttpUtils.AddCustomHeader(responseMessage, RunToBreakpointHeaderName, DebuggerHelper.RunToBreakpoint.ToString(true));
                }
            }

            return ResponseMessage(responseMessage);
        }

        protected delegate object EndpointImplementationDelegate(HeContext heContext, string screenName, JObject screenModel, JObject inputParameters);

        protected delegate HttpResponseMessage BinaryEndpointImplementationDelegate(HeContext heContext, string binaryDetails, HttpRequestMessage request, HttpResponseMessage response);

        private void SetCurrentStateFromHeaders() {
            if (DebuggerHelper.IsRunning) {
                IEnumerable<string> auxEnum;
                if (Request.Headers.TryGetValues(RequestTokenHeaderName, out auxEnum)) {
                    DebuggerHelper.SetCurrentRequestClientToken(auxEnum.FirstOrDefault());
                }

                if (Request.Headers.TryGetValues(CallContextIdHeaderName, out auxEnum)) {
                    DebuggerHelper.SetCurrentCallContextId(auxEnum.FirstOrDefault());
                }

                if (Request.Headers.TryGetValues(StopImmediatelyHeaderName, out auxEnum)) {
                    DebuggerHelper.SetCurrentStopImmediately(auxEnum.FirstOrDefault());
                } else if (Request.Headers.TryGetValues(RunToBreakpointHeaderName, out auxEnum)) {
                    DebuggerHelper.SetCurrentRunToBreakpoint(auxEnum.FirstOrDefault());
                }
            }
        }

        private MobileLoginInfoEndpoint ValidateRequestLogin(AppInfo appInfo, HeContext context) {
            return ValidateRequestLogin(appInfo, context, false);
        }

        private MobileLoginInfoEndpoint ValidateRequestLogin(AppInfo appInfo, HeContext context, bool ignoreCSRFToken) {
            MobileLoginInfoEndpoint loginEndpoint = new MobileLoginInfoEndpoint(appInfo, appInfo.GetMobileLoginConfigurations());
            try {
                var login = loginEndpoint.ReadLoginInfoFromRequest();
                login.Validate(ignoreCSRFToken);
                loginEndpoint.Login(login, context.Session);
            } catch (InvalidLoginException ex) {
                throw new ExposeRestException("Invalid Login", HttpStatusCode.Forbidden, ex);
            }
            return loginEndpoint;
        }

        protected IHttpActionResult endpoint_binary(string binaryDetailsCipher) {

            AppInfo appInfo = null;
            HeContext heContext = null;

            try {
                HttpResponseMessage response = new HttpResponseMessage();
                appInfo = AppInfo.GetAppInfo();
                heContext = appInfo.OsContext;

                if (appInfo == null || !appInfo.IsApplicationEnabled) {
                    response.StatusCode = HttpStatusCode.ServiceUnavailable;
                    return ResponseMessage(response);
                }

                ValidateRequestSecurity();

                ValidateRequestLogin(appInfo, heContext, true);

                int userId = heContext.Session.UserId;
                byte[] content;
                var statusCode = (HttpStatusCode)BinaryContentUtils.GetBinaryContent(ScreenServicesApiController.AllDbBinaryConfigs, binaryDetailsCipher, userId, out content);
                response.StatusCode = statusCode;

                if (statusCode == HttpStatusCode.OK) {
                    string mimeType = RuntimePlatformUtils.GetMIMEType(content, out bool isValidImage);
                    if (!isValidImage && RuntimePlatformSettings.Security.EnforceValidTypesOnBinaryEndpoints.GetValue()) {
                        response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    }

                    response.Headers.CacheControl = new CacheControlHeaderValue() {
                        Private = true,
                        MaxAge = TimeSpan.FromDays(7),
                    };

                    response.Headers.AcceptRanges.Clear();
                    response.Headers.AcceptRanges.Add("none");

                    response.Content = new ByteArrayContent(content);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
                }

                return ResponseMessage(response);
            } catch (Exception ex) {
                DatabaseAccess.FreeupResources(false);

                var licensingException = ex as LicensingException;
                if (licensingException != null) {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable));
                }

                ErrorLog.LogApplicationError(ex, heContext, "");

                HttpStatusCode errorStatusCode = HttpStatusCode.InternalServerError;
                var exposeRestException = ex as ExposeRestException;
                if (exposeRestException != null) {
                    errorStatusCode = exposeRestException.StatusCode;
                }

                return ResponseMessage(new HttpResponseMessage(errorStatusCode));
            }
        }

        protected IHttpActionResult endpoint(string input, string endpointName, string apiVersion, EndpointImplementationDelegate implementation) {

            AppInfo appInfo = null;
            HeContext heContext = null;
            MobileLoginInfoEndpoint loginEndpoint = null;
            Payload.ResponseVersionInfo responseVersionInfo = null;
            try {

                appInfo = AppInfo.GetAppInfo();
                heContext = appInfo.OsContext;

                if (appInfo == null || !appInfo.IsApplicationEnabled) {
                    return GetScreenServiceResult
                        (HttpStatusCode.ServiceUnavailable, 
                        GetExceptionPayload(new ApplicationBackendUnavailableException(ApplicationNotEnabledMessage)));
                }

                ValidateRequestSecurity();

                heContext.Session.EnableNewRuntimeSessionStorage();
                loginEndpoint = ValidateRequestLogin(appInfo, heContext);

                Payload.RequestPayload requestPayload;
                try {
                    requestPayload = JsonConvert.DeserializeObject<Payload.RequestPayload>(input, BehaviorsConfiguration.SerializerSettings);
                } catch (Exception ex) {
                    throw GetBadRequestException("Failed to parse JSON request content.", ex);
                }

                if (requestPayload.VersionInfo == null) {
                    throw GetBadRequestException("Missing Version Info in the request content.");
                }

                responseVersionInfo = new Payload.ResponseVersionInfo(requestPayload.VersionInfo, RunningInfo.ESpaceVersionToken, apiVersion);

                if (responseVersionInfo.HasApiVersionChanged) {
                    return GetScreenServiceResult(new Payload.EmptyDataPayload(), responseVersionInfo, loginEndpoint, heContext);
                } else {
                    SetCurrentStateFromHeaders();
                    object dataResponsePayload = implementation(heContext, requestPayload.ViewName, requestPayload.ScreenData, requestPayload.InputParameters);
                    return GetScreenServiceResult(dataResponsePayload, responseVersionInfo, loginEndpoint, heContext);
                }
            } catch (Exception ex) {
                DatabaseAccess.FreeupResources(false);

                var licensingException = ex as LicensingException;
                if (licensingException != null) {
                    // Already logged
                    return GetScreenServiceResult(
                        HttpStatusCode.ServiceUnavailable, 
                        GetExceptionPayload(new ApplicationBackendUnavailableException(ApplicationNotEnabledMessage)));
                }


                HttpStatusCode statusCode = HttpStatusCode.OK;
                var exposeRestException = ex as ExposeRestException;
                if (exposeRestException != null) {
                    statusCode = exposeRestException.StatusCode;
                }

                // Currently for security reasons we log it here and don't let the handler in client side decide. This can generate many "non-errors" to be logged if exceptions are used for flow control
                string errorLogId = ErrorLog.LogApplicationError(ex, heContext, "");
                var loggingContext = LoggingHelper.GetLoggingContext();
                if (loggingContext != null) {
                    loggingContext.ErrorLogId = errorLogId;
                }

                return GetScreenServiceResult(statusCode, new Payload.EmptyDataPayload(), responseVersionInfo, GetExceptionPayload(ex), loginEndpoint, heContext);
            }
        }

        protected static void SetRequesterLoggingInfo(HeContext heContext) {
            var loggingContext = LoggingHelper.GetLoggingContext();
            if (loggingContext != null && loggingContext.RequesterUserId == 0 && heContext != null && heContext.Session != null && heContext.Session.NewRuntimeLoginInfo != null) {
                loggingContext.RequesterUserId = heContext.Session.NewRuntimeLoginInfo.UserId;
                loggingContext.RequesterUsername = heContext.Session.NewRuntimeLoginInfo.Username;
                loggingContext.RequesterLoginId = heContext.Session.NewRuntimeLoginInfo.LoginId;
            }
        }
    }
}