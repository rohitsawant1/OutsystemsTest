/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.HubEdition.RuntimePlatform.Callbacks.Invoke;

namespace OutSystems.HubEdition.RuntimePlatform.Callbacks {
    [Serializable]
    public abstract partial class AbstractCallback : ICodeInjectionElement {
        protected AbstractCallbackInvoke _invoke;

        [NonSerialized]
        private bool _hideInProvider;
        [NonSerialized]
        private bool _localizable;
        protected int _id;
        protected CodeInjectionFactory.Locations _locationId;

        public AbstractCallback(int id, CodeInjectionFactory.Locations locationId, AbstractCallbackInvoke invoke) {
            _invoke = invoke;
            _id = id;
            _locationId = locationId;
        }

        public CodeInjectionFactory.Locations GetLocation() {
            return _locationId;
        }

        public string ProviderName {
            get { return _invoke.ProviderName; }
        }

        public virtual bool HideInProvider {
            get { return _hideInProvider; }
            set { _hideInProvider = value; }
        }

        public virtual bool IsLocalizable {
            get { return _localizable; }
            set { _localizable = value; }
        }

        public string EffectiveLocale {
            get { return IsLocalizable ? BuiltInFunction.GetCurrentLocale().ToLowerInvariant() : null; }
        }

        public virtual bool ForceHandleEvent(CallbackEvent evt) {
            return IsLocalizable && (evt == CallbackEvent.SessionStart || evt == CallbackEvent.ChangeLocale);
        }

        public virtual object Invoke(AppInfo app, SessionInfo session, AbstractCallback.EventListener listener) {
            return _invoke.Invoke(EffectiveLocale, app, session, listener);
        }

        public abstract AbstractCallback.EventListener BuildEventListener(CallbackEvent evt, int espaceId, int tenantId);

        public abstract void StoreResults(CallbackEvent evt, AppInfo app, SessionInfo session, object results);
        public abstract string RetrieveContentInjection(AppInfo app, SessionInfo session, CallbackPageContext context);
        
        #region Utils
        protected void StoreResultsInStorage(CallbackResultStorage storage, object results) {
            string locale = EffectiveLocale;
            if (locale != null) {
                storage.Store(this._id, locale, results);
            } else {
                storage.StoreSingleton(this._id, results);
            }
        }

        protected object RetrieveResultsFromStorage(CallbackResultStorage storage) {
            string locale = EffectiveLocale;
            if (locale != null) {
                return storage.Retrieve(this._id, locale);
            } else {
                return storage.RetrieveSingleton(this._id);
            }
        }
        #endregion

        #region Equals / GetHashCode
        public override sealed bool Equals(object obj) {
            return obj is AbstractCallback && Equals((AbstractCallback) obj);
        }

        private bool Equals(AbstractCallback obj) {
            return _invoke.Equals(obj._invoke);
        }

        public override sealed int GetHashCode() {
            return _invoke.GetHashCode();
        }
        #endregion
    }
}