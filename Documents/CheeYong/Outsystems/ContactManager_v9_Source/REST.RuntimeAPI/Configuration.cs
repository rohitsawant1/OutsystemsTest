/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.Internal.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using OutSystems.RuntimeCommon.Caching;
using OutSystems.HubEdition.RuntimePlatform.Internal;

namespace OutSystems.REST {
    /// <summary>
    /// Stores configuration parameters on how to connect to a REST API. Each Consume REST API has the corresponding associated configuration.
    /// </summary>
    public class Configuration {
        private const string ConfigPluginName = "RESTConsume";

        /// <summary>
        /// The URL of the REST web service.
        /// </summary>
        public String Url { get; set; }

        /// <summary>
        /// The username to use on requests.
        /// </summary>
        public String Username { get; set; }

        /// <summary>
        /// User's password for the service.
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Controls whether errors should be traced or not.
        /// </summary>
        public bool TraceErrors { get; set; }

        /// <summary>
        /// Controls whether a request should be traced, even if finishes normally.
        /// </summary>
        public bool TraceAll { get; set; }

        /// <summary>
        /// Controls whether a request should be traced.
        /// </summary>
        public bool Trace {
            get {
                return TraceErrors || TraceAll;
            }
        }

        /// <summary>
        /// Constructs a new Configuration object with the given parameters.
        /// </summary>
        /// <param name="url">URL to connect to.</param>
        /// <param name="username">Username to use.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="traceErrors"><code>bool</code> indicating wether errors should be traced at runtime.</param>
        /// <param name="traceAll"><code>bool</code> indicating wether tracing should enable at runtime, even when errors do not occurr.</param>
        private Configuration(string url, String username, String password, bool traceErrors, bool traceAll) {
            Url = url;
            Username = username;
            Password = password;
            TraceErrors = traceErrors;
            TraceAll = traceAll;
        }

        /// <summary>
        /// Return a previously defined REST API Configuration, based on its Service Studio key and eSpace Id.
        /// </summary>
        /// <param name="clientSSKey">The Service Studio key of the REST API source.</param>
        /// <param name="eSpaceId">The eSpace Id.</param>
        /// <param name="eSpaceKey">The eSpace Key.</param>
        /// <param name="defaultUrlOverride"></param>
        /// <param name="defaultUserNameOverride"></param>
        /// <param name="defaultPasswordOverride"></param>
        /// <returns>The corresponding Configuration.</returns>
        public static Configuration GetClientConfiguration(string clientSSKey, int eSpaceId, string eSpaceKey, string defaultUrlOverride = null, string defaultUserNameOverride = null, string defaultPasswordOverride = null) {
            Func<Configuration> fetchSettings = () => {
                var urlSetting = RuntimePlatformSettings.Plugin.GetSetting<string>(ConfigPluginName, eSpaceKey, clientSSKey, "Effective_URL", String.Empty);
                var usernameSetting = RuntimePlatformSettings.Plugin.GetSetting<string>(ConfigPluginName, eSpaceKey, clientSSKey, "Effective_Username", String.Empty);
                var passwordSetting = RuntimePlatformSettings.Plugin.GetSetting<string>(ConfigPluginName, eSpaceKey, clientSSKey, "Effective_Password", String.Empty, isEncrypted: true);
                var traceErrorsSetting = RuntimePlatformSettings.Plugin.GetSetting<bool>(ConfigPluginName, eSpaceKey, clientSSKey, "TraceErrors", false);
                var traceAllSetting = RuntimePlatformSettings.Plugin.GetSetting<bool>(ConfigPluginName, eSpaceKey, clientSSKey, "TraceAll", false);

                var url = urlSetting.GetValue();
                var username = usernameSetting.GetValue();
                var password = passwordSetting.GetValue();

                if (defaultUrlOverride != null && String.IsNullOrEmpty(url)) {
                    url = defaultUrlOverride;
                }

                if (defaultUserNameOverride != null && String.IsNullOrEmpty(username)) {
                    username = defaultUserNameOverride;
                }

                if (defaultPasswordOverride != null && String.IsNullOrEmpty(password)) {
                    // Can't be done directly in the setting defaults since it's still encrypted. 
                    password = passwordSetting.LoadFromString(defaultPasswordOverride);
                }
                var traceErrors = traceErrorsSetting.GetValue();
                var traceAll = traceAllSetting.GetValue();

                return new Configuration(url, username, password, traceErrors, traceAll);
            };

            return ConfigurationCache.GetESpaceCachedValue(clientSSKey, "RestConfigCache", eSpaceId, _ => fetchSettings());
        }


        private static class ConfigurationCache {
            private static readonly object lockObject = new object();
            private static bool reentrantCall = false;

            public static Configuration GetESpaceCachedValue(string key, String cacheName, int eSpaceId, Func<string, Configuration> Getter) {
                String cacheKey = cacheName + eSpaceId + key;
                return InnerGetCachedValue(cacheKey, cacheName, Getter, eSpaceId);
            }

            private static Configuration InnerGetCachedValue(string key, String cacheName, Func<string, Configuration> Getter, int cacheExtraId) {
                lock (lockObject) {
                    if (reentrantCall) {
                        throw new InvalidOperationException("Reentrant call in AppCache for key: " + key);
                    }
                    reentrantCall = true;
                    try {
                        return (Configuration)RuntimeCache.Instance.GetOrAdd(
                                                                                new CacheKey(key),
                                                                                () => Getter(key),
                                                                                new EspaceTenantDependency(cacheExtraId, 0),
                                                                                DateTime.UtcNow.AddDays(1),
                                                                                TimeSpan.Zero,
                                                                                CacheItemPriority.Removable);
                    } finally {
                        reentrantCall = false;
                    }
                }
            }
        }
    }
}