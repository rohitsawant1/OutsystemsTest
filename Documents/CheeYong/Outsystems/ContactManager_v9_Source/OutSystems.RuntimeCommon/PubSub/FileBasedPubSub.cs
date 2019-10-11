/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using OutSystems.RuntimeCommon.Log;

namespace OutSystems.RuntimeCommon.PubSub {

    internal static class FileBasedPubSubUtils {
        internal static string GetFilePath(string basePath, string topicName) {
            return basePath == null ? topicName : Path.Combine(basePath, topicName);
        }
    }

    internal class FileBasedPubSubSubscription : ISubscription {
        private ConcurrentDictionary<string, FileSystemWatcher> watchers;
        private ConcurrentDictionary<string, Guid> messageGuids;
        private PubSubJobsExecutor _executor;
        private readonly string basePath;
        private object watchersLocker = new object();
        private object messageLocker = new object();

        public FileBasedPubSubSubscription(string basePath, PubSubJobsExecutor executor) {
            this.basePath = basePath;
            this.watchers = new ConcurrentDictionary<string, FileSystemWatcher>();
            this.messageGuids = new ConcurrentDictionary<string, Guid>();
            this._executor = executor;
        }

        public event OnMessageCallback OnMessage;

        public IEnumerable<string> GetSubscribedTopics() {
            return this.watchers.Keys;
        }

        public void SubscribeTopic(string topic) {
            Action job = () => InnerSubscribeTopic(topic);
            _executor.AddJob(job);
        }

        private void InnerSubscribeTopic(string topic) {
            if (!watchers.Keys.Contains(topic)) {
                lock (watchersLocker) {
                    if (!watchers.Keys.Contains(topic)) {
                        var filePath = FileBasedPubSubUtils.GetFilePath(basePath, topic);
                        var fileInfo = new FileInfo(filePath);
                        FileSystemWatcher watcher = new FileSystemWatcher();

                        watcher.Path = fileInfo.DirectoryName;
                        watcher.Filter = fileInfo.Name;
                        watcher.NotifyFilter = NotifyFilters.LastWrite;

                        watchers[topic] = watcher;

                        var fileEventHandler = new FileSystemEventHandler((source, e) => {
                            try {
                                OnFileEvent(topic, source, e);
                            } catch (Exception ex) {
                                EventLogger.WriteError($"Error handling cache file event for file: {filePath}. Cache invalidation skipped.");
                                EventLogger.WriteError(ex);
                            }
                        });

                        watcher.Changed += fileEventHandler;
                        watcher.EnableRaisingEvents = true;
                    }
                }
            }
        }

        private void OnFileEvent(string topic, object source, FileSystemEventArgs e) {
            var filePath = e.FullPath;
            string[] fileLines = null;
            PubSubMessage msg = null;
            lock (messageLocker) {
                // Yes it's nasty, I know...
                Stopwatch s = new Stopwatch();
                s.Start();
                while (s.Elapsed < TimeSpan.FromMilliseconds(500)) {
                    try {
                        fileLines = File.ReadAllLines(filePath);
                        break;
                    } catch (IOException) {

                    }
                }
                s.Stop();

                if (!fileLines.IsNullOrEmpty()) {
                    bool hasParsedGui = Guid.TryParse(fileLines.FirstOrDefault(), out var newGuid);
                    var previousGuid = this.messageGuids.GetValueOrDefault(topic);

                    if (OnMessage != null && hasParsedGui && previousGuid != newGuid) {
                        this.messageGuids[topic] = newGuid;
                        var contentLines = new List<string>(fileLines);
                        contentLines.RemoveFirst();
                        var contentString = String.Join(string.Empty, contentLines);
                        msg = new PubSubMessage(topic, contentString);
                    }
                }
                if (msg != null) {
                    RaiseOnMessage(msg);
                }
            }
        }

        public void RaiseOnMessage(PubSubMessage message) {
            OnMessage?.Invoke(message);
        }

        public void UnsubscribeAll() {
            lock (watchersLocker) {
                foreach (var kvp in this.watchers) {
                    UnsubscribeTopic(kvp.Key);
                }
            }
        }

        public void UnsubscribeTopic(string topic) {
            Action job = () => InnerUnsubscribeTopic(topic);
            _executor.AddJob(job);
        }

        private void InnerUnsubscribeTopic(string topic) {
            if (this.watchers.ContainsKey(topic)) {
                lock (watchersLocker) {
                    if (this.watchers.TryRemove(topic, out var watcher)) {
                        watcher.EnableRaisingEvents = false;
                        watcher.Dispose();
                    }
                }
            }
        }

        public void Dispose() {
            UnsubscribeAll();
        }
    }

    public class FileBasedPubSub : IPubSub {
        private ConcurrentBag<ISubscription> subscriptions;
        private PubSubJobsExecutor _executor;
        private string basePath;

        public FileBasedPubSub(string basePath, PubSubJobsExecutor executor = null) {
            this.basePath = basePath;
            subscriptions = new ConcurrentBag<ISubscription>();
            this._executor = executor ?? new PubSubJobsExecutor(this);
        }

        public bool ClearFilesOnDispose { get; set; }

        public void CancelAllSubscriptions() {
            subscriptions.Apply(sub => sub.UnsubscribeAll());
        }

        public ISubscription CreateEmptySubscription() {
            var sub =  new FileBasedPubSubSubscription(this.basePath, _executor);
            subscriptions.Add(sub);
            return sub;
        }

        public void Dispose() {
            if (ClearFilesOnDispose) {
                subscriptions
                    .SelectMany(sub => sub.GetSubscribedTopics())
                    .Select(topic => FileBasedPubSubUtils.GetFilePath(basePath, topic))
                    .Where(filePath => File.Exists(filePath))
                    .Apply(filePath => File.Delete(filePath));
            }

            CancelAllSubscriptions();
            subscriptions.Apply(sub => sub.Dispose());
        }

        public void Publish(string topic, string message) {
            var filePath = FileBasedPubSubUtils.GetFilePath(basePath, topic);
            var content = Guid.NewGuid().ToString() + Constants.NewLineCharacter + message;
            var fileInfo = new FileInfo(filePath);

            // Yes it's nasty, I know...
            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMilliseconds(500)) {
                try {
                    using (var writer = new StreamWriter(fileInfo.FullName)) {
                        writer.Write(content);
                        writer.Flush();
                    }
                    break;
                } catch (IOException) {

                }
            }
            s.Stop();
        }

        public ISubscription Subscribe(string topic, OnMessageCallback onMessage) {
            var subscription = CreateEmptySubscription();
            subscription.OnMessage += onMessage;
            subscription.SubscribeTopic(topic);

            return subscription;
        }

        public bool IsAvailable() {
            return true;
        }

        public bool IsAvailable(out Exception ex) {
            ex = null;
            return true;
        }
    }
}
