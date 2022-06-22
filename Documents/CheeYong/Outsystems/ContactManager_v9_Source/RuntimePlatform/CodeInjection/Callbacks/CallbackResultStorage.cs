/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.Callbacks {
    [Serializable]
    public sealed class CallbackResultStorage {
        private IDictionary<string, IDictionary<int, object>> _storageByLocale;
        private IDictionary<int, object> _singletonStorage;

        public CallbackResultStorage() {
            _storageByLocale = new ConcurrentDictionary<string, IDictionary<int, object>>();
            _singletonStorage = new ConcurrentDictionary<int, object>();
        }

        public void Store(int callbackId, string locale, object results) {
            var inLocale = _storageByLocale.GetOrAdd(locale, () => new ConcurrentDictionary<int, object>());
            inLocale[callbackId] = results;
        }

        public object Retrieve(int callbackId, string locale) {
            IDictionary<int, object> inLocale;
            if (!_storageByLocale.TryGetValue(locale, out inLocale)) {
                return null;
            }

            object obj;
            if (!inLocale.TryGetValue(callbackId, out obj)) {
                return null;
            }
            return obj;
        }

        public bool Has(int callbackId, string locale) {
            IDictionary<int, object> inLocale;
            if (!_storageByLocale.TryGetValue(locale, out inLocale)) {
                return false;
            }

            return inLocale.ContainsKey(callbackId);
        }

        public void StoreSingleton(int callbackId, object singleton) {
            _singletonStorage[callbackId] = singleton;
        }

        public object RetrieveSingleton(int callbackId) {
            object obj;
            if (!_singletonStorage.TryGetValue(callbackId, out obj)) {
                return null;
            }
            return obj;
        }

        public bool HasSingleton(int callbackId) {
            return _singletonStorage.ContainsKey(callbackId);
        }

        internal string GetDebugInformation() {
            StringBuilder result = new StringBuilder();
            result.Append(_getPropertyText("_storage", _storageByLocale));
            result.Append(_getPropertyText("_storage", _singletonStorage));
            return result.ToString();
        }

        private static string _getPropertyText<TKey, TValue>(string property, IDictionary<TKey, TValue> value) {
            if (value == null) { return GetPropertyText(property, "null"); }
            string toReturn = "";
            toReturn += "<br/>===============" + property + "===============<br/>";

            toReturn += "Count: " + value.Count;

            toReturn += "<table cellspacing=\"1\" cellpadding=\"1\" border=\"1\" align=\"center\">";

            foreach (KeyValuePair<TKey, TValue> entry in value) {

                toReturn += "<tr>" + "<td>" + property + "[" + entry.Key + "]" + "</td>" + "<td>" +
                    _getPropertyGetValue(property, entry.Key, entry.Value) +
                    "</td>" + "</tr>";
            }
            toReturn += "</table>";

            toReturn += "<br/><br/>";
            return toReturn;
        }

        private static string _getPropertyText(string property, Type type) {
            string toReturn = "";
            toReturn += "<table cellspacing=\"1\" cellpadding=\"1\" border=\"1\" align=\"center\">";

            toReturn += "<tr><td>Callback</td><td>" + type.Name + "</td></tr>";
            toReturn += "</table>";
            toReturn += "<br/><br/>";
            return toReturn;
        }

        private static string _getPropertyText(string property, AbstractCallback value) {
            return _getPropertyText(property, value.GetType());
        }

        private static string _getPropertyText(string property, IList value) {
            string toReturn = "";
            toReturn += "<br/>===============" + property + "===============<br/>";

            if (value == null) {
                toReturn += "null";
            } else {
                toReturn += "Count: " + value.Count;

                toReturn += "<table cellspacing=\"1\" cellpadding=\"1\" border=\"1\" align=\"center\">";

                foreach (object entry in value) {

                    toReturn += "<tr>" + "<td>" + property + "[#]" + "</td>" + "<td>" +
                        _getPropertyGetValue(property, "", entry) +
                        "</td>" + "</tr>";
                }
                toReturn += "</table>";
            }
            toReturn += "<br/><br/>";
            return toReturn;
        }

        private static string _getPropertyGetValue(string property, object key, object value) {
            if (value == null) {
                return "";
            }

            string propertyName = property + "[" + key + "]";
            AbstractCallback valueAsAbstractCallback = value as AbstractCallback;

            if (valueAsAbstractCallback != null) {
                return _getPropertyText(propertyName, valueAsAbstractCallback);
            }

            Type valueAsType = value as Type;

            if (valueAsType != null) {
                return _getPropertyText(propertyName, valueAsType);
            }

            IList valueAsIList = value as IList;

            if (valueAsIList != null) {
                return _getPropertyText(propertyName, valueAsIList);
            }

            // See if value is a dictionary
            Type valueType = value.GetType();
            Type iGenericDictionaryType = typeof(IDictionary<,>);

            if (valueType.IsGenericType && iGenericDictionaryType.IsAssignableFrom(valueType.GetGenericTypeDefinition())) {
                MethodInfo getPropertyTextMethod = typeof(CallbackResultStorage).GetMethod("_getPropertyText",
                    BindingFlags.Static | BindingFlags.NonPublic, null,
                    new Type[] { typeof(string), iGenericDictionaryType.MakeGenericType(valueType.GetGenericArguments()) }, null);

                getPropertyTextMethod.Invoke(null, new object[] { propertyName, value });
            }

            return BuiltInFunction.EncodeHtml(value.ToString());
        }

        internal static string GetPropertyText(string property, object value) {
            return GetPropertyText(property, (value == null ? "null" : value.ToString()));
        }

        internal static string GetPropertyText(string property, string value) {
            return
                "<br/>===============" + property + "===============<br/>" +
                value + "<br/>";
        }
    }
}