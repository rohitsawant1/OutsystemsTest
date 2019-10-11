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
    internal sealed partial class ECTShowFeedbackCallback : AbstractNotContentCallback {

        // It's OK to store this in a static because there should be only one
        // ECT-type callback present
        private readonly static int ectCallbackId = -1;

        public ECTShowFeedbackCallback(int callbackId, CodeInjectionFactory.Locations locationId, Invoke.WebServiceCallbackInvoke invoke)
            : base(ectCallbackId, locationId, invoke) {
        }

        public override bool HideInProvider {
            get { return true; }
            set { }
        }

        public override bool IsLocalizable {
            get { return false; }
            set { }
        }

        public override AbstractCallback.EventListener BuildEventListener(CallbackEvent evt, int espaceId, int tenantId) {
            return new EventListener(this, evt, espaceId, tenantId);
        }

        public override void StoreResults(CallbackEvent evt, AppInfo app, SessionInfo session, object results) {
            StoreResults(evt, app, session, (string) results);
        }

        private void StoreResults(CallbackEvent evt, AppInfo app, SessionInfo session, string results) {
            string[] pairs = results.Split('|');
            for (int i = 0; i < pairs.Length; i = i + 2) {
                if (pairs[i].ToLower() == "show") {
                    bool show = Boolean.Parse(pairs[i + 1]);
                    int userId = (session == null) ? 0 : session.UserId;
                    IDictionary<int, bool> cache = (IDictionary<int, bool>)app.CallbackResults.RetrieveSingleton(_id);
                    if (cache == null) { cache = new Dictionary<int, bool>(); }
                    
                    cache[userId] = show;
                    app.CallbackResults.StoreSingleton(this._id, cache);
                }
            }
        }

        public static bool ShowFeedback(AppInfo app) {
            IDictionary<int, bool> cache = (IDictionary<int, bool>)app.CallbackResults.RetrieveSingleton(ectCallbackId);
            SessionInfo session = (app.OsContext == null) ? null : app.OsContext.Session;
            int userId = (session == null) ? 0 : session.UserId;
            
            if (cache == null || !cache.ContainsKey(userId)) {
                app.InjectionCache.RunCallbacks(app, session, CallbackEvent.GetHtmlForUser);
                cache = (IDictionary<int, bool>)app.CallbackResults.RetrieveSingleton(ectCallbackId);
            }

            return cache[userId];
        }
    }
}