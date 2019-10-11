/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;

namespace OutSystems.HubEdition.RuntimePlatform.Internal {
    public class DeploymentZoneResolution {
        private static readonly string ZONE_CACHE_BY_KEY_PREFIX = "DeploymentZoneResolution_ZoneByKey_";
        private static readonly string MODULE_KEY_CACHE_BY_NAME_PREFIX = "DeploymentZoneResolution_ModulekeyByName_";

        public static string ByModuleKeyWithScheme(ObjectKey moduleKey) {
            var zoneSettings = ByModuleKey(moduleKey);
            return $"{(zoneSettings.EnableHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp)}://{zoneSettings.Address}";
        }
        

        public struct ZoneSettings {
            public bool EnableHttps;
            public string Address;

            public ZoneSettings(bool enableHttps, string address) {
                EnableHttps = enableHttps;
                Address = address;
            }
        }

        public static ZoneSettings ByModuleKey(ObjectKey moduleKey) {
            var zoneCacheKey = ZONE_CACHE_BY_KEY_PREFIX + moduleKey;

            if (RuntimeCache.Instance.Get(new CacheKey(zoneCacheKey)) is ZoneSettings settings) {
                return settings;
            }

            string zoneAddress;
            ZoneSettings zoneSettings;
            int moduleId;
            using (var tran = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                DBRuntimePlatform.Instance.GetModuleNameAndIdByKey(tran, moduleKey, out string moduleName, out moduleId);

                zoneSettings = DBRuntimePlatform.Instance.GetDeploymentZoneAddressByModuleKey(tran, moduleKey);
            }

            zoneAddress = zoneSettings.Address;
            if (zoneAddress != null) {
                if (zoneAddress.IsEmpty()) {
                    zoneAddress = RuntimePlatformSettings.Misc.InternalAddress.GetValue();
                }

                zoneSettings = new ZoneSettings(zoneSettings.EnableHttps, zoneAddress);
                InsertCache(zoneCacheKey, zoneSettings, moduleId);
                return zoneSettings;
            }

            return new ZoneSettings(false, RuntimePlatformSettings.Misc.InternalAddress.GetValue());
        }

        public static ZoneSettings ByModuleName(string moduleName) {
            var moduleCacheKey = MODULE_KEY_CACHE_BY_NAME_PREFIX + moduleName;

            if (!(RuntimeCache.Instance.Get(new CacheKey(moduleCacheKey)) is ObjectKey moduleKey)) {

                int moduleId;
                using (var tran = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                    DBRuntimePlatform.Instance.GetModuleKeyAndIdByName(tran, moduleName, out moduleKey, out moduleId);
                }
                
                InsertCache(moduleCacheKey, moduleKey, moduleId);
            }

            return ByModuleKey(moduleKey);
        }

        private static void InsertCache(string key, object value, int moduleId) {
            RuntimeCache.Instance.Add(
                    new CacheKey(key),
                    value,
                    new EspaceTenantDependency(moduleId, 0),
                    DateTime.UtcNow.AddDays(1),
                    TimeSpan.Zero,
                    CacheItemPriority.NotRemovable);
        }
    }
}
