/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
    public sealed class InputFile : ViewStateSpecializations.ViewStateLessHtmlInputFile, IBreakPointControl, IAjaxHandler, IAjaxChangeEvent, IGridWidget, IOSControl, IParentEditRecordProp {

        public override void RenderControl(HtmlTextWriter writer) {
            if (((OSPage)Page).QuirksMode) {
                base.RenderControl(new HtmlTextWriterOverriderForHtmlControls(writer, new string[] { "disabled" }, new string[] { null }));
            } else {
                base.RenderControl(writer);
            }
        }

        protected override void RenderBeginTag(HtmlTextWriter writer) {
            AjaxEventsHelper.AddAjaxEventAttribute(this, AjaxEventType.onAjaxChange, ClientID, UniqueID, "__OSVSTATE", Attributes);
            base.RenderBeginTag(writer);
        }

        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            this.AddGridClassesAttribute();
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

        public override void DataBind() {
            if (BreakpointHookEvent != null) {
                BreakpointHookEvent(BreakpointHookId, BreakpointHookIsExpressionlessWidget);
            }
            base.DataBind();
        }

        #endregion

        #region IOSControl members
        string[] IOSControl.CssClass { get { return (this.Attributes["class"] ?? string.Empty).Split(' '); }}
        #endregion

        public string ParentEditRecord { get; set; }
        public ParentEditRecordPropType ValidatorType { get { return ParentEditRecordPropType.NEEDS_VALIDATION; } }
    }
}