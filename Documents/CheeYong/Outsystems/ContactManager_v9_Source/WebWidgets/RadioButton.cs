/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {

    using Pair = System.Web.UI.Pair;

    public sealed class RadioButton : WebControl, IPostBackDataHandler, IBreakPointControl, IViewStateAttributes, IAjaxHandler, IAjaxChangeEvent, IGridWidget, IOSControl, IParentEditRecordProp {

		public delegate string GetValueType();
		public event GetValueType GetRadioValue; 

		static RadioButton() {
			RadioButton.EventCheckedChanged = new object();
		}

        public RadioButton()
            : base(System.Web.UI.HtmlTextWriterTag.Input) {
            _viewStateAttributes = new ViewStateAttributes(this, Attributes, ViewState);
		}

		bool _registeredPostBack = false;

        private ViewStateAttributes _viewStateAttributes;
        public ViewStateAttributes ViewStateAttributes {
            get {
                return _viewStateAttributes;
            }
        }

		protected override void OnPreRender(EventArgs e) {
			base.OnPreRender(e);
			if (Enabled && !_registeredPostBack) {
				// only register requires postback event once per request, otherwise in multiple partial refreshes the 
				// control's ids will appear multiple times in the Viewstate in the key __ControlsRequirePostBackKey__
				Page.RegisterRequiresPostBack(this);
				_registeredPostBack = true;
			}
			string value = Attributes["value"];
            if (OSPage.IsAjaxRequest && value == null) {
                //#109916 - Get value from the viewstate, since if the radio is inside a table records the GetRadioValue() will return null
                value = (string)ViewState["value"];
            }
			
            ViewStateAttributes.SetInViewState("value", value, null);
		}
	
        protected override object SaveViewState() {
            object viewstate = base.SaveViewState();
            if (viewstate is Pair) {
                Pair p = viewstate as Pair;
                p.Second = null;
            }
            return viewstate;
        }
		
		public event EventHandler CheckedChanged {
			add { 
				Events.AddHandler(RadioButton.EventCheckedChanged, value);
			}
			remove { 
				Events.RemoveHandler(RadioButton.EventCheckedChanged, value);
			}
		}

        private bool _checked;
		public bool Checked {
			get{
                return _checked;
            }
			set {
                _checked = value;
			} 
		}

        public bool InsideIteration {
            get {
                object obj = ViewStateAttributes.GetFromViewState("InsideIteration", false);
                if (obj != null)
                    return (bool)obj;
                else
                    return false;
            }
            set {
                ViewStateAttributes.SetInViewState("InsideIteration", value, false);
            } 
        }

        public string GroupName {
            get {
                string s = ViewStateAttributes.GetFromViewState("GroupName", null) as string;
                if (s != null)
                    return s;
                else
                    return string.Empty;
            }
            set {
                ViewStateAttributes.SetInViewState("GroupName", value, null);
            } 
        }

		private static readonly object EventCheckedChanged;

		protected override void AddAttributesToRender(HtmlTextWriter writer) {
            using (var w = new HtmlTextWriterWithAttributeFilter(writer)) {
			    Page.VerifyRenderingInServerForm(this);
                
			    w.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
			    w.AddAttribute(HtmlTextWriterAttribute.Name, UniqueGroupName);
			    if (Checked) {
                    w.AddAttribute(HtmlTextWriterAttribute.Checked, ((OSPage)Page).QuirksMode ? null : "checked");
			    }

                bool old_Enabled = Enabled;
                if (!Enabled) {
                    w.AddAttribute(HtmlTextWriterAttribute.Disabled, ((OSPage)Page).QuirksMode ? null : "disabled");
                    Enabled = true;
                }
    			
			    // dump ajax onchange handler
			    AjaxEventsHelper.AddAjaxEventAttribute(this, AjaxEventType.onAjaxChange, ClientID, UniqueID, "__OSVSTATE", ViewStateAttributes.InlineAttributes);

                base.AddAttributesToRender(w);
                ViewStateAttributes.InlineAttributes.AddAttributes(w);
			    Enabled = old_Enabled;
            }
		}

		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection) {
			string value = postCollection[UniqueGroupName];
            if (value != null && value == GetValue()) {
                Checked = true;
            } else {
                Checked = false;
            }
            // As we don't store Checked in ViewState, we don't know if changed or not, so we have to force the event to always occur
            return true;
		}

		void IPostBackDataHandler.RaisePostDataChangedEvent() {
            EventHandler handler = ((EventHandler)Events[RadioButton.EventCheckedChanged]);
            if (handler != null) {
                handler.Invoke(this, EventArgs.Empty);
            }
		}

        private string UniqueGroupName {
            get {
                if (InsideIteration) {
                    string part1 = UniqueID;
                    int pos = part1.LastIndexOf('$');
                    if (pos >= 0) {
                        part1 = part1.Substring(0, pos + 1);
                        string part2 = GroupName;
                        pos = part2.LastIndexOf('$');
                        if (pos >= 0)
                            part2 = part2.Substring(pos + 1);                        
                        return string.Concat(part1, part2);
                    } else {
                        return GroupName;
                    }
                } else {
                    return GroupName;
                }
            }
        }

		public string GetValue() {
            string s = Attributes["value"];
            if (s != null)
                return s;
            s = ViewStateAttributes.GetFromViewState("value", null) as string;
            if (s != null)
                return s;            
            return string.Empty;
		}

        private Hashtable events;
		public void RegisterAjaxEvent(AjaxEventType eventType, Array controlIdsToSend) {
			if (events == null) {
				events = new Hashtable();
			}

			events[eventType] = controlIdsToSend;
		}

		public Hashtable GetRegisteredAjaxEvents() {
			return events;
		}

        public string GridCssClasses { get; set; }

        //public override string CssClass {
        //    get { return new string[] {base.CssClass, GridCssClasses}.StrCat(" "); }
        //    set { base.CssClass = value; }
        //}

		#region IAjaxChangeEvent implementation

		public event EventHandler AjaxChange;

		public void OnAjaxChange(EventArgs e) {
			AjaxEventsHelper.RaiseAjaxEvent(this, AjaxChange);
		}

		#endregion

		#region IBreakPointControl implementation

		private String _BreakpointHookId;
		private bool _BreakpointHookIsExpressionlessWidget = false;

		public event BreakpointHook BreakpointHookEvent;

		public string BreakpointHookId {
			get { return _BreakpointHookId; }
			set { _BreakpointHookId = value; }
		}

		public bool BreakpointHookIsExpressionlessWidget {
			get { return _BreakpointHookIsExpressionlessWidget; }
			set { _BreakpointHookIsExpressionlessWidget = value; }
		}

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            this.AddGridClassesAttribute();
        }

		public override void DataBind() {
			if ( BreakpointHookEvent != null ) {					
			    BreakpointHookEvent(BreakpointHookId, BreakpointHookIsExpressionlessWidget);
			}
			Attributes["value"] = GetRadioValue();
			base.DataBind();
		}
		
		#endregion

        #region IOSControl members
        string IOSControl.TagName { get { return this.TagName; } }
        string[] IOSControl.CssClass { get { return this.CssClass.Split(' '); } }
        #endregion

        public string ParentEditRecord { get; set; }
        public ParentEditRecordPropType ValidatorType { get { return ParentEditRecordPropType.NEEDS_VALIDATION; } }
	}
}