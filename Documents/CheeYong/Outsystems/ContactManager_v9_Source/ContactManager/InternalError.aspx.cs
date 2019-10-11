﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Internal;
using System.Collections.Generic;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.HubEdition.RuntimePlatform.Email;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;
using OutSystems.HubEdition.WebWidgets;
using OutSystems.HubEdition.WebWidgets.Behaviors;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;
using OutSystems.ObjectKeys;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Caching;
using System.Text;
using System.Resources;

namespace ssContactManager.Flows.FlowCommon {

	public class ScrnInternalError: OSPageViewStateCompressed, IWebScreen, INegotiateTabIndexes, IBookmarkableURL {


		public ScrnInternalError(): base(ContactManager_Properties.QuirksMode) {
		}


		/// <summary>
		/// Variable wt_WebBlockInstance8
		/// </summary>
		protected ssContactManager.Flows.FlowCommon.WBlkLayout_Normal wt_WebBlockInstance8;
		protected OutSystems.HubEdition.WebWidgets.Container wt_Container14;
		/// <summary>
		/// Variable "True" if the Widget wt_If3
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If3T;

		/// <summary>
		/// Variable "True" if the Widget wt_If3
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If3F;
		/// <summary>
		/// Variable (wtlnkPopup) with Link component
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.LinkButton wtlnkPopup;


		List<object> explicitChangedVariables = new List<object>();

		protected override void GetBlocksCss(TextWriter writer, bool inline, HashSet<string> visited) {
			ssContactManager.Flows.FlowCommon.WBlkLayout_Normal.GetCss(writer, inline, visited);
			ssContactManager.Flows.FlowCommon.WBlkMenu.GetCss(writer, inline, visited);
			ssContactManager.Flows.FlowRichWidgets.WBlkRemovePopups.GetCss(writer, inline, visited);

		}

		protected override void GetWidgetsCss(TextWriter writer, bool inline, HashSet<string> visited) {

		}







		protected override string GetInlineStyleSheetInclude() {
			throw new InvalidOperationException();
		}





		protected override bool PageAllowsCallbacks() {
			return true;
		}


		protected string GetRequestInfoJavaScript() {
			return GetRequestInfoJavaScript("5iM2jMromEyrgtXKm6ia+g", "InternalError");
		}

		protected string GetVisitCode() {
			SessionInfo session = AppInfo.GetAppInfo().OsContext.Session;
			if (session["osIsNewVisit"] != null && ((bool) session["osIsNewVisit"])
			// && !NetworkInterfaceUtils.IsLoopbackAddress(Request.UserHostAddress)
			&& RuntimePlatformUtils.IsValidRequestForVisit()) {
				return "<script type=\"text/javascript\">outsystems.internal.$.get(\"/ContactManager/_status.aspx\")</script>";
			}
			return "";
		}

		public string GetCallbackDebug() {
			if (Request.HttpMethod == "GET" && Request.QueryString["__CALLBACK_DEBUG"] != null && Request.QueryString["__CALLBACK_DEBUG"] != "") {
				if (Request.QueryString["__CALLBACK_DEBUG"] == RuntimePlatformSettings.Misc.CallbackDebugInformationKey.GetValue()) {
					return AppInfo.GetAppInfo().GetCallbackDebugInformation();
				}
			}
			return "";
		}

		protected string GetHeadTopJavaScript() {
			return GetInjectedCode(CodeInjectionFactory.Locations.HeadTop, "5iM2jMromEyrgtXKm6ia+g", "InternalError");
		}

		protected string GetHeadBottomJavaScript() {
			return GetInjectedCode(CodeInjectionFactory.Locations.HeadBottom, "5iM2jMromEyrgtXKm6ia+g", "InternalError");
		}

		protected string GetBodyTopJavaScript() {
			return GetInjectedCode(CodeInjectionFactory.Locations.BodyTop, "5iM2jMromEyrgtXKm6ia+g", "InternalError");
		}

		protected string GetBodyBottomJavaScript() {
			return GetInjectedCode(CodeInjectionFactory.Locations.BodyBottom, "5iM2jMromEyrgtXKm6ia+g", "InternalError");
		}

		HeContext heContext;
		private static Hashtable htTabIndexGroups = new Hashtable();
		private Hashtable htTabIndexGroupsTI = new Hashtable();



		static ScrnInternalError() {
		}




		protected override BaseAppUtils GetAppUtils() {
			return AppUtils.Instance;
		}

		protected override string OwnCssUrl {
			get {
				return ""; 
			}
		}

		protected override string OwnCssFile {
			get {
				return ""; 
			}
		}

		protected override string BasicCssUrl {
			get {
				return "_Basic.css"; 
			}
		}

		protected override string BasicCssFile {
			get {
				return "_Basic.css"; 
			}
		}

		protected override string ServiceCenterBrandingCssUrl {
			get {
				return "_ServiceCenterBrandingCss.css"; 
			}
		}

		protected override string ServiceCenterBrandingCssFile {
			get {
				return "_ServiceCenterBrandingCss.css"; 
			}
		}

		protected override string LifeTimeCoreBrandingCssUrl {
			get {
				return "_LifeTimeCoreBrandingCss.css"; 
			}
		}

		protected override string LifeTimeCoreBrandingCssFile {
			get {
				return "_LifeTimeCoreBrandingCss.css"; 
			}
		}

		protected override string LifeTimePerformanceMonitorBrandingCssUrl {
			get {
				return "_LifeTimePerformanceMonitorBrandingCss.css"; 
			}
		}

		protected override string LifeTimePerformanceMonitorBrandingCssFile {
			get {
				return "_LifeTimePerformanceMonitorBrandingCss.css"; 
			}
		}

		protected override string PerformanceThemeBrandingCssUrl {
			get {
				return "_PerformanceThemeBrandingCss.css"; 
			}
		}

		protected override string PerformanceThemeBrandingCssFile {
			get {
				return "_PerformanceThemeBrandingCss.css"; 
			}
		}

		protected override string LifeTimeStyleBrandingCssUrl {
			get {
				return "_LifeTimeStyleBrandingCss.css"; 
			}
		}

		protected override string LifeTimeStyleBrandingCssFile {
			get {
				return "_LifeTimeStyleBrandingCss.css"; 
			}
		}

		protected override string ThemeCssUrl {
			get {
				return "Theme.ContactManager.css"; 
			}
		}

		protected override string ThemeCssCacheInvalidationSuffix {
			get {
				return AppUtils.Instance.CacheInvalidationSuffix; 
			}
		}

		protected override string ThemeCssFile {
			get {
				return "Theme.ContactManager.css"; 
			}
		}

		protected override string ThemeExtraCssUrl {
			get {
				return ""; 
			}
		}

		protected override string ThemeExtraCssCacheInvalidationSuffix {
			get {
				return ""; 
			}
		}

		protected override string ThemeExtraCssFile {
			get {
				return ""; 
			}
		}

		public override bool IsUsingMobileTheme {
			get {
				return false; 
			}
		}

		protected override string OwnJavascriptInclude {
			get {
				return ""; 
			}
		}

		public override string XUACompatibleOverride {
			get {
				return null; 
			}
		}

		protected void InitializeUrls() {
			Uri uri = new Uri((RuntimePlatformUtils.RequestIsHttps(Request) ? "https": "http") + Request.Url.ToString().Substring(Request.Url.Scheme.Length));
			string applicationUrl = AppUtils.Instance.getImagePath(/*internalAccess*/false,/*includeSessionIdIfNeeded*/ false);
			actionUrl = "";
			bookmarkableUrl = uri.GetLeftPart(UriPartial.Authority) + applicationUrl;
			List<Pair<string, string>> parameters = new List<Pair<string, string>>();
			if (Request.AppRelativeCurrentExecutionFilePath.IndexOf('/', 2) == -1) {
				AppInfo appInfo = AppInfo.GetAppInfo();
				if (appInfo != null) {
					string pageHeader = appInfo.OsContext.OsISAPIFilter.GetPage(Request);
					if (appInfo.OsContext.IsCookielessSession || (pageHeader != null && pageHeader.IndexOf('/', 1) != -1)) {
						actionUrl = applicationUrl;
					}
				}
				actionUrl += AppUtils.GetPageName(heContext, Global.eSpaceId, "InternalError", parameters,/*useParamsOnlyIfNeededForRule*/ true);
			}
			bookmarkableUrl += AppUtils.GetPageName(heContext, Global.eSpaceId, "InternalError", parameters,/*useParamsOnlyIfNeededForRule*/ false);

		}

		protected override void OnInit(EventArgs e) {
			HeContext heContext = AppInfo.GetAppInfo().OsContext;
			heContext.CurrentScreen = this;
			try {
				heContext.CurrentExecutionFileName = Path.GetFileName(Request.CurrentExecutionFilePath);
			} catch {}
			InitializeComponent(heContext);
			base.OnInit(e);
		}
		private void InitializeComponent(HeContext heContext) {
			wt_WebBlockInstance8 = (ssContactManager.Flows.FlowCommon.WBlkLayout_Normal) FindControl("wt_WebBlockInstance8");
			wt_Container14 = (OutSystems.HubEdition.WebWidgets.Container) FindControl("wt_Container14");
			wtlnkPopup = (OutSystems.HubEdition.WebWidgets.LinkButton) FindControl("wtlnkPopup");
			if (this.wtlnkPopup != null) {
				this.wtlnkPopup.Click += new System.EventHandler(this.wtlnkPopup_Click);
			}
			Page.Error += new EventHandler(Page_Error);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
		}

		public override Control FindControl(string id) {
			if (id == "wt_WebBlockInstance6") {
				return wt_WebBlockInstance8.wtMenu.FindControl("wt_WebBlockInstance6");
			}
			if (id == "wt_Text15") {
				return wt_WebBlockInstance8.wtTitle.FindControl("wt_Text15");
			}
			if (id == "wt_Container14") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Container14");
			}
			if (id == "wt_Text17") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text17");
			}
			if (id == "wt_If3") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_If3");
			}
			if (id == "wt_If3T") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_If3T");
			}
			if (id == "wt_Text9") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text9");
			}
			if (id == "wt_If3F") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_If3F");
			}
			if (id == "wt_Text16") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text16");
			}
			if (id == "wt_InlineExpression13") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_InlineExpression13");
			}
			if (id == "wt_Text7") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text7");
			}
			if (id == "wt_Text18") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text18");
			}
			if (id == "wtlnkPopup") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wtlnkPopup");
			}
			if (id == "wt_Text21") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_Text21");
			}
			if (id == "wt_InlineExpression11") {
				return wt_WebBlockInstance8.wtMainContent.FindControl("wt_InlineExpression11");
			}

			return base.FindControl(id);
		}


		private void Page_Load(object sender, System.EventArgs e) {
			// init vars
			AppInfo appInfo = Global.App;
			if (appInfo != null) {
				heContext = appInfo.OsContext;
			}
			Response.ContentType = "text/html; charset=" + Response.ContentEncoding.WebName;

			// No session SessionFixationValidation because screen is accessible by anonymous users or uses a readonly session.

			if (appInfo != null) {
				heContext = appInfo.OsContext; heContext.RequestTracer.MainEventType = RequestTracerEventType.WebScreenServerExecuted; heContext.RequestTracer.RegisterEndpoint("8c3623e6-e8ca-4c98-ab82-d5ca9ba89afa", "InternalError"); 
			}
			OutSystems.HubEdition.RuntimePlatform.Web.JavaScriptManager.CheckRelativeJavaScriptPrefix(AppUtils.Instance.getImagePath());
			appInfo.IsLoadingScreen = !IsPostBack;
			((OSPageViewState) Page).EnableResetViewState();
			if (!IsPostBack) {
				ArrayList screenParameters = (ArrayList) Global.App.OsContext.Session["ContactManager._ScreenParameters_InternalError"];
				bool screenParametersInSession = false;
				object screenParametersKey = heContext.Session["_ScreenParametersKey"];
				if ((screenParametersKey == null || this.Key.Equals(ObjectKey.Parse(Convert.ToString(screenParametersKey)))) && screenParameters != null) {
					try {
						screenParametersInSession = true;
					} catch (Exception parametersException) {
						ErrorLog.LogApplicationError("Failed to load Screen Input Parameters from session.", "ScreenParametersKey = " + screenParametersKey + ", Count = " + screenParameters.Count + "\r\n" + parametersException.StackTrace, heContext, "Global");
					} finally {
						Global.App.OsContext.Session["ContactManager._ScreenParameters_InternalError"] = null;
						heContext.Session["_ScreenParametersKey"] = null;
					}
				}
				else if (Request.HttpMethod == "GET") {
				}
				else if (Request.HttpMethod == "POST") {
				}
			}
			if (!appInfo.IsApplicationEnabled) {
				ErrorLog.LogApplicationError(message: "eSpace " + appInfo.eSpaceName + " is disabled", stackTrace: Environment.StackTrace, context: heContext, moduleName: "Global");
				String contact = RuntimePlatformUtils.GetAdministrationEmail();
				try {
					Context.Items[Constants.AppOfflineCustomHandler.ContactKey] = contact;
					Context.Items[Constants.AppOfflineCustomHandler.ErrorCodeKey] = "APPLICATION_OFFLINE";
					Server.Transfer("/ContactManager/CustomHandlers/app_offline.aspx");
				}
				catch (System.Threading.ThreadAbortException) {}
				catch {
					Response.Redirect("/ContactManager/CustomHandlers/internalerror.aspx");
				}
			}
			InitializeUrls();
			Actions.ActionOnBeginWebRequest(heContext);
			if (appInfo.IsForcingSecurityForScreens() && !RuntimePlatformUtils.RequestIsSecure(Request)) {
				Response.Redirect("https://" + Request.Url.Host + "" + AppUtils.Instance.getImagePath() + "InternalError.aspx" + Request.Url.Query);
				HttpContext.Current.ApplicationInstance.CompleteRequest();
			}
			if (!IsPostBack) {
				CheckPermissions(heContext);
				bool bindEditRecords = !IsPostBack;
				Title = "Internal Error"; Page.DataBind();
				if (RuntimePlatformUtils.GetRequestTracer() != null) {
					RuntimePlatformUtils.GetRequestTracer().RegisterSessionSize(); if (heContext.Session != null) {
						RuntimePlatformUtils.GetRequestTracer().RegisterUserId(heContext.Session.UserId); 
					}
				}
				if (!heContext.AppInfo.SelectiveLoggingEnabled || heContext.AppInfo.Properties.AllowLogging) {
					ScreenLog.StaticWrite(heContext.AppInfo, heContext.Session, heContext.StartInstant, (int) ((TimeSpan) (DateTime.Now-heContext.StartInstant)).TotalMilliseconds, "InternalError", (string) heContext.Session["MSISDN"], "WEB", "Screen", RuntimeEnvironment.MachineName, RuntimePlatformUtils.GetViewstateSize(), RuntimePlatformUtils.GetRetrievedSessionSize(), RuntimePlatformUtils.GetRetrievedSessionRequests());
				}
			} else {
				if (heContext.AppInfo.IsForcingSecurityForScreens() && !RuntimePlatformUtils.RequestIsSecure(Request)) {
					Response.Redirect("https://" + Request.Url.Host + "" + AppUtils.Instance.getImagePath() + "InternalError.aspx" + Request.Url.Query);
					HttpContext.Current.ApplicationInstance.CompleteRequest();
				}
				FetchViewState();
			}

		}
		private void Page_PreRender(object sender, System.EventArgs e) {
			ClientScript.RegisterArrayDeclaration("OsPage_Validators", "{}");

			NegotiateTabIndexes();

			foreach(Control child in this.Controls) {
				DisableViewState(child);
			}
		}

		private void NegotiateTabIndexes() {
			short tabindex=1;
			tabindex = NegotiateTabIndexes(tabindex, false);
		}

		public short NegotiateTabIndexes(short tabindex, bool setTabIndex) {
			Control rootCtrl = this;
			if ((this.Controls.Count == 1) && (typeof(HtmlForm).IsInstanceOfType(this.Controls[0]))) {
				rootCtrl = this.Controls[0];
			} else {
				rootCtrl = this;
			}
			tabindex = NegotiateTabIndexesRecursively(tabindex, rootCtrl, setTabIndex);
			return tabindex;
		}

		public short NegotiateTabIndexesRecursively(short tabindex, Control rootCtrl, bool setTabIndex) {

			bool bAssignTabIndex = false;
			WebControl ctrl = null;
			HtmlControl htmlCtrl = null;
			foreach(Control child in rootCtrl.Controls) {
				if (child is INegotiateTabIndexes) {
					tabindex = ((INegotiateTabIndexes) child).NegotiateTabIndexes(tabindex, setTabIndex);
					continue;
				}
				if (typeof(WebControl).IsInstanceOfType(child)) {
					ctrl = (WebControl) child;
					bAssignTabIndex = false;
					if (ctrl is OutSystems.HubEdition.WebWidgets.TextBox | ctrl is OutSystems.HubEdition.WebWidgets.CheckBox | ctrl is OutSystems.HubEdition.WebWidgets.RadioButton | ctrl is OutSystems.HubEdition.WebWidgets.DropDownList) {

						bAssignTabIndex = true;
					} else if (ctrl is System.Web.UI.WebControls.LinkButton | ctrl is System.Web.UI.WebControls.Button | ctrl is System.Web.UI.WebControls.HyperLink | ctrl is System.Web.UI.WebControls.ListBox) {
						bAssignTabIndex = true;
					}
					else if (ctrl is PlaceholderContainer)
					{
						INegotiateTabIndexes placeholderOwner = (INegotiateTabIndexes) Utils.GetOwnerOfControl(ctrl);
						tabindex = placeholderOwner.NegotiateTabIndexesRecursively(tabindex, ctrl, setTabIndex);
						continue;
					}

					short settedTabIndex = 0;
					if (bAssignTabIndex && setTabIndex) {
						object b = htTabIndexGroups[ctrl.ID];
						if (b != null) {
							string groupid = b.ToString();
							if (htTabIndexGroupsTI[groupid] == null) {
								htTabIndexGroupsTI[groupid] = tabindex++;
							}
							ViewStateAttributes.SetTabIndex(ctrl, Convert.ToInt16(htTabIndexGroupsTI[groupid]), out settedTabIndex);
						} else {
							ViewStateAttributes.SetTabIndex(ctrl, tabindex, out settedTabIndex);
							// Increase tabindex if it was not overiden
							if (tabindex == settedTabIndex) {
								tabindex++;
							}
						}
					}
					tabindex = Math.Max(tabindex, ++settedTabIndex);
				} else if (child is HtmlControl && setTabIndex) {
					htmlCtrl = (HtmlControl) child;
					if (htmlCtrl is System.Web.UI.HtmlControls.HtmlInputFile) {
						htmlCtrl.Attributes.Add("tabIndex", Convert.ToString(tabindex++));
					}
				}
				if (child.Controls.Count > 0) {
					tabindex = NegotiateTabIndexesRecursively(tabindex, child, setTabIndex);
				}
			}
			return tabindex;
		}



		private void Page_Error(object sender, System.EventArgs e) {
			if (! new ssContactManager.Flows.FlowCommon.ExceptionHandler(this, false).HandleException()) {
				DatabaseAccess.FreeupResources(false);
				Server.Transfer("_WebErrorPage.aspx");
			}
		}

		public override void ClearErrorHandler() {
			Error -= Page_Error;
		}

		public void CheckPermissions(HeContext heContext) {
			return;
		}


		public ObjectKey Key {
			get {
				return ObjectKey.Parse("5iM2jMromEyrgtXKm6ia+g"); 
			}
		}

		public bool isSecure {
			get {
				return Global.App.IsForcingSecurityForScreens();
			}
		}


		/// <summary>
		/// Action <code>CommandClose</code> that represents the Service Studio screen action
		///  <code>Close</code> <p> Description: </p>
		/// </summary>
		private bool CommandClose(HeContext heContext) {
			Global.App.Context.Items["osPassedOnAction"] = true;
			CheckPermissions(heContext);
			RequestTracer perfTracer = heContext.RequestTracer; if (perfTracer != null) {
				perfTracer.RegisterAction("13dadb09-1482-4c8b-a858-9ffef470f1ef", "Close"); 
			}
			try {
				if (heContext != null && heContext.RequestTracer != null) {
					heContext.RequestTracer.RegisterInternalCall("CdvaE4IUi0yoWJ_+9HDx7w", "Close", "X0RMeX3yYU+0eg2nFEDfaA", "ContactManager");
				}
				// Popup_Editor_Close
				Actions.ActionPopup_Editor_Close(heContext);

				// Update Screen
				return true;

			} catch (System.Threading.ThreadAbortException) {
				return false;
			}
		}
		/// <summary>
		/// wt_WebBlockInstance8 Functions
		/// </summary>
		public void webBlck_WebBlockInstance8_onDataBinding(object sender, System.EventArgs e) {
			ssContactManager.Flows.FlowCommon.WBlkLayout_Normal widget = (ssContactManager.Flows.FlowCommon.WBlkLayout_Normal) sender;
		}
		/// <summary>
		/// wt_WebBlockInstance6 Functions
		/// </summary>
		public void webBlck_WebBlockInstance6_onDataBinding(object sender, System.EventArgs e) {
			ssContactManager.Flows.FlowCommon.WBlkMenu widget = (ssContactManager.Flows.FlowCommon.WBlkMenu) sender;
			widget.inParamActiveMenuItemId = 0;
		}
		/// <summary>
		/// wt_Container14 Functions
		/// </summary>
		public void cnt_Container14_onDataBinding(object sender, System.EventArgs e) {
			cnt_Container14_setInlineAttributes(sender, e);
		}
		public string cnt_Container14_setInlineAttributes(object sender, System.EventArgs e) {
			if (!cnt_Container14_isVisible()) {
				string stylevalue = ((IAttributeAccessor) sender).GetAttribute("style");
				{
					string newstyledef;
					string oldstyledef;
					newstyledef = stylevalue + ((stylevalue!=null && !stylevalue.TrimEnd().EndsWith(";")) ? ";": "") + "display:none";
					oldstyledef = ((IAttributeAccessor) sender).GetAttribute("style");
					if (oldstyledef != null) {
						if (!oldstyledef.TrimEnd().EndsWith(";")) newstyledef = ";" + newstyledef;
						if (!oldstyledef.EndsWith(newstyledef)) {
							((IAttributeAccessor) sender).SetAttribute("style", oldstyledef + newstyledef.ToString());
						} else {
							((IAttributeAccessor) sender).SetAttribute("style", oldstyledef.ToString());
						}
					} else {
						((IAttributeAccessor) sender).SetAttribute("style", newstyledef.ToString());
					}
				}
			} else {
				string stylevalue = ((IAttributeAccessor) sender).GetAttribute("style");
				if (stylevalue != null) {
					((IAttributeAccessor) sender).SetAttribute("style", stylevalue.Replace("display:none;", "").Replace("display:none", "").ToString());
				}
			}
			return "";
		}
		/// <summary>
		/// Gets the visible state of component (wt_Container14)
		/// </summary>
		/// <returns>The Visible State of wt_Container14</returns>
		public bool cnt_Container14_isVisible() {
			return true;
		}

		/// <summary>
		/// wt_If3 Functions
		/// </summary>
		bool if_wt_If3_hasRun=false;
		bool if_wt_If3_evalResult;
		public bool if_wt_If3() {
			if (if_wt_If3_hasRun) {
				if_wt_If3_hasRun = false;
				return if_wt_If3_evalResult;
			}
			if_wt_If3_hasRun = true;
			if_wt_If3_evalResult = (BuiltInFunction.GetPersonalAreaName() == "");
			return if_wt_If3_evalResult;
		}

		/// <summary>
		/// wt_InlineExpression13 Functions
		/// </summary>
		/// <summary>
		/// Function to dump expression (Key = 3SpycKE6HEepS+JVQKvsKg) Expression: ExceptionMessage
		/// </summary>
		/// <returns>Returns the value of the Expression</returns>
		public string expression_InlineExpression13() {
			return ((string) Global.App.OsContext.Session["ExceptionMessage"]);
		}
		/// <summary>
		/// wtlnkPopup Functions
		/// </summary>
		public void lnklnkPopup_onDataBinding(object sender, System.EventArgs e) {
			((IAjaxHandler) sender).RegisterAjaxEvent(AjaxEventType.onAjaxClick, null);
		}
		/// <summary>
		/// Action to be taken at a Link submit action)
		/// </summary>
		/// <param name="sender"> The associated sender components</param>
		/// <param name="e"> The associated event arguments</param>
		public void wtlnkPopup_Click(object sender, System.EventArgs e) {
			((IWebScreen) ((System.Web.UI.Control) sender).Page).OnSubmit(((IParentEditRecordProp) sender).GetParentEditRecordClientId(), false);
			if (CommandClose(heContext)) {
				doAJAXRefreshScreen(heContext);
			}
		}
		/// <summary>
		/// Gets the title of the link (wtlnkPopup)
		/// </summary>
		/// <returns>title of the Link (wtlnkPopup)</returns>
		public string
		lnklnkPopup_getTitle() {
			return "";
		}
		/// <summary>
		/// Gets the visible state of component (wtlnkPopup)
		/// </summary>
		/// <returns>The Visible State of wtlnkPopup</returns>
		public bool lnklnkPopup_isVisible() {
			return true;
		}

		/// <summary>
		/// Gets the enabled state of component (wtlnkPopup)
		/// </summary>
		/// <returns>The Enabled State of wtlnkPopup</returns>
		public bool lnklnkPopup_isEnabled() {
			return true; 
		}
		/// <summary>
		/// wt_InlineExpression11 Functions
		/// </summary>
		/// <summary>
		/// Function to dump expression (Key = Vy4yZ1XNOUigazoCmexoSA) Expression: "<script
		///  type='text/javascript'>  if (parent!=window){ //Is inside frame   document.getElementById('"
		/// + lnkPopup.Id + "').style.display='';  }   else {   document.getElementById('" + lnkPopup.Id +
		///  "').style.display='none';  } </script>"
		/// </summary>
		/// <returns>Returns the value of the Expression</returns>
		public string expression_InlineExpression11() {
			return (((("<script type=\'text/javascript\'>\r\n if (parent!=window){ //Is inside frame\r\n  document.getElementById(\'" +wtlnkPopup.ClientID) + "\').style.display=\'\';\r\n } \r\n else {\r\n  document.getElementById(\'") +wtlnkPopup.ClientID) + "\').style.display=\'none\';\r\n }\r\n</script>");
		}
		/// <summary>
		/// wt_WebBlockInstance20 Functions
		/// </summary>
		public void webBlck_WebBlockInstance20_onDataBinding(object sender, System.EventArgs e) {
			ssContactManager.Flows.FlowRichWidgets.WBlkRemovePopups widget = (ssContactManager.Flows.FlowRichWidgets.WBlkRemovePopups) sender;
		}


		public static class FuncCommandClose {
		}



		protected static string GetString(string key, string defaultValue) {
			return Global.GetStringResource(key, defaultValue);
		}


		public LocalState PushStack() {
			return null;
		}

		public void doRefreshScreen(HeContext heContext) {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				Title = "Internal Error"; Page.DataBind();
				if (RuntimePlatformUtils.GetRequestTracer() != null) {
					RuntimePlatformUtils.GetRequestTracer().RegisterSessionSize(); if (heContext.Session != null) {
						RuntimePlatformUtils.GetRequestTracer().RegisterUserId(heContext.Session.UserId); 
					}
				}
				if (!heContext.AppInfo.SelectiveLoggingEnabled || heContext.AppInfo.Properties.AllowLogging) {
					ScreenLog.StaticWrite(heContext.AppInfo, heContext.Session, heContext.StartInstant, (int) ((TimeSpan) (DateTime.Now-heContext.StartInstant)).TotalMilliseconds, "InternalError", (string) heContext.Session["MSISDN"], "WEB", "Screen", RuntimeEnvironment.MachineName, RuntimePlatformUtils.GetViewstateSize(), RuntimePlatformUtils.GetRetrievedSessionSize(), RuntimePlatformUtils.GetRetrievedSessionRequests());
				}
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}

		}

		public void doAJAXRefreshScreen(HeContext heContext) {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				// Perform the partial databind
				Page.DataBind();
				RequestTracer perfTracer = RuntimePlatformUtils.GetRequestTracer(); if (perfTracer != null) {
					perfTracer.RegisterSessionSize(); if (heContext.Session != null) {
						RuntimePlatformUtils.GetRequestTracer().RegisterUserId(heContext.Session.UserId); 
					}
				}
				if (!heContext.AppInfo.SelectiveLoggingEnabled || heContext.AppInfo.Properties.AllowLogging) {
					ScreenLog.StaticWrite(heContext.AppInfo, heContext.Session, heContext.StartInstant, (int) ((TimeSpan) (DateTime.Now-heContext.StartInstant)).TotalMilliseconds, "InternalError", (string) heContext.Session["MSISDN"], "WEB", "Ajax", RuntimeEnvironment.MachineName, RuntimePlatformUtils.GetViewstateSize(), RuntimePlatformUtils.GetRetrievedSessionSize(), RuntimePlatformUtils.GetRetrievedSessionRequests());
				}
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
			StoreWebScreenStackViewState();

		}



		/// <summary>
		/// Store widget and variable data in the viewstate
		/// </summary>
		public override void StoreViewState() {
			base.StoreViewState();
			RemoveStoreViewStateWebScreenStack(this);
		}
		/// <summary>
		/// Restore widget and variable data from the viewstate
		/// </summary>
		protected override void FetchViewState() {
			base.FetchViewState();
			try {
			} catch (Exception e) {
				throw new Exception("Error Deserializing ViewState", e); 
			}
		}


		/// <summary>
		/// This method is called when there is a submit. So it should validate input values and call the
		///  correct system event user action if needed
		/// </summary>
		public void OnSubmit(string parentEditRecord, bool validate) {
			CallOnSubmitOnChildren(Controls, parentEditRecord, validate);
		}


		public void CallOnSubmitOnChildren(ControlCollection children, string parentEditRecord, bool validate) {
			foreach(Control ctrl in children) {
				IWebScreen screen = ctrl as IWebScreen;

				if (screen != null) {
					screen.OnSubmit(parentEditRecord, validate);
				} else {
					CallOnSubmitOnChildren(ctrl.Controls, parentEditRecord, validate);
				}
			}
		}

		public String BreakpointHook(String breakpointId) {
			return "";
		}

		public String BreakpointHook(String breakpointId, bool isExpressionlessWidget) {
			return "";
		}

		public String PageStartHook() {
			Page_Load(null, null); this.Load -= new System.EventHandler(this.Page_Load);
			return "";
		}
		public String PageEndHook() {
			return "";
		}


		public override void DataBind() {
			base.DataBind();
			StoreViewState();
			OutSystems.HubEdition.WebWidgets.Utils.addValidationScriptsToPage(this);
		}



	}

}
