/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimeCommon;
using OutSystems.WidgetsRuntimeAPI;

namespace OutSystems.HubEdition.WebWidgets {
    public partial class CustomWidget : Container, IPostBackEventHandler, IWidgetWithBehaviors, IWidgetWithViewState {

        public CustomWidgetRtWidget RtWidget = new CustomWidgetRtWidget();

        public CustomWidget() { }

        protected override void OnAfterDataBind() {
            if (behaviors != null) {
                behaviors.Values.Apply(b => b.OnAfterDataBind());
            }

            base.OnAfterDataBind();
        }

        protected override void OnPreRender(EventArgs e) {
            if (behaviors != null) {
                behaviors.Values.Apply(b => b.OnRender());
            }

            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e) {
            if (behaviors != null) {
                behaviors.Values.Apply(b => b.OnLoad());
            }

            base.OnLoad(e);
        }

        
        public override void RenderBeginTag(HtmlTextWriter writer) {
            // do nothing
        }

        public override void RenderEndTag(HtmlTextWriter writer) {
            // do nothing
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument) {
            string eventName = null;
            var isCustomEvent = Page.Request.IsCustomAjaxEventRequest();
            var isBuiltInEvent = !isCustomEvent && Page.Request.IsBuiltInAjaxEventRequest();
            
            if (isCustomEvent || isBuiltInEvent) {
                eventName = Page.Request.GetAjaxEventName();
            }

            if (behaviors != null) {
                behaviors.Values.Apply(b => b.OnPostback());
            }

            if (isBuiltInEvent) {
                if (behaviors != null) {
                    behaviors.Values.Apply(b => b.OnBuiltInEventRaised(eventName));
                }
            } else if (isCustomEvent) {
                EventHandler handler;
                if (eventHandlers != null && eventHandlers.TryGetValue(eventName, out handler)) {
                    handler(this, EventArgs.Empty);
                }

                if (behaviors != null) {
                    behaviors.Values.Apply(b => b.OnAfterCustomEventRaised(eventName));
                }
            }
        }

        private Dictionary<string, EventHandler> eventHandlers;

        public void AddEventHandler(string eventName, EventHandler handler) {
            if (eventHandlers == null) {
                eventHandlers = new Dictionary<string, EventHandler>();
            } 
            eventHandlers[eventName] = handler;
        }

        private Dictionary<Type, WidgetBehavior> behaviors;

        public void AddBehavior(WidgetBehavior behavior) {
            if (behaviors == null) {
                behaviors = new Dictionary<Type, WidgetBehavior>();
            }
            behavior.Owner = this;
            behaviors.Add(behavior.GetType(), behavior);
        }

        public T GetBehavior<T>() where T : WidgetBehavior {
            return (T) behaviors.GetValueOrDefault(typeof(T));
        }

        public bool BehavesAs<T>(){
            return behaviors!=null && behaviors.Any(behavior => behavior.Value is T);
        }

        void IWidgetWithViewState.StorePropertyValue<T>(string propertyName, T value) {
            ViewState[propertyName] = value;
        }

        T IWidgetWithViewState.GetPropertyValue<T>(string propertyName) {
            return (T)ViewState[propertyName];
        }

        protected override bool SkipSaveViewState {
            get { return false; }
        }
        
        public string GetInlineAttributes() {
            var attributes = new StringBuilder();
            foreach (string attribute in Attributes.Keys) {

                if (!attribute.IsOneOf("anonymous", "style")) {
                    // #1019618 #SWAT-125 - escape not only the single quote but also all characters to avoid poorly generated HTML
                    var escapedAttribute = BuiltInFunction.EncodeHtmlAttribute(Attributes[attribute]);
                    attributes.Append(attribute + "='" + escapedAttribute + "' ");
                }
            }
            return attributes.ToString();
        }

        public string GetCssClass() {
            return CssClass.IsEmpty() ? "" : " " + BuiltInFunction.EncodeHtmlAttribute(CssClass);
        }

        public string GetStyle() {
            return Style.Value.IsEmpty() ? "" : " " + BuiltInFunction.EncodeHtmlAttribute(Style.Value);
        }
    }
}
