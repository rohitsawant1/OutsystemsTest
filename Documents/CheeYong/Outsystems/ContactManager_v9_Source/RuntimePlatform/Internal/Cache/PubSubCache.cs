/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Caching;
using OutSystems.RuntimeCommon.PubSub;

namespace OutSystems.HubEdition.RuntimePlatform.Internal.Cache {
    public class PubSubCache : ICache {
        protected IPubSub pubSub;
        private readonly MemoryCache memoryCacheInstance;
        private const string CacheInvalidationContent = "OutSystems Cache File";
        private ISubscription subscription;
        private InvalidationFilter filter;

        public PubSubCache(IPubSub pubSubProvider, string cacheInstanceKey = null) {
            this.pubSub = pubSubProvider;
            this.memoryCacheInstance = new MemoryCache(this.pubSub.GetType().Name + (cacheInstanceKey ?? ""));
            this.subscription = pubSub.CreateEmptySubscription();
            this.filter = new InvalidationFilter();
            this.subscription.OnMessage += filter.OnMessageReceived;
        }

        public void Add(ICacheKey cacheKey, object value, ICacheDependency dependency, DateTime expirationDate, TimeSpan slidingSpan, RuntimeCommon.Caching.CacheItemPriority priority) {
            var policy = new CacheItemPolicy();
            { //configurations
                var depKeys = TransformDependency(dependency)?.ToList();
                if (!depKeys.IsNullOrEmpty()) {
                    foreach (var key in depKeys) {
                        subscription.SubscribeTopic(key);
                    }

                    var monitor = new PubSubMonitor(cacheKey.GetKeyAsString(), depKeys, filter);

                    policy.ChangeMonitors.Add(monitor);
                }

                policy.SlidingExpiration = slidingSpan == CacheUtils.NoSliding ?
                                                    ObjectCache.NoSlidingExpiration :
                                                    slidingSpan;

                policy.AbsoluteExpiration = expirationDate == CacheUtils.NoExpiration ?
                                                    ObjectCache.InfiniteAbsoluteExpiration :
                                                    expirationDate;

                policy.Priority = priority == RuntimeCommon.Caching.CacheItemPriority.NotRemovable ?
                                    System.Runtime.Caching.CacheItemPriority.NotRemovable :
                                    System.Runtime.Caching.CacheItemPriority.Default;
            }
            memoryCacheInstance.Set(cacheKey.GetKeyAsString(), value, policy);
        }
        
        public object Get(ICacheKey key) {
            return memoryCacheInstance.Get(key.GetKeyAsString());
        }

        public object GetOrAdd(ICacheKey key, CacheItemValueGetter getter, ICacheDependency dependency, DateTime expirationDate, TimeSpan slidingSpan, RuntimeCommon.Caching.CacheItemPriority priority) {
            var value = Get(key);
            if (value != null) {
                return value;
            }
            
            value = getter();
            Add(key, value, dependency, expirationDate, slidingSpan, priority);

            return value;
        }
        public void Invalidate(ICacheInvalidationKey dependency) {
            var topic = TransformDependency(dependency);
            try {
                pubSub.Publish(topic, filter.InstanceKey);
            } catch (Exception e){
                AppInfo appInfo = null;
                try {
                    appInfo = AppInfo.GetAppInfo();
                } catch { }
                Log.ErrorLog.LogApplicationError(new InvalidOperationException("Error invalidating cache. Check the Cache Invalidation Service status in the Environment Health page.", e), appInfo?.OsContext, "Server Side Cache");
            } finally {
                // Sending a message to invalidate local cache, without sending to RabbitMQ Server
                // This way, current application will immediatly see its cache invalidated
                filter.OnMessageReceived(new PubSubMessage(topic, "local Invalidation"));
            }
        }

        public void Listen(ICacheKey cacheKey, ICacheDependency dependency, CacheItemInvalidationCallback invalidationCallback) {
            var policy = new CacheItemPolicy();
            { //configurations
                var depKeys = TransformDependency(dependency)?.ToList();
                if (!depKeys.IsNullOrEmpty()) {
                    foreach (var key in depKeys) {
                        subscription.SubscribeTopic(key);
                    }
                    var monitor = new PubSubMonitor(cacheKey.GetKeyAsString(), depKeys, filter);

                    policy.ChangeMonitors.Add(monitor);
                }

                policy.SlidingExpiration = ObjectCache.NoSlidingExpiration;
                policy.AbsoluteExpiration = DateTime.UtcNow.AddDays(1);
                policy.Priority = System.Runtime.Caching.CacheItemPriority.NotRemovable;
                policy.UpdateCallback = EncapsulateListenerCallback(cacheKey, depKeys, invalidationCallback);
            }
            memoryCacheInstance.Set(cacheKey.GetKeyAsString(), 0, policy);
        }

        public object StopListen(ICacheKey key) {
            return memoryCacheInstance.Remove(key.GetKeyAsString());
        }

        private CacheEntryUpdateCallback EncapsulateListenerCallback(ICacheKey originalKey, List<string> depKeys, CacheItemInvalidationCallback invalidationCallback) {
            return (args) => {
                if (args.RemovedReason == CacheEntryRemovedReason.ChangeMonitorChanged || args.RemovedReason == CacheEntryRemovedReason.Expired) {
                    invalidationCallback?.Invoke();
                    args.UpdatedCacheItem = new CacheItem(originalKey.GetKeyAsString(), 0);
                    
                    var newPolicy = new CacheItemPolicy();
                    { //configurations
                        if (!depKeys.IsNullOrEmpty()) {
                            newPolicy.ChangeMonitors.Add(new PubSubMonitor(originalKey.GetKeyAsString(), depKeys, filter));
                        }
                        newPolicy.SlidingExpiration = ObjectCache.NoSlidingExpiration;
                        newPolicy.AbsoluteExpiration = DateTime.UtcNow.AddDays(1);
                        newPolicy.Priority = System.Runtime.Caching.CacheItemPriority.NotRemovable;
                        newPolicy.UpdateCallback = EncapsulateListenerCallback(originalKey, depKeys, invalidationCallback);
                    }
                    args.UpdatedCacheItemPolicy = newPolicy;
                }
            };
        }

        protected virtual IEnumerable<string> TransformDependency(ICacheDependency dependency) {
            return dependency?
                .DependencyInvalidationKeys()
                .Select(TransformDependency);
        }

        protected virtual string TransformDependency(ICacheInvalidationKey key) {
            return key.GetKeyAsString();
        }

        public void Clear() {
            // adapted from https://social.msdn.microsoft.com/Forums/vstudio/en-US/0295b899-c550-48c1-bd5d-841c45ec3c57/memorycache-clear-all?forum=csharpgeneral
            foreach (var key in memoryCacheInstance.Select(kvp => kvp.Key)) {
                memoryCacheInstance.Remove(key);
            }
        }

        public bool IsAvailable() {
            return pubSub.IsAvailable();
        }

        public bool IsAvailable(out Exception ex) {
            return pubSub.IsAvailable(out ex);
        }

        public void Dispose() {
            pubSub?.Dispose();
        }
    }
}