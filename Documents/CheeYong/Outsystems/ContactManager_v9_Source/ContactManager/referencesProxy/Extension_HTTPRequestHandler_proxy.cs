﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

// Proxy for reference Extension with name HTTPRequestHandler and key qaSKXzrgQkqvSJbBokJbcw
using System;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Runtime.Serialization;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using System.Collections.Generic;
using System.Xml;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Log;
using System.Web.UI;
using OutSystems.HubEdition.WebWidgets;
using OutSystems.HubEdition.RuntimePlatform.Web;
using ssContactManager;
namespace ssContactManager {
	/// <summary>
	/// Class: RssExtensionHTTPRequestHandler
	/// </summary>
	public partial class RssExtensionHTTPRequestHandler {
		/// <summary>
		/// Extension Variable: issHTTPRequestHandler
		/// </summary>
		protected static OutSystems.NssHTTPRequestHandler.IssHTTPRequestHandler issHTTPRequestHandler = (OutSystems.NssHTTPRequestHandler.IssHTTPRequestHandler) new OutSystems.NssHTTPRequestHandler.CssHTTPRequestHandler();
		protected static int _maxExtensionLogsPerRequest = OutSystems.HubEdition.RuntimePlatform.RuntimePlatformSettings.Misc.MaxLogsPerRequestExtension.GetValue();
		public static void MssGetURLMethod(HeContext heContext, out string outParamMethod) {
			DateTime startTime = DateTime.Now;
			String errorLogId = "";
			try {
				issHTTPRequestHandler.MssGetURLMethod(out outParamMethod);
			} catch (Exception ex) {
				errorLogId = ErrorLog.LogApplicationError(ex, heContext, "Extension method execution: HTTPRequestHandler.GetURLMethod");
				throw ex;
			} finally {
				if (errorLogId != string.Empty || (!heContext.AppInfo.SelectiveLoggingEnabled ||
				(heContext.AppInfo.ExtensionProperties.AllowLogging("b1ef216b-d67f-454e-9f01-a7f0274608d6") && heContext.AppInfo.Properties.AllowLogging))) {

					int extLogCount = heContext.ExtensionLogCount;
					if (extLogCount == _maxExtensionLogsPerRequest) {
						// issue warning
						GeneralLog.StaticWrite(
						DateTime.Now, heContext.Session.SessionID, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
						heContext.Session.UserId, "The maximum number (" + _maxExtensionLogsPerRequest + ") of allowed Extension Log entries per request has been exceeded. No more entries will be logged in this request.",
						 "WARNING", "SLOWEXTENSION", "");
						heContext.ExtensionLogCount = extLogCount + 1;
					} else if (extLogCount < _maxExtensionLogsPerRequest) {
						DateTime instant = DateTime.Now;
						int executionDuration = Convert.ToInt32(DateTime.Now.Subtract(startTime).TotalMilliseconds);
						ExtensionLog.StaticWrite(heContext.AppInfo, heContext.Session,
						instant, executionDuration, "GetURLMethod", errorLogId, 13, "HTTPRequestHandler");
						heContext.ExtensionLogCount = extLogCount + 1;
						RequestTracer reqTracer = heContext.RequestTracer;
						if (reqTracer != null) {
							reqTracer.RegisterExtensionExecuted("6037fad1-7ab6-41b9-9e23-614acaba5fd8", "GetURLMethod", "794c445f-f27d-4f61-b47a-0da71440df68", "ContactManager", executionDuration, instant); 
						}
					}
				}
				RuntimePlatformUtils.LogSlowExtensionCall(startTime, "HTTPRequestHandler.GetURLMethod");
			}
		}


		public static void MssIsAjaxRequest(HeContext heContext, out bool outParamIsAjaxRequest) {
			DateTime startTime = DateTime.Now;
			String errorLogId = "";
			try {
				issHTTPRequestHandler.MssIsAjaxRequest(out outParamIsAjaxRequest);
			} catch (Exception ex) {
				errorLogId = ErrorLog.LogApplicationError(ex, heContext, "Extension method execution: HTTPRequestHandler.IsAjaxRequest");
				throw ex;
			} finally {
				if (errorLogId != string.Empty || (!heContext.AppInfo.SelectiveLoggingEnabled ||
				(heContext.AppInfo.ExtensionProperties.AllowLogging("b1ef216b-d67f-454e-9f01-a7f0274608d6") && heContext.AppInfo.Properties.AllowLogging))) {

					int extLogCount = heContext.ExtensionLogCount;
					if (extLogCount == _maxExtensionLogsPerRequest) {
						// issue warning
						GeneralLog.StaticWrite(
						DateTime.Now, heContext.Session.SessionID, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
						heContext.Session.UserId, "The maximum number (" + _maxExtensionLogsPerRequest + ") of allowed Extension Log entries per request has been exceeded. No more entries will be logged in this request.",
						 "WARNING", "SLOWEXTENSION", "");
						heContext.ExtensionLogCount = extLogCount + 1;
					} else if (extLogCount < _maxExtensionLogsPerRequest) {
						DateTime instant = DateTime.Now;
						int executionDuration = Convert.ToInt32(DateTime.Now.Subtract(startTime).TotalMilliseconds);
						ExtensionLog.StaticWrite(heContext.AppInfo, heContext.Session,
						instant, executionDuration, "IsAjaxRequest", errorLogId, 13, "HTTPRequestHandler");
						heContext.ExtensionLogCount = extLogCount + 1;
						RequestTracer reqTracer = heContext.RequestTracer;
						if (reqTracer != null) {
							reqTracer.RegisterExtensionExecuted("42593b4a-86fc-4724-8a21-f53e64e0e175", "IsAjaxRequest", "794c445f-f27d-4f61-b47a-0da71440df68", "ContactManager", executionDuration, instant); 
						}
					}
				}
				RuntimePlatformUtils.LogSlowExtensionCall(startTime, "HTTPRequestHandler.IsAjaxRequest");
			}
		}


		public static void MssSetCookie(HeContext heContext, string inParamCookieName, string inParamCookieValue, int inParamCookieExpirationSpan, string inParamCookiePath, string inParamCookieDomain) {
			DateTime startTime = DateTime.Now;
			String errorLogId = "";
			try {
				issHTTPRequestHandler.MssSetCookie(inParamCookieName, inParamCookieValue, inParamCookieExpirationSpan, inParamCookiePath, inParamCookieDomain);
			} catch (Exception ex) {
				errorLogId = ErrorLog.LogApplicationError(ex, heContext, "Extension method execution: HTTPRequestHandler.SetCookie");
				throw ex;
			} finally {
				if (errorLogId != string.Empty || (!heContext.AppInfo.SelectiveLoggingEnabled ||
				(heContext.AppInfo.ExtensionProperties.AllowLogging("b1ef216b-d67f-454e-9f01-a7f0274608d6") && heContext.AppInfo.Properties.AllowLogging))) {

					int extLogCount = heContext.ExtensionLogCount;
					if (extLogCount == _maxExtensionLogsPerRequest) {
						// issue warning
						GeneralLog.StaticWrite(
						DateTime.Now, heContext.Session.SessionID, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
						heContext.Session.UserId, "The maximum number (" + _maxExtensionLogsPerRequest + ") of allowed Extension Log entries per request has been exceeded. No more entries will be logged in this request.",
						 "WARNING", "SLOWEXTENSION", "");
						heContext.ExtensionLogCount = extLogCount + 1;
					} else if (extLogCount < _maxExtensionLogsPerRequest) {
						DateTime instant = DateTime.Now;
						int executionDuration = Convert.ToInt32(DateTime.Now.Subtract(startTime).TotalMilliseconds);
						ExtensionLog.StaticWrite(heContext.AppInfo, heContext.Session,
						instant, executionDuration, "SetCookie", errorLogId, 13, "HTTPRequestHandler");
						heContext.ExtensionLogCount = extLogCount + 1;
						RequestTracer reqTracer = heContext.RequestTracer;
						if (reqTracer != null) {
							reqTracer.RegisterExtensionExecuted("a6fb144c-3441-4bdc-976e-903cdeaeab28", "SetCookie", "794c445f-f27d-4f61-b47a-0da71440df68", "ContactManager", executionDuration, instant); 
						}
					}
				}
				RuntimePlatformUtils.LogSlowExtensionCall(startTime, "HTTPRequestHandler.SetCookie");
			}
		}


		public static void MssRunJavaScript(HeContext heContext, string inParamScript) {
			DateTime startTime = DateTime.Now;
			String errorLogId = "";
			try {
				issHTTPRequestHandler.MssRunJavaScript(inParamScript);
			} catch (Exception ex) {
				errorLogId = ErrorLog.LogApplicationError(ex, heContext, "Extension method execution: HTTPRequestHandler.RunJavaScript");
				throw ex;
			} finally {
				if (errorLogId != string.Empty || (!heContext.AppInfo.SelectiveLoggingEnabled ||
				(heContext.AppInfo.ExtensionProperties.AllowLogging("b1ef216b-d67f-454e-9f01-a7f0274608d6") && heContext.AppInfo.Properties.AllowLogging))) {

					int extLogCount = heContext.ExtensionLogCount;
					if (extLogCount == _maxExtensionLogsPerRequest) {
						// issue warning
						GeneralLog.StaticWrite(
						DateTime.Now, heContext.Session.SessionID, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
						heContext.Session.UserId, "The maximum number (" + _maxExtensionLogsPerRequest + ") of allowed Extension Log entries per request has been exceeded. No more entries will be logged in this request.",
						 "WARNING", "SLOWEXTENSION", "");
						heContext.ExtensionLogCount = extLogCount + 1;
					} else if (extLogCount < _maxExtensionLogsPerRequest) {
						DateTime instant = DateTime.Now;
						int executionDuration = Convert.ToInt32(DateTime.Now.Subtract(startTime).TotalMilliseconds);
						ExtensionLog.StaticWrite(heContext.AppInfo, heContext.Session,
						instant, executionDuration, "RunJavaScript", errorLogId, 13, "HTTPRequestHandler");
						heContext.ExtensionLogCount = extLogCount + 1;
						RequestTracer reqTracer = heContext.RequestTracer;
						if (reqTracer != null) {
							reqTracer.RegisterExtensionExecuted("e0ca1324-2a9a-4df4-8d44-bbeb9a2011ef", "RunJavaScript", "794c445f-f27d-4f61-b47a-0da71440df68", "ContactManager", executionDuration, instant); 
						}
					}
				}
				RuntimePlatformUtils.LogSlowExtensionCall(startTime, "HTTPRequestHandler.RunJavaScript");
			}
		}


		public static void MssGetPageName(HeContext heContext, out string outParamPageName) {
			DateTime startTime = DateTime.Now;
			String errorLogId = "";
			try {
				issHTTPRequestHandler.MssGetPageName(out outParamPageName);
			} catch (Exception ex) {
				errorLogId = ErrorLog.LogApplicationError(ex, heContext, "Extension method execution: HTTPRequestHandler.GetPageName");
				throw ex;
			} finally {
				if (errorLogId != string.Empty || (!heContext.AppInfo.SelectiveLoggingEnabled ||
				(heContext.AppInfo.ExtensionProperties.AllowLogging("b1ef216b-d67f-454e-9f01-a7f0274608d6") && heContext.AppInfo.Properties.AllowLogging))) {

					int extLogCount = heContext.ExtensionLogCount;
					if (extLogCount == _maxExtensionLogsPerRequest) {
						// issue warning
						GeneralLog.StaticWrite(
						DateTime.Now, heContext.Session.SessionID, heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
						heContext.Session.UserId, "The maximum number (" + _maxExtensionLogsPerRequest + ") of allowed Extension Log entries per request has been exceeded. No more entries will be logged in this request.",
						 "WARNING", "SLOWEXTENSION", "");
						heContext.ExtensionLogCount = extLogCount + 1;
					} else if (extLogCount < _maxExtensionLogsPerRequest) {
						DateTime instant = DateTime.Now;
						int executionDuration = Convert.ToInt32(DateTime.Now.Subtract(startTime).TotalMilliseconds);
						ExtensionLog.StaticWrite(heContext.AppInfo, heContext.Session,
						instant, executionDuration, "GetPageName", errorLogId, 13, "HTTPRequestHandler");
						heContext.ExtensionLogCount = extLogCount + 1;
						RequestTracer reqTracer = heContext.RequestTracer;
						if (reqTracer != null) {
							reqTracer.RegisterExtensionExecuted("dad7de67-1a03-427f-87ab-b9f2ed57f688", "GetPageName", "794c445f-f27d-4f61-b47a-0da71440df68", "ContactManager", executionDuration, instant); 
						}
					}
				}
				RuntimePlatformUtils.LogSlowExtensionCall(startTime, "HTTPRequestHandler.GetPageName");
			}
		}




		public class Factory {
		}
		public class DefaultValues {
		}
	}
}
