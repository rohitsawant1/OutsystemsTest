﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using OutSystems.ObjectKeys;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Log;

namespace ssContactManager {
	public class TimerHandler : System.Web.Services.WebService {
		public TimerHandler() {
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
		}

		/// Clean up any resources being used.
		protected override void Dispose(bool disposing ) {
			if (disposing && components != null) {
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod()]
		public int ExecuteTimer(string ssKey, int timeout, int tenantId) {
            ObjectKey timerKey = ObjectKey.Parse(ssKey);

			if (HttpContext.Current == null) {
				GeneralLog.StaticWrite(DateTime.Now, "", 0, 0, 0, "ExecuteTimer Called (Context is null)", GeneralLogType.WARNING.ToString(), "", "");
			} else {
				HeContext context = Global.App.OsContext;

				// Check if the request is from a valid IP
				if (!NetworkInterfaceUtils.IsLoopbackAddress(HttpContext.Current.Request.UserHostAddress)) {
                    ErrorLog.LogApplicationError("Access to timerhandler with invalid IP: " + HttpContext.Current.Request.UserHostAddress, 
						"The timer handler can only be accessed by the 127.0.0.1 IP", context, "ExecuteTimer");		
					return 0;
				}
                if (tenantId > 0) {
                    context.Session.TenantId = tenantId;
                }
				bool processedOk = false;
				try {
					if (timerKey == TimerBootstrap.TimerKey) {
TimerBootstrap.Execute( context, timeout);
} else  {
					    GeneralLog.StaticWrite(DateTime.Now, context.Session.SessionID, Global.eSpaceId,
						    context.AppInfo.Tenant.Id,
                            context.Session.UserId, "Timer " + ssKey + " isn't mapped",
						    GeneralLogType.INFO.ToString(), "", "");
					}
					processedOk = true;
				} finally {
					DatabaseAccess.FreeupResources(processedOk);
				}
			}
			return 1;
		}
	}
}
