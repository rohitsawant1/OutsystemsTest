/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
    public sealed class HyperLink : ViewStateSpecializations.ViewStateLessHyperLink, IBreakPointControl, IOSControl {

        private string _confirmMessage;

        public string ConfirmationMessage {
            get {
                return _confirmMessage;
            }
            set {
                _confirmMessage = value;
            }
        }
        public override void RenderControl(HtmlTextWriter writer) {
            // disable relative-to-absolute translations by ASP.NET 2.0, as they don't do what we want
            if (((OSPage)Page).QuirksMode) {
                base.RenderControl(
                    new HtmlTextWriterOverriderForWebControls(writer,
                        new HtmlTextWriterAttribute[] { HtmlTextWriterAttribute.Href, HtmlTextWriterAttribute.Disabled },
                        new string[] { NavigateUrl, null }));
            } else {
                base.RenderControl(
                    new HtmlTextWriterOverriderForWebControls(writer,
                        new HtmlTextWriterAttribute[] { HtmlTextWriterAttribute.Href },
                        new string[] { NavigateUrl }));
            }
        }

        //public override bool SupportsDisabledAttribute { get { return true; } }

        protected override void AddAttributesToRender(HtmlTextWriter writer) {
            string onClickText = Attributes["onclick"];
            if (onClickText != null) {
                Attributes.Remove("onclick");
            }

            onClickText = JavaScriptManager.GetControlWithConfirmMessageOnClickCode(ClientID, onClickText, _confirmMessage);

            // TODO JMR #585790 uncommend SupportsDisabledAttribute override and delete this block when targetting .net 4.0+
            if (!Enabled) { // Not setting the Enabled to false like other widgets because we need it to prevent base.AddAttributesToRender from rendering the href
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, ((OSPage)Page).QuirksMode ? null : "disabled");
            }

            if (onClickText.Length > 0) {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, onClickText);
            }

            base.AddAttributesToRender(writer);
        }

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

        // Fix for stackoverflow on exceptions during DataBind
        protected override void DataBindChildren() {
            if (!this.HasControls())
                return;

            int count = this.Controls.Count;
            for (int index = 0; index < count; ++index)
                this.Controls[index].DataBind();
        }

        #endregion
        
        #region IOSControl members
        string IOSControl.TagName { get { return this.TagName; } }
        string[] IOSControl.CssClass { get { return this.CssClass.Split(' '); } }
        #endregion
	}
}