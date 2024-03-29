/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using Newtonsoft.Json;
using OutSystems.Internal.Db;
using OutSystems.RuntimeCommon;
using System.Collections.Generic;
using System.Data;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.HubEdition.RuntimePlatform.NewRuntime {
    public class ApplicationInfoGenerator {
    
        public static ModuleDefinitions DeserializeToModuleDefinitions(string payload) {
            return JsonConvert.DeserializeObject<ModuleDefinitions>(payload, new JsonSerializerSettings() { DateParseHandling = DateParseHandling.None });
        }
        
        public ApplicationInfo GenerateApplicationInfo(Transaction trans, ISettingsProvider settingsProvider, string manifestContent, string[] entityModuleNames, string moduleDefinitions, string espaceName, int espaceId, int espaceVersionId, string espaceUID, IEnumerable<GlobalObjectKey> staticEntityKeys) {
            var applicationInfo = new ApplicationInfo(manifestContent, entityModuleNames);
            applicationInfo.Data.ApplicationDefaultTimeout = settingsProvider.Get(RuntimePlatformSettings.Application.DefaultTimeout);
            applicationInfo.Data.HasTracingEnabled = ShouldEnableTracing();

            var moduleDefinitionsJson = DeserializeToModuleDefinitions(moduleDefinitions);

            GetStaticEntities(trans, moduleDefinitionsJson, staticEntityKeys);
            applicationInfo.Data.ModuleDefinitions = moduleDefinitionsJson;

            return applicationInfo;
        }

        protected virtual ModuleDefinitions GetStaticEntities(Transaction trans, ModuleDefinitions modules, IEnumerable<GlobalObjectKey> entityKeys) {
            foreach (var entityGlobalKey in entityKeys) {
                var eSpaceKey = entityGlobalKey.OwnerKey.AsGuid.ToString();
                var entityKey = entityGlobalKey.Key.AsGuid.ToString();
                var staticRecords = GetStaticRecords(trans, entityGlobalKey);

                var module = modules.GetOrAdd(eSpaceKey, () => new ModuleDefinition());
                var staticEntities = module.StaticEntities ?? new StaticEntities();
                staticEntities.Add(entityKey, staticRecords);
            }

            return modules;
        }

        private static bool ShouldEnableTracing() {
            return OSTrace.getRealLogLevel().TraceVerbose || RuntimePlatformSettings.Debug.ForceClientSideTracing.GetValue();
        }


        private Records GetStaticRecords(Transaction trans, GlobalObjectKey staticEntityGlobalKey) {
            var records = new Records();

            using (IDataReader reader = DBRuntimePlatform.Instance.GetStaticRecordsByEntity(trans, staticEntityGlobalKey.Key, staticEntityGlobalKey.OwnerKey)) {
                while (reader.Read()) {
                    var dataId = reader.SafeGet<string>("DATA_ID");
                    var ssKey = reader.SafeGet<string>("SS_KEY");

                    records.Add(ssKey, dataId);
                }
            }

            return records;
        }

        public string SerializeApplicationInfoToJSON(ApplicationInfo appInfo) {
            return JsonConvert.SerializeObject(appInfo);
        }

        public string GetApplicationInfoJSON(Transaction trans, ISettingsProvider settingsProvider, string manifestContent, string[] entityModuleNames, string moduleDefinitions, string espaceName, int espaceId, int espaceVersionId, string espaceUID, IEnumerable<GlobalObjectKey> staticEntities) {
            return SerializeApplicationInfoToJSON(GenerateApplicationInfo(
                trans,
                settingsProvider,
                manifestContent,
                entityModuleNames,
                moduleDefinitions,
                espaceName,
                espaceId,
                espaceVersionId,
                espaceUID,
                staticEntities));
        }
    }
}
