﻿/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Internal;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
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
using System.Runtime.Serialization;
using System.Text;
using System.Linq;


namespace ssContactManager.Flows.FlowRichWidgets {
	public abstract class WBlkContainer_Round: OSUserControl, IWebScreen, INegotiateTabIndexes, IAjaxNotifyEvent, INotifyTriggers, INotifySender {

		/// <summary>
		/// Delegate Definitions
		/// </summary>
		/// <summary>
		/// Parameters and Local Variables Definitions
		/// </summary>
		/// <summary>
		/// Screen Input Parameter inParamIdOfContainerToCompletelyRound. Description: The 'Id' runtime
		///  property of the container to have rounded corners.
		/// </summary>
		public string inParamIdOfContainerToCompletelyRound = "";
		/// <summary>
		/// Screen Input Parameter inParamStyleOfContainersToRoundTops. Description: If specified, only those
		///  widgets with this style have their top corners rounded (e.g. application menus).
		/// </summary>
		public string inParamStyleOfContainersToRoundTops = "";
		/// <summary>
		/// Variable "True" if the Widget wt_If12
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If12T;

		/// <summary>
		/// Variable "True" if the Widget wt_If12
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If12F;
		/// <summary>
		/// Variable "True" if the Widget wt_If11
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If11T;

		/// <summary>
		/// Variable "True" if the Widget wt_If11
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If11F;
		/// <summary>
		/// Variable "True" if the Widget wt_If4
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If4T;

		/// <summary>
		/// Variable "True" if the Widget wt_If4
		/// </summary>
		protected OutSystems.HubEdition.WebWidgets.If wt_If4F;
		private List<object> explicitChangedVariables = new List<object>();
		private bool _isRendering = false;
		public HeContext heContext;
		private static Hashtable htTabIndexGroups = new Hashtable();
		private Hashtable htTabIndexGroupsTI = new Hashtable();
		public string InstanceID;
		public string RuntimeID= "";
		public event EventHandler NotifyTriggered;
		private BlocksJavascript.JavascriptNode _javascriptNode;
		static WBlkContainer_Round() {
		}

		public void OnNotifyCalled(string message) {
			BindDelegatesIfNeeded();
			if (NotifyTriggered != null) {
				NotifyTriggered(this, new MsgEventArgs(message));
			}
		}

		override protected void OnInit(EventArgs e) {
			InitializeComponent();
			base.OnInit(e);
		}
		private T HandleCurrentEspaceKey<T>(Func<T> action) {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				return action();
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
		}
		private void InitializeComponent() {
			this.Load += new System.EventHandler(this.Page_Load);
			this.Unload += new System.EventHandler(this.Page_Unload);
		}
		private void Page_Load(object sender, System.EventArgs e) {
			heContext = Global.App.OsContext;
			RuntimeID = ClientID;
			if (!Visible) return;
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				if (!IsPostBack || _isRendering) {
					// register this block in the page so for later outputting the block javascript includes in their correct order
					((OSPage) Page).RegisterBlock(this, out _javascriptNode);
					if (_isRendering) {
					}
					bool bindEditRecords = IsViewStateEmpty;
				} else {
					FetchViewState();
				}
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}

		}
		/// <summary>
		/// This method is called when there is a submit. So it should validate input values and call the
		///  correct system event user action if needed
		/// </summary>
		public void OnSubmit(string parentEditRecord, bool validate) {
			if (!WasRendered) {
				return;
			}
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


		/// <summary>
		/// Store widget and variable data in the viewstate
		/// </summary>
		public override void StoreViewState() {
			base.StoreViewState();
			ViewStateAttributes.EnsureNotEmpty();
			RemoveStoreViewStateWebScreenStack(this);
		}
		/// <summary>
		/// Restore widget and variable data from the viewstate
		/// </summary>
		protected override void FetchViewState() {
			base.FetchViewState();
			if (IsViewStateEmpty) return;
			try {
			} catch (Exception e) {
				throw new Exception("Error Deserializing ViewState", e); 
			}
		}

		/// <summary>
		/// Store visibility information of the web block and input widgets in the viewstate
		/// </summary>
		protected override void StoreInputsAndWebBlockVisibility() {
			ViewStateAttributes.EnsureNotEmpty();
		}
		/// <summary>
		/// Restore visibility information of the web block and input widgets from the viewstate
		/// </summary>
		protected override void RestoreInputsAndWebBlockVisibility() {
			WasRendered = true;
		}

		private void Page_Unload(object sender, System.EventArgs e) {
		}

		public LocalState PushStack() {
			throw new NotImplementedException();
		}

		public void doRefreshScreen(HeContext heContext) {
			((IWebScreen) this.Page).doRefreshScreen(heContext);
		}

		public void doAJAXRefreshScreen(HeContext heContext) {
			StoreViewState();
			((IWebScreen) this.Page).doAJAXRefreshScreen(heContext);
		}

		public static void GetCss(TextWriter writer, bool inline, HashSet<string> visited) {
			string blockId = "ContactManager.KR5jTByrm4ESUvnM__9raCw";
			if (visited.Contains(blockId)) {
				return; 
			}
			visited.Add(blockId);
			if (!inline) {
				GetCssIncludes(writer, visited);
			} else {
				GetInlineCss(writer, visited);
			}
		}

		private static void GetCssIncludes(TextWriter writer, HashSet<string> visited) {
			InnerGetCss(writer, false, visited);
		}

		private static void GetInlineCss(TextWriter writer, HashSet<string> visited) {
			StringWriter localCssWriter = new StringWriter();
			localCssWriter.NewLine = writer.NewLine;
			string localCss = Environment.NewLine;
			InnerGetCss(localCssWriter, true, visited);
			localCss += localCssWriter.ToString();
			writer.Write(localCss);
		}

		private static void InnerGetCss(TextWriter writer, bool inline, HashSet<string> visited) {
			ssContactManager.Flows.FlowPrivate.WBlkjQueryCurvycorners.GetCss(writer, inline, visited);
		}

		private void Page_Error(object sender, System.EventArgs e) {
		}
		public void CheckPermissions(HeContext heContext) {
			((IWebScreen) this.Page).CheckPermissions(heContext);
		}
		protected static string GetString(string key, string defaultValue) {
			return Global.GetStringResource(key, defaultValue);
		}

		public ObjectKey Key {
			get {
				return ObjectKey.Parse("R5jTByrm4ESUvnM+_9raCw"); 
			}
		}
		public bool isSecure {
			get {
				return ((IWebScreen) Page).isSecure; 
			}
		}
		bool if_wt_If12_hasRun=false;
		bool if_wt_If12_evalResult;
		public bool if_wt_If12() {
			if (if_wt_If12_hasRun) {
				if_wt_If12_hasRun = false;
				return if_wt_If12_evalResult;
			}
			if_wt_If12_hasRun = true;
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				if_wt_If12_evalResult = ("InWebBlockPreview" == "True");
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
			return if_wt_If12_evalResult;
		}

		/// <summary>
		/// Gets the Height of the image (wt_Image9)
		/// </summary>
		/// <returns>Height of the Image (wt_Image9)</returns>
		public string img_Image9_actualHeight() {
			return HttpUtility.HtmlEncode(Convert.ToString(16));
		}
		/// <summary>
		/// Gets the Width of the image (wt_Image9)
		/// </summary>
		/// <returns>Width of the Image (wt_Image9)</returns>
		public string img_Image9_actualWidth() {
			return HttpUtility.HtmlEncode(Convert.ToString(16));
		}
		public void webBlck_WebBlockInstance1_onDataBinding(object sender, System.EventArgs e) {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				ssContactManager.Flows.FlowPrivate.WBlkjQueryCurvycorners widget = (ssContactManager.Flows.FlowPrivate.WBlkjQueryCurvycorners) sender;
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
		}
		bool if_wt_If11_hasRun=false;
		bool if_wt_If11_evalResult;
		public bool if_wt_If11() {
			if (if_wt_If11_hasRun) {
				if_wt_If11_hasRun = false;
				return if_wt_If11_evalResult;
			}
			if_wt_If11_hasRun = true;
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				if_wt_If11_evalResult = (inParamIdOfContainerToCompletelyRound!= "");
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
			return if_wt_If11_evalResult;
		}

		/// <summary>
		/// Function to dump expression (Key = fBoGe_d1aEizbOm3L3uHFg) Expression: "<SCRIPT
		///  type=""text/javascript""> <!-- RichWidgets_Container_Round('" + IdOfContainerToCompletelyRound
		/// + "'); --> </SCRIPT> "
		/// </summary>
		/// <returns>Returns the value of the Expression</returns>
		public string expression_InlineExpression5() {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				return (("<SCRIPT type=\"text/javascript\">\r\n<!--\r\nRichWidgets_Container_Round(\'" +inParamIdOfContainerToCompletelyRound) + "\');\r\n-->\r\n</SCRIPT>\r\n");
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
		}
		bool if_wt_If4_hasRun=false;
		bool if_wt_If4_evalResult;
		public bool if_wt_If4() {
			if (if_wt_If4_hasRun) {
				if_wt_If4_hasRun = false;
				return if_wt_If4_evalResult;
			}
			if_wt_If4_hasRun = true;
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				if_wt_If4_evalResult = (inParamStyleOfContainersToRoundTops!= "");
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
			return if_wt_If4_evalResult;
		}

		/// <summary>
		/// Function to dump expression (Key = W95Nt46AQ0SuP_yusggDIw) Expression: "<SCRIPT
		///  type=""text/javascript""> <!-- RichWidgets_Container_RoundTops('." + StyleOfContainersToRoundTops
		/// + "'); --> </SCRIPT> "
		/// </summary>
		/// <returns>Returns the value of the Expression</returns>
		public string expression_InlineExpression10() {
			ObjectKey oldCurrentESpaceKey = heContext.CurrentESpaceKey;
			try {
				heContext.CurrentESpaceKey = ssContactManager.Global.eSpaceKey;
				return (("<SCRIPT type=\"text/javascript\">\r\n<!--\r\nRichWidgets_Container_RoundTops(\'." +inParamStyleOfContainersToRoundTops) + "\');\r\n-->\r\n</SCRIPT>\r\n");
			} finally {
				heContext.CurrentESpaceKey = oldCurrentESpaceKey;
			}
		}

		public override Control FindControl(string id) {
			return base.FindControl(id);
		}
		public String BreakpointHook(String breakpointId) {
			return "";
		}

		public String BreakpointHook(String breakpointId, bool isExpressionlessWidget) {
			return "";
		}

		public String PageStartHook() {
			_isRendering = true;
			Page_Load(null, null); _isRendering = false;
			this.Load -= new System.EventHandler(this.Page_Load);
			return "";
		}
		public String PageEndHook() {
			return "";
		}
		public override string WebBlockIdentifier {
			get {
				return "ContactManager.KR5jTByrm4ESUvnM__9raCw";
			}
		}
		public override string JavaScriptFileName {
			get {
				return AppRelativeVirtualPath.Replace(".ascx", string.Empty) + ".js" + AppUtils.Instance.CacheInvalidationSuffix;
			}
		}
	}
}
