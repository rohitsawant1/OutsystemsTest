﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Email;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;
using OutSystems.HubEdition.WebWidgets;
using OutSystems.RuntimeCommon;
using OutSystems.ObjectKeys;
using System.Resources;


namespace ssContactManager.Flows.FlowRichWidgets {

	public class ExceptionHandler {

		private readonly bool isEmailScreen;
		private readonly OSPage page;

		public ExceptionHandler(OSPage page, bool isEmailScreen) {
			this.page = page;
			this.isEmailScreen = isEmailScreen;
		}

		private OSPage Page {
			get {
				return page; 
			}
		}

		private HttpServerUtility Server {
			get {
				return Page.Server; 
			}
		}

		[Obsolete("Use GetClientRedirectionUrlBasePath instead")]
		private string GetRedirectionProtocol(bool destinationIsSecure) {
			return Page.GetRedirectionProtocol(destinationIsSecure);
		}

		private string GetClientRedirectionUrlBasePath(bool destinationIsSecure, string urlPath, string defaultPort = "", string securePort = "") {
			return Page.GetClientRedirectionUrlBasePath(destinationIsSecure, urlPath, defaultPort, securePort);
		}

		private HttpRequest Request {
			get {
				return Page.Request; 
			}
		}

		private HttpResponse Response {
			get {
				return Page.Response; 
			}
		}

		private HttpSessionState Session {
			get {
				return Page.Session; 
			}
		}

		private void FinishRequest() {
			((OSPageViewState) Page).FinishRequest();
		}

		public bool HandleException() {
			LocalState dummy = null;
			return HandleException(ref dummy);
		}



		public bool HandleException(ref LocalState flowState) {
			Exception ex = Server.GetLastError();
			if (ex is LicensingException) {
				return true;
			}

			HeContext heContext = Global.App.OsContext;
			string errorKey = "ContactManager.RichWidgets" + ex.GetType().ToString();
			if (heContext.VisitedExceptionHandlerFlows.Contains(errorKey)) {
				return false;
			}
			heContext.VisitedExceptionHandlerFlows.Add(errorKey);

			if (heContext.Session.EntryPoint == null) {
				heContext.Session.EntryPoint = HeContext.UnknownEntryPoint;
			}
			while (ex != null) {
				if (ex is System.Threading.ThreadAbortException) {
					return true;
				}
				ex = ex.InnerException;
			}
			ex = Server.GetLastError();
			if (ex is System.Reflection.TargetInvocationException) {
				ex = ex.InnerException;
			}

			heContext.Session["ExceptionMessage"] = ex.Message;

			heContext.Session[BuiltInFunction.ExceptionURLSessionName] = BuiltInFunction.GetBookmarkableURL();
			Response.Clear();

			if (isEmailScreen) {
				ErrorLog.LogApplicationError(ex, heContext, "");
				return true;
			}

			if (heContext.CanUseCustomErrorHandler(ex)) {
				return new ssContactManager.Flows.FlowCommon.ExceptionHandler(page, isEmailScreen).HandleException();

			}
			DatabaseAccess.FreeupResources(false);

			Server.Transfer("_WebErrorPage.aspx");
			return true;
		}
	}

}