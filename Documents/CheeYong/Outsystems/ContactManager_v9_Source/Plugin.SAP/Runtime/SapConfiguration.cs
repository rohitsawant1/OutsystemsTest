/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Internal;
using OutSystems.Internal.Db;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;
using System;

namespace OutSystems.Plugin.SAP {
    public class SapConfiguration {
        public string SapRouterString { get; set; }
        public string ApplicationServer { get; set; }
        public string InstanceNumber { get; set; }
        public string SystemId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Client { get; set; }
        public string Language { get; set; }
        public string DefaultSapRouterString { get; set; }
        public string DefaultApplicationServer { get; set; }
        public string DefaultInstanceNumber { get; set; }
        public string DefaultSystemId { get; set; }
        public string DefaultUsername { get; set; }
        public string DefaultPassword { get; set; }
        public string DefaultClient { get; set; }
        public string DefaultLanguage { get; set; }
        public bool TraceAll { get ; set ; }
            
        public SapConfiguration() : this("","","","","","","","",
                                        "","","","","","","","", false) { }
        public SapConfiguration(
            string sapRouterString, 
            string applicationServer,
            string instanceNumber,
            string systemId,
            string username,
            string password,
            string client, 
            string language, 
            string defaultSapRouterString, 
            string defaultApplicationServer, 
            string defaultInstanceNumber, 
            string defaultSystemId, 
            string defaultUsername, 
            string defaultPassword, 
            string defaultClient, 
            string defaultLanguage,
            bool traceAll)
        {
            SapRouterString = sapRouterString;
            ApplicationServer = applicationServer;
            InstanceNumber = instanceNumber;
            SystemId = systemId;
            Username = username;
            Password = password;
            Client = client;
            Language = language;
            DefaultSapRouterString = defaultSapRouterString;
            DefaultApplicationServer = defaultApplicationServer;
            DefaultInstanceNumber = defaultInstanceNumber;
            DefaultSystemId = defaultSystemId;
            DefaultUsername = defaultUsername; 
            DefaultPassword = defaultPassword; 
            DefaultClient = defaultClient;
            DefaultLanguage = defaultLanguage;    
            TraceAll = traceAll;
        }

        public static SapConfiguration GetCustomClientConfiguration(string sapWebRefSSKey, int eSpaceId, string eSpaceKey,
            string defaultSapRouterStringOverride = null,
            string defaultApplicationServerOverride = null,
            string defaultInstanceNumberOverride = null,
            string defaultSystemIdOverride = null,
            string defaultUsernameOverride = null,
            string defaultPasswordOverride = null,
            string defaultClientOverride = null,
            string defaultLanguageOverride = null
            ) {
        Func<SapConfiguration> fetchSettings = () => {
            var pluginName = "SAP";

            // get effective url, username and password
            var sapRouterString = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_SapRouterString", defaultSapRouterStringOverride ?? String.Empty).GetValue().Trim();
            var applicationServer = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_ApplicationServer", defaultApplicationServerOverride ?? String.Empty).GetValue().Trim();
            var instanceNumber = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_InstanceNumber", defaultInstanceNumberOverride ?? String.Empty).GetValue().Trim();
            var systemId = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_SystemId", defaultSystemIdOverride ?? String.Empty).GetValue();
            var username = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_Username", defaultUsernameOverride ?? String.Empty).GetValue();
            var password = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_Password", defaultPasswordOverride ?? String.Empty, isEncrypted: true).GetValue();
            var client = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_Client", defaultClientOverride ?? String.Empty).GetValue();
            var language = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "Effective_Language", defaultLanguageOverride ?? String.Empty).GetValue();
            var defaultSapRouterString = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "sapRouterString", String.Empty).GetValue();
            var defaultApplicationServer = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "applicationServer", String.Empty).GetValue();
            var defaultInstanceNumber = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "instanceNumber", String.Empty).GetValue();
            var defaultSystemId = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "systemId", String.Empty).GetValue();
            var defaultUsername = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "username", String.Empty).GetValue();
            var defaultPassword = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "password", String.Empty, isEncrypted: true).GetValue();
            var defaultClient = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "client", String.Empty).GetValue();
            var defaultLanguage = RuntimePlatformSettings.Plugin.GetSetting<string>(pluginName, eSpaceKey, sapWebRefSSKey, "language", String.Empty).GetValue();
            var traceAll = RuntimePlatformSettings.Plugin.GetSetting<bool>(pluginName, eSpaceKey, sapWebRefSSKey, "TraceAll", false).GetValue();

            return new SapConfiguration(sapRouterString, applicationServer, instanceNumber, systemId, username,
                password, client, language, defaultSapRouterString, defaultApplicationServer, defaultInstanceNumber,
                defaultSystemId, defaultUsername, defaultPassword, defaultClient, defaultLanguage, traceAll);
        };

            return ConfigurationCache.GetESpaceCachedValue(sapWebRefSSKey, "SAPConfigCache", eSpaceId, _ => fetchSettings());
        }

        private static class ConfigurationCache {
            private static readonly object lockObject = new object();
            private static bool reentrantCall = false;

            public static SapConfiguration GetESpaceCachedValue(string key, String cacheName, int eSpaceId, Func<string, SapConfiguration> Getter) {
                String cacheKey = cacheName + eSpaceId + key;
                return InnerGetCachedValue(cacheKey, cacheName, Getter, eSpaceId);
            }

            private static SapConfiguration InnerGetCachedValue(string key, String cacheName, Func<string, SapConfiguration> Getter, int cacheExtraId) {
                lock (lockObject) {
                    if (reentrantCall) {
                        throw new InvalidOperationException("Reentrant call in AppCache for key: " + key);
                    }
                    reentrantCall = true;
                    try {
                        return (SapConfiguration)RuntimeCache.Instance.GetOrAdd(
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
