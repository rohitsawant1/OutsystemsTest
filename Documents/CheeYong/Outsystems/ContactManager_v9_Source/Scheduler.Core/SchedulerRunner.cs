/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Settings;
using OutSystems.Scheduler.Core.Configuration;
using OutSystems.Scheduler.Core.Jobs;
using OutSystems.HubEdition.Extensibility.Data.Platform;

namespace OutSystems.Scheduler.Core {

    public class RunningContext {

        public string ApplicationName { get; set; }

        public ObjectKey ApplicationKey { get; set; }

        private string frontendName;
        public string FrontendName {
            get { return frontendName ?? RuntimeEnvironment.MachineName; }

            set { frontendName = value; }
        }

        public ISettingsProvider SettingsProvider { get; set; }

        public bool IsDevMachine { get; set; }

        public string ServerPurpose { get; set; }

        public Func<IDatabaseAccessProvider<IPlatformDatabaseServices>> DatabaseProviderGetter { private get; set; }

        public IDatabaseAccessProvider<IPlatformDatabaseServices> DatabaseProvider {
            get { return DatabaseProviderGetter(); }
        }
        
        public bool ProcessEmails { get; set; } = true;

        public bool ProcessTimers { get; set; } = true;

        public bool ProcessProcesses { get; set; } = true;

        public int OutboundPort { get; set; } = 80;

        public Func<string> InstanceKeyGetter { private get; set; }
        public virtual string InstanceKey {
            get { return InstanceKeyGetter == null ? null : InstanceKeyGetter(); }
        }

        public override string ToString() {
            return
                "ApplicationKey = " + ApplicationKey + "; " +
                "FrontendName = " + FrontendName + "; " +
                "IsDevMachine = " + IsDevMachine + "; " +
                "ServerPurpose = " + ServerPurpose + "; " +
                "ProcessEmails = " + ProcessEmails + "; " +
                "ProcessTimers = " + ProcessTimers + "; " +
                "ProcessProcesses = " + ProcessProcesses + ";" +
                "OutboundPort = " + OutboundPort + ")";
        }
    }

    #region Thread Status related classes

    // Todo: in future move this code to a common place, so it is not replicated in services
    public enum SchedulerThreadStatus {
        Uncreated,
        Starting,
        Idle,
        Processing,
        Sleeping,
        Disabled,
        Error,
        Dead
    };

    public abstract class SchedulerThreadStatusData : IComparable {
        public string Name;          // thread name
        public DateTime Instant;     // in status since this instant
        public int MaxExpectedSeconds;
        public string Detail;        // extra info about the status (what job is processing, etc.)
        public SchedulerThreadStatus Status;
        public Thread TheThread;
        public bool ThreadIsAlive;
        public bool IsProducerThread;
        protected abstract Type GetJobType { get; }

        public event Action LicenseInvalidated;

        public static List<SchedulerThreadStatusData> ThreadsStatusData = new List<SchedulerThreadStatusData>();
        public static readonly Object Lock = new Object();

        public abstract void SetStatus(SchedulerThreadStatus st, string newDetail, int maxSeconds);
        public abstract void SetStatus(SchedulerThreadStatus st, int maxSeconds);

        public abstract SchedulerThreadStatusData GetStatusData();

        public void InvalidateLicense() {
            if (LicenseInvalidated != null) {
                LicenseInvalidated();
            }
        }

        public int CompareTo(object obj) {
            var other = (SchedulerThreadStatusData)obj;
            int typeCompare = IJob.GetKindOrderNum(this.GetJobType).CompareTo(IJob.GetKindOrderNum(other.GetJobType));
            if (typeCompare == 0) {
                return -(this.IsProducerThread.CompareTo(other.IsProducerThread));
            }
            return typeCompare;
        }
    }

    public class SchedulerThreadStatusData<Job> : SchedulerThreadStatusData {
        protected override Type GetJobType {
            get { return typeof(Job); }
        }

        private SchedulerThreadStatusData() {
            Name = "";
            Detail = "";
            Instant = DateTime.Now;
            Status = SchedulerThreadStatus.Uncreated;
            TheThread = null;
            ThreadIsAlive = false;
        }

        public SchedulerThreadStatusData(SchedulerThreadStatusData tsd) {
            this.Name = tsd.Name;
            this.Detail = tsd.Detail;
            this.Instant = tsd.Instant;
            this.Status = tsd.Status;
            this.TheThread = tsd.TheThread;
            this.MaxExpectedSeconds = tsd.MaxExpectedSeconds;
            if (this.TheThread != null)
                this.ThreadIsAlive = (this.TheThread.IsAlive);
            else
                this.ThreadIsAlive = false;
            this.IsProducerThread = tsd.IsProducerThread;
        }

        public static SchedulerThreadStatusData<Job> AllocateThreadStatusData(bool isProducerThread) {
            var newThreadData = new SchedulerThreadStatusData<Job>();
            newThreadData.TheThread = Thread.CurrentThread;
            newThreadData.ThreadIsAlive = true;
            newThreadData.IsProducerThread = isProducerThread;
            newThreadData.Status = SchedulerThreadStatus.Starting;
            lock (Lock) {
                ThreadsStatusData.Add(newThreadData);
            }
            return newThreadData;
        }

        public override void SetStatus(SchedulerThreadStatus st, string newDetail, int maxSeconds) {
            lock (this) {
                Instant = DateTime.Now;
                MaxExpectedSeconds = maxSeconds;
                Status = st;
                Detail = newDetail;
            }
        }

        public override void SetStatus(SchedulerThreadStatus st, int maxSeconds) {
            SetStatus(st, "", maxSeconds);
        }

        /// <summary>
        /// Safe way to get thread status data
        /// </summary>
        /// <returns></returns>
        public override SchedulerThreadStatusData GetStatusData() {
            lock (this) {
                return new SchedulerThreadStatusData<Job>(this);
            }
        }
    }

    #endregion


    /// <summary>
    /// Summary description for Scheduler.
    /// </summary>
    public class SchedulerRunner {

        public const int StopDelayMs = 1000;

        /// <summary>
        /// Sleep interval in seconds
        /// </summary>
        private const int SleepInterval = 20;

        public bool ServerIsInDevelopmentMode = false;

        public class JobData {
            // default value in seconds
            private const int DEFAULT_TIMER_TIMEOUT = 20 * 60;

            public string EspaceName;
            public int EspaceId;
            public string TenantName;
            public int TenantId;
            public bool IsMultitenant;
            public ObjectKey SSKey;
            public string TimerName;
            public int JobId;
            public int Timeout = DEFAULT_TIMER_TIMEOUT; // In seconds
            public DateTime PreviousNextRun;
            public string PreviousNextRunStrPrecision; // Higher precision for comparison purposes
            public string Schedule;
            public DateTime LastRun;
        }

        private bool stopping = false; // when service is about to stop, it set this to true

        public bool Stopping {
            get { return stopping; }
            set { stopping = value; }
        }

        private const int recoverTimeoutSec = 30; // thread recover timeout in seconds (in case of unexpected error, waiting time)

        public static QueueKey<int, JobData> JobsQueue = new QueueKey<int, JobData>(); // all jobs will be queued here to be executed

        public RunningContext RunningContext { get; }

        public SchedulerRunner(RunningContext runningContext) {
            this.RunningContext = runningContext;
        }

        public void Initialize(JobFactory factory) {
            OSTrace.Debug("Initializing scheduler runner");
            var settingsProvider = RunningContext.SettingsProvider;

            var maxNumberOfThreadsInDevMachines = settingsProvider.Get(SchedulerSettings.Misc.MaxNumberOfConsumerThreadsInDevelopmentMachines);

            if (RunningContext.ProcessTimers) {
                var numberOfThreadsForTimers = settingsProvider.Get(SchedulerSettings.Timers.NumberOfThreadsForTimers);
                if (RunningContext.IsDevMachine) {
                    numberOfThreadsForTimers = Math.Min(numberOfThreadsForTimers, maxNumberOfThreadsInDevMachines);
                }

                factory.InitializeTimerThreads(numberOfThreadsForTimers, this);
                OSTrace.Info("Timers threads were initialized.");
            } else {
                OSTrace.Info("Scheduler not processing Timers.");
            }

            if (RunningContext.ProcessEmails) {
                var numberOfThreadsForEmails = settingsProvider.Get(SchedulerSettings.Emails.NumberOfThreadsForEmails);
                if (RunningContext.IsDevMachine) {
                    numberOfThreadsForEmails = Math.Min(numberOfThreadsForEmails, maxNumberOfThreadsInDevMachines);
                }

                factory.InitializeEmailThreads(numberOfThreadsForEmails, this);
                OSTrace.Info("Emails threads were initialized.");
            } else {
                OSTrace.Info("Scheduler not processing Emails.");
            }

            if (RunningContext.ProcessProcesses) {
                var numberOfThreadsForActivities = settingsProvider.Get(SchedulerSettings.Activities.NumberOfThreadsForActivities);
                if (RunningContext.IsDevMachine) {
                    numberOfThreadsForActivities = Math.Min(numberOfThreadsForActivities, maxNumberOfThreadsInDevMachines);
                }

                factory.InitializeActivityThreads(numberOfThreadsForActivities, this);

                var numberOfThreadsForEvents = settingsProvider.Get(SchedulerSettings.Events.NumberOfThreadsForEvents);
                if (RunningContext.IsDevMachine) {
                    numberOfThreadsForEvents = Math.Min(numberOfThreadsForEvents, maxNumberOfThreadsInDevMachines);
                }

                factory.InitializeEventThreads(numberOfThreadsForEvents, this);
                OSTrace.Info("Processes/Activities threads were initialized.");

                if (settingsProvider.Get(SchedulerSettings.LightEvents.EnableLightProcessExecution)) {
                    var numberOfThreadsForLightEvents = settingsProvider.Get(SchedulerSettings.LightEvents.NumberOfThreadsForLightEvents);
                    if (RunningContext.IsDevMachine) {
                        numberOfThreadsForLightEvents = Math.Min(numberOfThreadsForLightEvents, maxNumberOfThreadsInDevMachines);
                    }

                    factory.InitializeLightEventThreads(numberOfThreadsForLightEvents, this);
                    OSTrace.Info("LightProcesses threads were initialized.");
                } else {
                    OSTrace.Info("Scheduler not processing LightProcesses.");
                }
            } else {
                OSTrace.Info("Scheduler not processing Processes/Activities.");
            }
        }


        public bool Sleep(int millisec) {
            while (millisec > 0 && !Stopping) {
                Thread.Sleep(Math.Min(millisec, SchedulerRunner.StopDelayMs));
                millisec -= SchedulerRunner.StopDelayMs;
            }
            return !Stopping;
        }

        public string Stop() {
            OSTrace.Debug("Stopping scheduler runner.");
            OSTrace.Debug("Previous stopping flag: " + this.Stopping);
            this.Stopping = true;

            int totalThreads = 0;
            int totalDeadThreads = 0;

            // if ntries > 25 (tested 30 or greater), we receive the error 'The service did not respond to the start or control request in a timely fashion'
            // in the management console...
            for (int nTries = 0; nTries < 25; nTries++) {
                totalDeadThreads = 0;
                lock (SchedulerThreadStatusData.Lock) {
                    totalThreads = SchedulerThreadStatusData.ThreadsStatusData.Count;
                    OSTrace.Debug("Total threads: " + totalThreads);
                    foreach (SchedulerThreadStatusData threadStatusData in SchedulerThreadStatusData.ThreadsStatusData) {
                        if (threadStatusData.Status != SchedulerThreadStatus.Processing && threadStatusData.Status != SchedulerThreadStatus.Dead) {
                            threadStatusData.Status = SchedulerThreadStatus.Dead; // unfortunately, only works with this line...
                            threadStatusData.TheThread.Abort();
                        } else if (threadStatusData.Status == SchedulerThreadStatus.Dead) {
                            totalDeadThreads++;
                        }
                    }
                }
                if (totalDeadThreads >= totalThreads) {
                    OSTrace.Debug("Total dead threads: " + totalDeadThreads);
                    break;
                }
                Thread.Sleep(1000);
            }
            string appString = string.Empty;
            if (totalDeadThreads != totalThreads) {
                var remainingThreads = totalThreads - totalDeadThreads;
                OSTrace.Debug("Number of threads still processing: " + remainingThreads);
                appString = " (There are still " + remainingThreads + " processing threads)";
            }
            return appString;
        }

    }

}
