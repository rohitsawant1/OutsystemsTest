/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Processes;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.Scheduler.Core.Configuration;

namespace OutSystems.Scheduler.Core.Jobs {
    public class JobFactory {
        protected RunningContext context;

        public JobFactory(RunningContext context) {
            this.context = context;
        }
        
        protected virtual SchedulerProducerConsumer<Job> CreateSchedulerProducerConsumer<Job>(string name, int numberOfConsumers, int delayBetweenExecutionsMs, int delayBetweenErrorMs, int delayBetweenDatabasePullMs, SchedulerProducerConsumer<Job>.PullJobsFromDatabaseDelegate pullJobs, bool isDequeuePattern, SchedulerProducerConsumer<Job>.CanExecuteDelegate canExecuteDelegate, SchedulerProducerConsumer<Job>.CanExecuteInParallelDelegate canExecuteInParallelDelegate, SchedulerRunner schedulerRunner) where Job : IJob {
            return new SchedulerProducerConsumer<Job>(name, numberOfConsumers, delayBetweenExecutionsMs, delayBetweenErrorMs, delayBetweenDatabasePullMs, pullJobs, isDequeuePattern, canExecuteDelegate, canExecuteInParallelDelegate, schedulerRunner);
        }
        protected enum ActivationParameter {
            BusinessProcessExecution,
            ParallelBusinessProcessExecution,
            ParallelTimers,
        }


        protected static bool GetActivationParameter(Transaction transaction, ActivationParameter activationParameter) {
            return true;
        }

#region Activities
        private IDataReader GetDBPendingActivities(Transaction trans, int batch) {
            return this.context.ApplicationKey != null ?
                        DBScheduler.Instance.GetPendingActivitiesForApplication(trans, batch, this.context.ApplicationKey) :
                        DBScheduler.Instance.GetPendingActivitiesForFrontend(trans, batch, this.context.FrontendName);
        }

        public virtual List<ActivityJob> GetPendingActivities(int batch, string instanceKey = "") {
            List<ActivityJob> pendingList = new List<ActivityJob>();
            using (Transaction trans = context.DatabaseProvider.GetCommitableTransaction()) {
                using (IDataReader reader = GetDBPendingActivities(trans, batch)) {
                    while (reader.Read() && pendingList.Count <= batch) {

                        ActivityJob job = new ActivityJob(
                            Convert.ToString(reader["Espace_Key"]),
                            Convert.ToInt32(reader["Activity_Id"]),
                            Convert.ToInt32(reader["Process_Id"]),
                            Convert.ToString(reader["Activity_Name"]),
                            (ActivityStatus)Convert.ToInt32(reader["Status_Id"]),
                            ObjectKey.Parse(Convert.ToString(reader["SS_Key"])),
                            (ActivityKind)Convert.ToInt32(reader["Kind"]),
                            Convert.ToString(reader["Espace_Name"]),
                            Convert.ToBoolean(reader["Is_Multitenant"]),
                            Convert.ToString(reader["Tenant_Name"]),
                            Convert.ToInt32(reader["Tenant_Id"]),
                            Convert.ToInt32(reader["Espace_Id"]),
                            reader.SafeGet<DateTime>("Next_Run",
                            BuiltInFunction.NullDate()),
                            instanceKey,
                            context);
                        pendingList.Add(job);
                    }
                }
                trans.Commit();
            }
            return pendingList;
        }

        public virtual void InitializeActivityThreads(int numberOfThreadsForActivities, SchedulerRunner runner) {
            var settingsProvider = context.SettingsProvider;
            OSTrace.Debug("Initializing " + numberOfThreadsForActivities + " threads for activities.");

            CreateSchedulerProducerConsumer<ActivityJob>("Activity",
                numberOfThreadsForActivities,
                settingsProvider.Get(SchedulerSettings.Activities.DelayBetweenExecutionsForActivitiesMs),
                settingsProvider.Get(SchedulerSettings.Misc.DelayAfterErrorsMs),
                settingsProvider.Get(SchedulerSettings.Activities.DelayBetweenDbActivityPollingMs),
                () => GetPendingActivities(numberOfThreadsForActivities * settingsProvider.Get(SchedulerSettings.Activities.NumberOfJobsPerThreadsForActivities)),
                /*isDequeuePattern*/false,
                delegate (Transaction transaction) {
                    return GetActivationParameter(transaction, ActivationParameter.BusinessProcessExecution) && !settingsProvider.Get(SchedulerSettings.Activities.DisableProcesses);
                },
                delegate (Transaction transaction) {
                    return GetActivationParameter(transaction, ActivationParameter.ParallelBusinessProcessExecution);
                },
                runner);
        }
#endregion

#region Timers

        private IDataReader GetDBPendingTimers(Transaction trans) {
            return this.context.ApplicationKey != null ?
                        DBScheduler.Instance.GetCyclicJobsForApplication(trans, this.context.ApplicationKey) :
                        DBScheduler.Instance.GetCyclicJobsForFrontend(trans, this.context.FrontendName);
        }

        public virtual List<TimerJob> GetPendingTimers(string instanceKey = "") {
            List<TimerJob> pendingList = new List<TimerJob>();
            using (Transaction trans = context.DatabaseProvider.GetCommitableTransaction()) {
                using (IDataReader reader = GetDBPendingTimers(trans)) {
                    while (reader.Read()) {
                        TimerJob job = new TimerJob(
                            reader.SafeGet<int>("Id"),
                            reader.SafeGet<string>("Meta_Cyclic_Job_Name"),
                            ObjectKey.Parse(reader.SafeGet<string>("SS_Key")),
                            ObjectKey.Parse(reader.SafeGet<string>("User_Provider_Key")),
                            reader.SafeGet<bool>("Is_Shared"),
                            (reader.SafeGet<int>("real_timeout")) * 60, // The database is minutes
                            reader.SafeGet<string>("Espace_Name"),
                            reader.SafeGet<bool>("Is_Multitenant"),
                            reader.SafeGet<string>("Tenant_Name", string.Empty),
                            reader.SafeGet<int>("Tenant_Id"),
                            reader.SafeGet<int>("Espace_Id"),
                            reader.SafeGet<DateTime>("Next_Run", BuiltInFunction.NullDate()),
                            reader.SafeGet<int>("Priority"),
                            instanceKey /*will be null on 1st run (for main)*/,
                            context);
                        pendingList.Add(job);
                    }
                }
                trans.Commit();
            }
            return pendingList;
        }

        public virtual void InitializeTimerThreads(int numberOfThreadsForTimers, SchedulerRunner runner) {
            var settingsProvider = context.SettingsProvider;
            OSTrace.Debug("Initializing " + numberOfThreadsForTimers + " threads for timers.");

            CreateSchedulerProducerConsumer<TimerJob>("Timer",
                numberOfThreadsForTimers,
                settingsProvider.Get(SchedulerSettings.Timers.DelayBetweenExecutionsForTimersMs),
                settingsProvider.Get(SchedulerSettings.Misc.DelayAfterErrorsMs),
                settingsProvider.Get(SchedulerSettings.Timers.DelayBetweenDbTimerPollingMs),
                () => GetPendingTimers(),
                /*isDequeuePattern*/false,
                transaction => {
                    return !settingsProvider.Get(SchedulerSettings.Timers.DisableTimers);
                },
                delegate (Transaction transaction) {
                    return GetActivationParameter(transaction, ActivationParameter.ParallelTimers);
                },
                runner);
        }
#endregion

#region Emails

        public virtual List<EmailJob> FetchEmails(int batch, string instanceKey = "") {
            List<EmailJob> result = new List<EmailJob>();

            using (Transaction trans = context.DatabaseProvider.GetCommitableTransaction()) {
                result.AddRange(DequeueEmails(trans, batch, instanceKey));
                trans.Commit();
            }
            return result;
        }

        private IDataReader DBDequeueEmails(Transaction trans, int batch) {
            return this.context.ApplicationKey != null ?
                        DBScheduler.Instance.DequeueEmails(trans, batch, this.context.FrontendName, this.context.ApplicationKey, context.SettingsProvider.Get(SchedulerSettings.Emails.RecoverEmailHangIntervalInMinutes)) :
                        DBScheduler.Instance.DequeueEmails(trans, batch, this.context.FrontendName, context.SettingsProvider.Get(SchedulerSettings.Emails.RecoverEmailHangIntervalInMinutes));
        }

        private List<EmailJob> DequeueEmails(Transaction trans, int batch, string instanceKey = "") {
            var pendingList = new List<EmailJob>();
            // get jobs
            using (IDataReader reader = DBDequeueEmails(trans, batch)) {

                while (reader.Read()) {

                    int id = reader.SafeGet<int>("id");

                    if (id != 0) {
                        EmailJob job = new EmailJob(id, instanceKey, context);

                        pendingList.Add(job);
                    }
                }
            }
            return pendingList;
        }

        public virtual void InitializeEmailThreads(int numberOfThreadsForEmails, SchedulerRunner runner) {
            var settingsProvider = context.SettingsProvider;
            OSTrace.Debug("Initializing " + numberOfThreadsForEmails + " threads for emails.");

            CreateSchedulerProducerConsumer<EmailJob>("Email",
                numberOfThreadsForEmails,
                settingsProvider.Get(SchedulerSettings.Emails.DelayBetweenExecutionsForEmailsMs),
                settingsProvider.Get(SchedulerSettings.Misc.DelayAfterErrorsMs),
                settingsProvider.Get(SchedulerSettings.Emails.DelayBetweenDbEmailPollingMs),
                () => FetchEmails(numberOfThreadsForEmails * 2),
                /*isDequeuePattern*/true,
                transaction => {
                    return !settingsProvider.Get(SchedulerSettings.Emails.DisableEmails);
                },
                transaction => {
                    return true;
                },
                runner);
        }
#endregion

#region Events

        private IDataReader DBDequeueEvents(Transaction trans, int batch, int activityId) {
            return this.context.ApplicationKey != null ?
                        DBRuntimePlatform.Instance.DequeueNormalEventForApplication(trans, batch, activityId, this.context.ApplicationKey) :
                        DBRuntimePlatform.Instance.DequeueNormalEventForFrontend(trans, batch, activityId, this.context.FrontendName);
        }

        public virtual List<EventJob> DequeueEvents(int batch, Func<int, bool> sleep, string instanceKey = "") {
            var pendingList = new List<EventJob>();
            using (Transaction trans = context.DatabaseProvider.GetCommitableTransaction()) {

                using (IDataReader reader = DBDequeueEvents(trans, batch, BuiltInFunction.NullIdentifier())) {

                    while (reader.Read() && pendingList.Count <= batch) {
                        CreateJobFromReader(reader, pendingList, sleep, instanceKey);
                    }
                }
                trans.Commit();
            }

            return pendingList;
        }

        private void CreateJobFromReader(IDataReader reader, List<EventJob> pendingList, Func<int, bool> sleep, string sandboxKey) {
            string eSpaceKey = reader.SafeGet<string>("espace_key");
            int espaceId = reader.SafeGet<int>("espace_id");
            int tenantId = reader.SafeGet<int>("tenant_id");
            int activityId = reader.SafeGet<int>("activity_id");
            int processId = reader.SafeGet<int>("process_id");
            int processDefId = reader.SafeGet<int>("process_def_id");
            int daysSinceQueued = reader.SafeGet<int>("days_since_queued");
            int id = reader.SafeGet<int>("id");

            if (id != 0) {
                EventJob job = new EventJob(
                    eSpaceKey,
                    id,
                    espaceId,
                    tenantId,
                    activityId,
                    processId,
                    processDefId,
                    Convert.ToString(reader["data_id"]),
                    daysSinceQueued,
                    Convert.ToString(reader["espace_name"]),
                    (Convert.ToBoolean(reader["is_multitenant"]) ? Convert.ToString(reader["tenant_name"]) : null),
                    reader.SafeGet<bool>("valid_tenant"),
                    activityId != 0 ? ObjectKey.Parse(Convert.ToString(reader["activity_key"])) : ObjectKey.Parse(Convert.ToString(reader["process_def_key"])),
                    sandboxKey,
                    context,
                    sleep);
                pendingList.Add(job);

                OSTrace.Debug(String.Format("EVENT SCHEDULER DEBUG: Added event (id={0},eSpaceId={1}) for {2} {3} to the dequeue list, Thread: {4}",
                    id.ToString(), espaceId.ToString(), (activityId > 0 ? "Activity" : "Process"), (activityId > 0 ? activityId.ToString() : processDefId.ToString()), Thread.CurrentThread.ManagedThreadId));
            }
        }



        public virtual void InitializeEventThreads(int numberOfThreadsForEvents, SchedulerRunner runner) {
            var settingsProvider = context.SettingsProvider;
            OSTrace.Debug("Initializing " + numberOfThreadsForEvents + " threads for events.");

            CreateSchedulerProducerConsumer<EventJob>("Event",
                numberOfThreadsForEvents,
                settingsProvider.Get(SchedulerSettings.Events.DelayBetweenExecutionsForEventsMs),
                settingsProvider.Get(SchedulerSettings.Misc.DelayAfterErrorsMs),
                settingsProvider.Get(SchedulerSettings.Activities.DelayBetweenDbActivityPollingMs),
                () => DequeueEvents(numberOfThreadsForEvents * settingsProvider.Get(SchedulerSettings.Events.NumberOfJobsPerThreadForEvents), (time) => runner.Sleep(time)),
                /*isDequeuePattern*/true,
                transaction => {
                    return !settingsProvider.Get(SchedulerSettings.Activities.DisableProcesses);
                },
                delegate (Transaction transaction) {
                    return GetActivationParameter(transaction, ActivationParameter.ParallelBusinessProcessExecution);
                },
                runner);
        }
#endregion

#region LightEvents

        private IDataReader DBDequeueLightEvents(Transaction trans, int batch, int activityId) {
            return this.context.ApplicationKey != null ?
                        DBRuntimePlatform.Instance.DequeueLightEventForApplication(trans, batch, activityId, this.context.ApplicationKey) :
                        DBRuntimePlatform.Instance.DequeueLightEventForFrontend(trans, batch, activityId, this.context.FrontendName);
        }

        public virtual List<LightEventJob> DequeueLightEvents(int batch, Func<int, bool> sleep, string instanceKey = "") {
            var pendingList = new List<LightEventJob>();
            
                using (Transaction trans = context.DatabaseProvider.GetCommitableTransaction()) {

                    using (IDataReader reader = DBDequeueLightEvents(trans, batch, BuiltInFunction.NullIdentifier())) {

                        //with multiple sandboxes the limit is proportional to the number of sandboxes to avoid starvation 
                        while (reader.Read() && pendingList.Count <= batch) {
                            CreateJobFromReader(reader, pendingList, sleep, instanceKey);
                        }
                    }
                    trans.Commit();
                }
            return pendingList;
        }


        private void CreateJobFromReader(IDataReader reader, List<LightEventJob> pendingList, Func<int, bool> sleep, string instanceKey) {
            string eSpaceKey = reader.SafeGet<string>("espace_key");
            int espaceId = reader.SafeGet<int>("espace_id");
            int tenantId = reader.SafeGet<int>("tenant_id");
            int activityId = reader.SafeGet<int>("activity_id");
            int processId = reader.SafeGet<int>("process_id");
            int processDefId = reader.SafeGet<int>("process_def_id");
            int daysSinceQueued = reader.SafeGet<int>("days_since_queued");
            long id = reader.SafeGet<long>("id");

            if (id != 0) {
                LightEventJob job = new LightEventJob(
                    eSpaceKey,
                    id,
                    espaceId,
                    tenantId,
                    activityId,
                    processId,
                    processDefId,
                    Convert.ToString(reader["Entity_Record_Id"]),
                    daysSinceQueued,
                    Convert.ToString(reader["espace_name"]),
                    (Convert.ToBoolean(reader["is_multitenant"]) ? Convert.ToString(reader["tenant_name"]) : null),
                    reader.SafeGet<bool>("valid_tenant"),
                    activityId != 0 ? ObjectKey.Parse(Convert.ToString(reader["activity_key"])) : ObjectKey.Parse(Convert.ToString(reader["process_def_key"])),
                    instanceKey,
                    context,
                    sleep);
                pendingList.Add(job);

                OSTrace.Debug(String.Format("EVENT SCHEDULER DEBUG: Added light event (id={0},eSpaceId={1}) for {2} {3} to the dequeue list, Thread: {4}",
                    id.ToString(), espaceId.ToString(), (activityId > 0 ? "Activity" : "Process"), (activityId > 0 ? activityId.ToString() : processDefId.ToString()), Thread.CurrentThread.ManagedThreadId));
            }
        }

        public virtual void InitializeLightEventThreads(int numberOfThreadsForLightEvents, SchedulerRunner runner) {
            var settingsProvider = context.SettingsProvider;
            OSTrace.Debug("Initializing " + numberOfThreadsForLightEvents + " threads for light events.");

            CreateSchedulerProducerConsumer<LightEventJob>("LightEvent",
                numberOfThreadsForLightEvents,
                settingsProvider.Get(SchedulerSettings.LightEvents.DelayBetweenExecutionsForLightEventsMs),
                settingsProvider.Get(SchedulerSettings.Misc.DelayAfterErrorsMs),
                settingsProvider.Get(SchedulerSettings.LightEvents.DelayBetweenDbLightEventPollingMs),
                () => DequeueLightEvents(numberOfThreadsForLightEvents * settingsProvider.Get(SchedulerSettings.Events.NumberOfJobsPerThreadForEvents), (time) => runner.Sleep(time)),
                /*isDequeuePattern*/true,
                transaction => {
                    return !settingsProvider.Get(SchedulerSettings.Activities.DisableProcesses);
                },
                delegate (Transaction transaction) {
                    return GetActivationParameter(transaction, ActivationParameter.ParallelBusinessProcessExecution);
                },
                runner);
        }
#endregion
    }
}
