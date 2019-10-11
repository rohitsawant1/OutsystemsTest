/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.RESTService.Filters;

namespace OutSystems.RESTService.ErrorHandling {

    public class ExposeRestExceptionFilter : ExceptionFilterAttribute {

        public static readonly ExposeRestExceptionFilter Instance = new ExposeRestExceptionFilter();

        private void BuildErrorResponse(HttpActionExecutedContext actionExecutedContext) {
            var errors = new List<string>();
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            if (actionExecutedContext.Exception is HttpResponseException) {
                HttpResponseException httpException = (HttpResponseException)actionExecutedContext.Exception;
                var httpError = httpException.Response.Content as ObjectContent<HttpError>;
                if (httpError != null) {
                    errors.Add(((HttpError)httpError.Value).Message);
                } else {
                    errors.Add(httpException.Response.ReasonPhrase);
                }
                statusCode = httpException.Response.StatusCode;
            } else if (actionExecutedContext.Exception is ExposeRestException exposeRestException) {
                errors = exposeRestException.Errors;
                statusCode = exposeRestException.StatusCode;
            } else {
                errors.Add(actionExecutedContext.Exception.Message);
                statusCode = HttpStatusCode.InternalServerError;
            }

            actionExecutedContext.Response = new HttpResponseMessage(statusCode);
            actionExecutedContext.Response.Content = new ObjectContent(
                  typeof(ErrorResponse),
                  new ErrorResponse(errors, (int)statusCode),
                  new JsonMediaTypeFormatter()
            );
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            BuildErrorResponse(actionExecutedContext);

            bool isLoggable = true;
            Exception baseEx = actionExecutedContext.Exception;
            ExposeRestException restException = baseEx as ExposeRestException;
            if (restException != null) {
                baseEx = restException.InnerException ?? baseEx; // use the base Exception so that we don't get the async stacks added in the trace
                if (!restException.IsLoggable) {
                    isLoggable = false;
                    var loggingContext = LoggingHelper.GetLoggingContext();
                    if (loggingContext != null) { 
                        loggingContext.LogRequest = isLoggable;
                    }
                }
            }

            if (isLoggable) {
                // Create log as soon as possible, or it will be done without the errorLogId inside the OnActionExecuted (since that is the normal logging place)
                string errorLogId = ErrorLog.LogApplicationError(baseEx, AppInfo.GetAppInfo().OsContext, "REST (Expose)");
                LoggingHelper.LogResponse(actionExecutedContext, errorLogId);
            }

            try {
                if (actionExecutedContext.ActionContext.ControllerContext != null) {
                    var controller = actionExecutedContext.ActionContext.ControllerContext.Controller;
                    if (controller != null) {
                        var responseFilters = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<OnResponseFilter>();
                        
                        foreach (var filter in responseFilters) {
                            filter.OnActionExecuted(actionExecutedContext);
                        }
                    }
                }
            } catch (Exception exceptionInsideExceptionHandler) {
                ExposeRestException restExceptionInsideExceptionHandler = exceptionInsideExceptionHandler as ExposeRestException;
                if (restExceptionInsideExceptionHandler != null) {
                    // use the base Exception so that we don't get the async stacks added in the trace
                    exceptionInsideExceptionHandler = restExceptionInsideExceptionHandler.InnerException ?? exceptionInsideExceptionHandler;
                }
                
                // lets log the second error as well, just so it doesn't get lost. The one associated with the Integration Log will be the original one
                ErrorLog.LogApplicationError(exceptionInsideExceptionHandler, AppInfo.GetAppInfo().OsContext, "REST (Expose)");

                // If an exception occurs in the ResponseFilter, build a new error response and don't let it "bubble up"
                // The new exception will override the old one as the user might change the error message
                actionExecutedContext.Exception = restExceptionInsideExceptionHandler;
                BuildErrorResponse(actionExecutedContext);
            }
        }
    }
}
