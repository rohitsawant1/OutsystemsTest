/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace OutSystems.RuntimeCommon.PubSub {

    public class InMemoryPubSubSubscription : ISubscription {
        private HashSet<string> topics;
        private object locker = new object();

        protected internal InMemoryPubSubSubscription() {
            this.topics = new HashSet<string>();
        }

        public event OnMessageCallback OnMessage;

        public void RaiseOnMessage(PubSubMessage msg) {
            OnMessage?.Invoke(msg);
        }

        public IEnumerable<string> GetSubscribedTopics() {
            return topics;
        }

        public void SubscribeTopic(string topic) {
            lock (locker) {
                topics.Add(topic);
            }
        }

        public void UnsubscribeAll() {
            lock (locker) {
                topics.Clear();
            }
        }

        public void UnsubscribeTopic(string topic) {
            lock (locker) {
                topics.Remove(topic);
            }
        }

        public void Dispose() {
            UnsubscribeAll();
        }
    }

    public class InMemoryPubSub : IPubSub {
        private HashSet<ISubscription> subscriptions;

        public InMemoryPubSub() {
            this.subscriptions = new HashSet<ISubscription>();
        }

        public void CancelAllSubscriptions() {
            subscriptions.Apply(sub => sub.UnsubscribeAll());
        }

        public ISubscription CreateEmptySubscription() {
            var sub = new InMemoryPubSubSubscription();
            this.subscriptions.Add(sub);
            return sub;
        }

        public void Dispose() { }

        public bool IsAvailable() {
            return true;
        }

        public bool IsAvailable(out Exception ex) {
            ex = null;
            return true;
        }

        public void Publish(string topic, string message) {
            this.subscriptions
                .Where(sub => sub.GetSubscribedTopics().Contains(topic))
                .Apply(sub => sub.RaiseOnMessage(new PubSubMessage(topic, message)));
        }

        public ISubscription Subscribe(string topic, OnMessageCallback onMessage) {
            var subscription = CreateEmptySubscription();
            subscription.OnMessage += onMessage;
            subscription.SubscribeTopic(topic);

            return subscription;
        }
   }
}
