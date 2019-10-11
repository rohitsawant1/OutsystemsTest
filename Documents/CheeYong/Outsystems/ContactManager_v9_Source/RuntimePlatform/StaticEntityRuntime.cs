/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using OutSystems.HubEdition.RuntimePlatform.Internal;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;

namespace OutSystems.HubEdition.RuntimePlatform {
    public abstract class StaticEntityRuntime : IDisposable{
        public abstract class StaticRecordMetadata {
            protected object _dataId = null;
            public string Name = string.Empty;
            public ObjectKey Key = ObjectKey.Dummy;

            public Boolean Valid = false;

            //To convert the to the correct type at the beginning
            protected abstract object IdReader(IDataReader r);

            /// <summary>
            /// Read a record from database
            /// </summary>
            /// <param name="r"> Data base reader</param>
            public void Read(IDataReader r) {
                Object column = null;
                try {
                    _dataId = IdReader(r); //So conversion is only done once

                    column = r["Name"];
                    Name = (column != System.DBNull.Value ? (string)column : string.Empty);

                    column = r["SS_Key"];
                    Key = (column != System.DBNull.Value ? ObjectKey.Parse((string)column) : ObjectKey.Dummy);

                    Valid = true;
                } catch (Exception excep) {
                    throw new System.InvalidCastException("Could not load the Record Metadata: " + excep.Message);
                }
            }
        }

        protected int EspaceId;
        protected ObjectKey EntityKey;
        protected Hashtable _recordsByIdByLocale;
        private Hashtable _recordsMetaByName;
        private IDictionary<ObjectKey, StaticRecordMetadata> _recordsMetaByKey;
        private volatile bool cacheControl = false;
        private string instanceId;

        protected abstract StaticRecordMetadata newStaticRecord();

        private void Init(int espaceId, ObjectKey entityKey) {
            EspaceId = espaceId;
            EntityKey = entityKey;
            _recordsByIdByLocale = new Hashtable();
            _recordsMetaByName = new Hashtable();
            _recordsMetaByKey = new Dictionary<ObjectKey, StaticRecordMetadata>();
            instanceId = Guid.NewGuid().ToString();

            lock (_recordsMetaByKey) {
                InitRecordsCacheWithCache();
            }
        }

        protected StaticEntityRuntime(int espaceId, ObjectKey entityKey) {
            Init(espaceId, entityKey);
        }

        protected StaticEntityRuntime(ObjectKey espaceKey, ObjectKey entityKey) {
            int espaceId;

            using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                espaceId = DBRuntimePlatform.Instance.GetESpaceIdbyKey(trans, espaceKey);
            }

            Init(espaceId, entityKey);
        }

        public Hashtable RecordsById(string locale) {
            if (!cacheControl) {
                lock (_recordsMetaByKey) { //always use the same item to lock
                    if (!cacheControl) {
                        ClearCache();
                        InitRecordsCache();
                    }
                }
            }

            //this could be locked ..but the worst case is that it needs to make some extra queries
            Hashtable recordsById = (Hashtable)_recordsByIdByLocale[locale];
            if (recordsById == null) {
                recordsById = new Hashtable();
                _recordsByIdByLocale[locale] = recordsById;
            }
            return recordsById;
        }

        private Hashtable RecordsMetaByName {
            get {
                if (!cacheControl) {
                    lock (_recordsMetaByKey) { //always use the same item to lock
                        if (!cacheControl) {
                            ClearCache();
                            InitRecordsCache();
                        }
                    }
                }
                return _recordsMetaByName;
            }
        }

        private IDictionary<ObjectKey, StaticRecordMetadata> RecordsMetaByKey {
            get {
                if (!cacheControl) {
                    lock (_recordsMetaByKey) { //always use the same item to lock
                        if (!cacheControl) {
                            ClearCache();
                            InitRecordsCache();
                        }
                    }
                }
                return _recordsMetaByKey;
            }
        }

        protected virtual bool UseCache { get { return true; } }

        private void InitRecordsCache() {
            LoadAllEntriesMetadata();
            cacheControl = true;
        }

        private void InitRecordsCacheWithCache() {
            InitRecordsCache();
            if (UseCache) {
                RuntimeCache.Instance.Listen(
                            new CacheKey("recordsCacheCache" + EntityKey + "_" + EspaceId + "_" + instanceId),
                            new EspaceTenantDependency(EspaceId, 0),
                            InvalidateRecordsCache);
            }
        }

        private void InvalidateRecordsCache() { 
            lock (_recordsMetaByKey) {
                if (cacheControl) {
                    cacheControl = false;
                }
            }
        }

        protected void AddToMetadataCache(StaticRecordMetadata meta) {
            if (meta != null && meta.Valid) {
                lock (_recordsMetaByKey) {
                    if (meta.Name != null)
                        _recordsMetaByName[meta.Name] = meta;
                    if (meta.Key != null)
                        _recordsMetaByKey[meta.Key] = meta;
                }
            }
        }

        public void ClearCache() {
            OSTrace.Debug("StaticEntityRuntime.ClearCache: Clearing cache for " + ObjectKeyUtils.DatabaseValue(EntityKey) + ".");
            _recordsMetaByName.Clear();
            _recordsMetaByKey.Clear();
            foreach (Hashtable recordsById in _recordsByIdByLocale.Values) {
                recordsById.Clear();
            }
        }

        protected void LoadAllEntriesMetadata() {
            using (OSTrace.Timer("StaticEntityRuntime.LoadAllEntriesMetadata: Loading metadata for " + ObjectKeyUtils.DatabaseValue(EntityKey) + ".")) {
                using (Transaction tran = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                    using (IDataReader reader = DBRuntimePlatform.Instance.GetStaticRecordsByEntity(tran, EntityKey, EspaceId)) {
                        int count = 0;
                        while (reader.Read()) {
                            StaticRecordMetadata record = newStaticRecord();
                            record.Read(reader);
                            AddToMetadataCache(record);
                            count++;
                        }
                        OSTrace.Debug("StaticEntityRuntime.LoadAllEntriesMetadata: Loaded " + count + " metadata records.");
                    }
                }
            }
        }

        protected StaticRecordMetadata GetRecordMetadataByName( string name) {
            StaticRecordMetadata record = (StaticRecordMetadata)RecordsMetaByName[name];
            if (record == null || !record.Valid) {
                record = newStaticRecord();
                
                using (Transaction systemTransaction = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                    using (IDataReader reader = DBRuntimePlatform.Instance.GetStaticRecordByName(systemTransaction, name, EntityKey, EspaceId)) {
                        if (reader.Read()) {
                            record.Read(reader);
                            AddToMetadataCache(record);
                        } else {
                            //Not found on db so we can return a empty record
                            OSTrace.Error("GetRecordMetadataByName(Name=" + name +
                                          ", EntityKey=" + ObjectKeyUtils.DatabaseValue(EntityKey) +
                                          ", EspaceId=" + EspaceId + ") found no metadata!");
                        }
                    }
                }
            }
            return record;
        }

        protected StaticRecordMetadata GetRecordMetadataByKey( ObjectKey key) {
            StaticRecordMetadata record;
            if (!RecordsMetaByKey.TryGetValue(key, out record) || record == null || !record.Valid) {
                record = newStaticRecord();
                
                using (Transaction systemTransaction = DatabaseAccess.ForRuntimeDatabase.GetReadOnlyTransaction()) {
                    using (IDataReader reader = DBRuntimePlatform.Instance.GetStaticRecordBykey(systemTransaction, key, EntityKey, EspaceId)) {
                        if (reader.Read()) {
                            record.Read(reader);
                            AddToMetadataCache(record);
                        } else {
                            //Not found on db so we can return a empty record
                            OSTrace.Error("GetRecordMetadataByKey(Key=" + ObjectKeyUtils.DatabaseValue(key) +
                                          ", EntityKey=" + ObjectKeyUtils.DatabaseValue(EntityKey) +
                                          ", EspaceId=" + EspaceId + ") found no metadata!");
                        }
                    }
                }
            }
            return record;
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
