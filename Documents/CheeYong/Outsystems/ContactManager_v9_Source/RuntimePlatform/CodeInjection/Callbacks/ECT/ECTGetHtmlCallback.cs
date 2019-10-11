/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;

namespace OutSystems.HubEdition.RuntimePlatform.Callbacks.ECT {
    [Serializable]
    internal sealed partial class ECTGetHtmlCallback : StaticContentCallback {
        public ECTGetHtmlCallback(int callbackId, CodeInjectionFactory.Locations locationId, Invoke.WebServiceCallbackInvoke invoke)
            : base(callbackId, locationId, invoke) {
        }

        public override bool HideInProvider {
            get { return true; }
            set { }
        }

        public override bool IsLocalizable {
            get { return true; }
            set { }
        }

        public static bool IsEctDisabled(AppInfo app) {
            return app.OsContext != null && app.OsContext.ResponseDisabledFeedback;
        }

        protected override StaticContentCallback.EventListener BuildEventListenerInner(CallbackEvent evt, int espaceId, int tenantId) {
            return new EventListener(this, evt, espaceId, tenantId);
        }

        protected override string RetrieveContentInjection(AppInfo app, CallbackPageContext context) {
            if (IsEctDisabled(app) || !ECTShowFeedbackCallback.ShowFeedback(app)) {
                return string.Empty;
            } else {
                return base.RetrieveContentInjection(app, context);
            }
        }
    }
}