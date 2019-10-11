/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OutSystems.RuntimeCommon.Log;

namespace OutSystems.RuntimeCommon.PubSub {
    public class PubSubJobsExecutor : IJobExecutor {
        protected volatile Task runningTask;
        protected volatile Task cleanupTask;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected IPubSub pubSub;
        private static readonly int ConnectionRetriesTreshold = 5;
        private static readonly int JobRetriesTreshold = 10;
        private static readonly int SleepTimeFactor = 10 * 1000;
        private volatile bool isOnCleanupState = false;
        private volatile int connectionFails = 0, jobFails = 0;
        protected Dictionary<string, List<Pair<Action, string>>> dependencies = new Dictionary<string, List<Pair<Action, string>>> ();

        public PubSubJobsExecutor(IPubSub pubSub) {
            this.pubSub = pubSub;
            runningTask = Task.CompletedTask;
        }

        public void AddJob(Action jobAction, string key = null, string dependencyKey = null) {
            lock (this) {
                if (!tokenSource.Token.IsCancellationRequested && !isOnCleanupState) {

                    if (!key.IsNullOrEmpty() && !dependencies.ContainsKey(key)) {
                        dependencies[key] = new List<Pair<Action, string>>();
                    }

                    if (!dependencyKey.IsNullOrEmpty() && dependencies.ContainsKey(dependencyKey)) {
                        dependencies[dependencyKey].Add(new Pair<Action, string>(jobAction, key));
                        return;
                    }

                    runningTask = runningTask.ContinueWith((previousTask) => {
                        if (!tokenSource.Token.IsCancellationRequested) {
                            if (!pubSub.IsAvailable(out var exception)) {
                                connectionFails = ProcessJobFailure(connectionFails, ConnectionRetriesTreshold, "Error executing PubSub jobs, {0} consecutive connections failed.", exception);
                                AddJob(jobAction, key, dependencyKey);
                                return;
                            }
                            connectionFails = 0;

                            try {
                                jobAction();
                                jobFails = 0;
                                lock (this) {
                                    if (!key.IsNullOrEmpty() && dependencies.ContainsKey(key)) {
                                        dependencies[key].Apply((pair) => AddJob(pair.First, pair.Second));
                                        dependencies.Remove(key);
                                    }
                                }
                            } catch (Exception ex) {
                                if (pubSub.IsAvailable()) {
                                    jobFails = ProcessJobFailure(jobFails, JobRetriesTreshold, "Error executing PubSub jobs, {0} consecutive Jobs failed.", ex);
                                } else {
                                    jobFails = 0;
                                    connectionFails = ProcessJobFailure(connectionFails, ConnectionRetriesTreshold, "Error executing PubSub jobs, {0} consecutive connections failed.", ex);
                                }
                                AddJob(jobAction, key, dependencyKey);
                            }
                        }
                    }, tokenSource.Token);
                }
            }
        }

        protected virtual int ProcessJobFailure(int counter, int threshold, string eventLogErrorMessage, Exception innerException = null) {
            ++counter;
            if (counter >= threshold) {
                EventLogger.WriteError(string.Format(eventLogErrorMessage, counter) + 
                    (innerException == null ?
                        "" :
                        (Environment.NewLine + innerException.Message + Environment.NewLine + innerException.StackTrace)));
            }
            EncloseTaskWait(
                Task.Delay(CalculateSleepTime(counter, threshold), tokenSource.Token));
            return counter;
        }

        protected virtual int CalculateSleepTime(int nFails, int threshold) {
            return Math.Min(nFails, threshold) * SleepTimeFactor;
        }

        public void TriggerCleanupState(IEnumerable<Action> cleanupActions) {
            lock (this) {
                if (!tokenSource.Token.IsCancellationRequested && !isOnCleanupState) {
                    isOnCleanupState = true;
                    cleanupTask = runningTask.ContinueWith((t) => {
                        foreach (var a in cleanupActions) {
                            try {
                                a();
                            } catch {

                            }
                        }
                    });
                }
            }
        }

        public void Stop() {
            tokenSource.Cancel();
        }

        public void Dispose() {
            Stop();
            EncloseTaskWait(runningTask);
            EncloseTaskWait(cleanupTask);
        }

        private void EncloseTaskWait(Task task) {
            try {
                task?.Wait();
            } catch (AggregateException ex) {
                if(!ex.InnerExceptions.All(innerEx => innerEx is TaskCanceledException)){
                    throw;
                }
            } catch (TaskCanceledException) { }
        }
    }
}
