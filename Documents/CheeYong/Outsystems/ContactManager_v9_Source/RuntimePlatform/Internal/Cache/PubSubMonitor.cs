/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.PubSub;

namespace OutSystems.HubEdition.RuntimePlatform.Internal.Cache {
    internal class PubSubMonitor : ChangeMonitor {
        private readonly List<string> topics;
        private readonly string cacheKey;
        private readonly InvalidationFilter filter;
        private volatile bool monitorDisposed = false;
        public PubSubMonitor(string cacheKey, List<string> topics, InvalidationFilter filter) : base() {
            bool initialized = false;
            try {
                this.cacheKey = cacheKey;
                this.topics = topics;
                this.filter = filter;
                this.filter.RegisterForTopics(this.InnerOnChange, topics);
                initialized = true;
            } finally {
                InitializationComplete();
                if (!initialized) {
                    Dispose();
                }
            }
        }

        private void InnerOnChange(PubSubMessage message) {
            lock (this) {
                if (!monitorDisposed) {
                    this.filter.UnregisterForTopics(this.InnerOnChange, topics);
                    try {
                        base.OnChanged(message);
                    } catch (Exception ex) {
                        OSTrace.Error($"Error notifing PubSubMonitor change for topic: {UniqueId}. Possible due to Application Unload.", ex);
                    }
                }
            }
        }

        public override string UniqueId => cacheKey + "[" + Guid.NewGuid().ToString() + "]";

        protected override void Dispose(bool disposing) {
            lock (this) {
                this.filter.UnregisterForTopics(this.InnerOnChange, topics);
                monitorDisposed = true;
            }
        }
    }
}