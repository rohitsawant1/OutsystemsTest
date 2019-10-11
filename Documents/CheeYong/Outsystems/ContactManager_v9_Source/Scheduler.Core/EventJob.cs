/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Threading;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Log;
using OutSystems.HubEdition.RuntimePlatform.Processes;
using OutSystems.Internal.Db;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.ObfuscationProperties;
using OutSystems.Scheduler.Core.Configuration;

namespace OutSystems.Scheduler.Core {
    [DoNotObfuscateType]
    [DoNotSealType]
    public class EventJob : AbstractEventJob {

        private string eSpaceKey;
        private int EspaceId;
        private int TenantId;
        private bool ValidTenant;
        private int ActivityId;
        private int ProcessId;
        private int ProcessDefId;
        private string DataId;
        private int DaysSinceQueued;
        private string EspaceName;
        private string TenantName;
        private ObjectKey SSKey;

        private int Scheduler_ActivitiesTimeout {
            get {
                return context.SettingsProvider.Get(SchedulerSettings.Activities.ActivitiesTimeout);
            }
        }

        private int timeoutInSec;
        public override int TimeoutInSec {
            get { return timeoutInSec; }
        }

        public string Url() {
            return $"http://{context.SettingsProvider.Get(RuntimePlatformSettings.Misc.InternalAddress)}:{context.OutboundPort}/{EspaceName}/";
        }

        public string DebuggerUrl() {
            return Debugger.DebuggerUrl(context.SettingsProvider.Get(RuntimePlatformSettings.Misc.InternalAddress), EspaceName, TenantName, /*personalAreaName*/null);
        }

        public override string Details() {
            return "Event id " + Id + ", Espace '" + EspaceName + "'" + (TenantName != null ? ", Tenant '" + TenantName + "'" : "");
        }

        public bool Valid {
            get { return (EspaceId > 0) && (!EspaceName.IsEmpty()) && (SSKey != null) && (ProcessDefId > 0 || (ActivityId != 0 && ProcessId > 0)) && ValidTenant; }
        }

        public bool EventExpired {
            get { return DaysSinceQueued >= context.SettingsProvider.Get(SchedulerSettings.Events.ProcessBackoffMaxDays); }
        }

        public EventJob(string eSpaceKey, int id, int EspaceId, int TenantId, int ActivityId, int ProcessId, int ProcessDefId, string DataId, int DaysSinceQueued, string EspaceName, string TenantName, bool ValidTenant, ObjectKey SSKey, string sandboxKey, RunningContext context, Func<int, bool> sleep)
            : base(id, sandboxKey, context, sleep) {

            this.eSpaceKey = eSpaceKey;
            this.EspaceId = EspaceId;
            this.TenantId = TenantId;
            this.ValidTenant = ValidTenant;
            this.ActivityId = ActivityId;
            this.ProcessId = ProcessId;
            this.ProcessDefId = ProcessDefId;
            this.DataId = DataId;
            this.DaysSinceQueued = DaysSinceQueued;

            this.EspaceName = EspaceName;
            this.TenantName = TenantName;
            this.SSKey = SSKey;

            this.timeoutInSec = Scheduler_ActivitiesTimeout;
        }

        public override void Execute() {
            var keyDatabaseValue = ObjectKeyUtils.DatabaseValue(SSKey);

            if (Valid) {

                using (ActivityHandler activityHandler = new ActivityHandler(context.SettingsProvider, Url(), TenantId, 0, SchedulerUtils.SchedulerConsumerKey, this.eSpaceKey)) {
                    activityHandler.Timeout = (int)(1.2 * TimeoutInSec) * 1000;
                    if (ProcessDefId != 0) {
                        OSTrace.Debug("EVENT SCHEDULER DEBUG START: Going to execute event WS (SSKey=" + keyDatabaseValue + ",DataId=" + DataId + "), Thread: " + Thread.CurrentThread.ManagedThreadId);
                        activityHandler.ExecuteProcessDefEvent(keyDatabaseValue, TenantId, DataId);
                        OSTrace.Debug("EVENT SCHEDULER SCHEDULER DEBUG END: Event WS (SSKey=" + keyDatabaseValue + ",DataId=" + DataId + ") executed successfully, Thread: " + Thread.CurrentThread.ManagedThreadId);
                    } else {
                        OSTrace.Debug("ACTIVITY SCHEDULER DEBUG START: Going to execute activity WS (SSKey=" + keyDatabaseValue + ",ActivityId=" + ActivityId + ",ProcessId=" + ProcessId + ",DataId=" + DataId + "), Thread: " + Thread.CurrentThread.ManagedThreadId);
                        activityHandler.ExecuteOnEvent(keyDatabaseValue, ActivityId, ProcessId, TenantId, DataId, false);
                        OSTrace.Debug("ACTIVITY SCHEDULER DEBUG END: Event WS (SSKey=" + keyDatabaseValue + ",ActivityId=" + ActivityId + ",ProcessId=" + ProcessId + ",DataId=" + DataId + ") executed successfully, Thread: " + Thread.CurrentThread.ManagedThreadId);
                    }
                }
                OSTrace.Debug(String.Format("EVENT SCHEDULER DEBUG: Successfully executed event (id={0},eSpace={1}) for {2} {3}, Thread: {4}",
                    Id.ToString(), EspaceId.ToString(), (ActivityId != 0 ? "Activity" : "Process"), (ActivityId != 0 ? ActivityId.ToString() : ProcessDefId.ToString()), Thread.CurrentThread.ManagedThreadId));
            } else {
                GetEspaceInfo(out string eSpaceName, out string applicationName, out ObjectKey applicationKey);
                ErrorLog.LogApplicationError(EspaceId, TenantId, String.Format(@"Scheduler Service: Discarding event for {0} {1} because it is invalid.", (ActivityId != 0 ? "Activity" : "Process"), (ActivityId != 0 ? ActivityId : ProcessDefId)), string.Empty, null, "Scheduler", eSpaceName, applicationName, applicationKey);
                OSTrace.Debug("EVENT SCHEDULER DEBUG: Event execution discarded because the event is invalid (SSKey=" + keyDatabaseValue + ",ActivityId=" + ActivityId + ",EspaceId=" + EspaceId + ",EspaceName=" + EspaceName + ",ProcessDefId = " + ProcessDefId + ", ProcessId=" + ProcessId + ",ValidTenant=" + ValidTenant + ",DataId = " + DataId + "), Thread: " + Thread.CurrentThread.ManagedThreadId);
            }

            RemoveEvent();
        }

        public override void HandleError(DateTime startDatetime, Exception ex, int durationInSec) {
            // Leaving this here commented just in case we need for debug.
            // Events should are rescheduled if there are errors and deleted on success
            // (There can be exceptions thrown to avoid multiple events to run at the same time)
            bool isAlreadyBeingProcessed = ex.Message.Contains("already being processed");

            try {
                if (isAlreadyBeingProcessed) {
                    RequeueEvent(false);
                } else {
                    GetEspaceInfo(out string eSpaceName, out string applicationName, out ObjectKey applicationKey);

                    string errorId = ErrorLog.LogApplicationError(EspaceId, TenantId, String.Format(@"Scheduler Service: Error executing event {0} (id={1}) for {2} {3}. Request duration = {4} secs. ", Url(), Id, (ActivityId != 0 ? "Activity" : "Process"), (ActivityId != 0 ? ActivityId : ProcessDefId), durationInSec), ex.Message + Environment.NewLine + ex.StackTrace, null, "Scheduler", eSpaceName, applicationName, applicationKey);
                    if (EventExpired) {
                        ErrorLog.LogApplicationError(EspaceId, TenantId, String.Format(@"Scheduler Service: Discarding event for {0} {1} because it exceeded the maximum time for retries({2} days).", (ActivityId != 0 ? "Activity" : "Process"), (ActivityId != 0 ? ActivityId : ProcessDefId), context.SettingsProvider.Get(SchedulerSettings.Events.ProcessBackoffMaxDays)), string.Empty, null, "Scheduler", eSpaceName, applicationName, applicationKey);
                        RemoveEvent();
                    } else {
                        RequeueEvent(true);
                    }
                }
            } catch (Exception e) {
                SchedulerUtils.LogError(String.Format("Scheduler Service: Error handling error of event (id={0})", Id.ToString()), e, SandboxKey, logToEventViewer: true);
            }
        }

        // NOTE: This func gets called with SandboxUtils.SetConfigurationContext() already called with the proper sandbox context
        protected void RequeueEvent(bool hasError) {
            // due to a request time-out update DB job entry and job log
            RetryOnError(
                "updating event (id= {0})".F(Id.ToString()),
                () => {
                    using (Transaction privTrans = context.DatabaseProvider.GetCommitableTransaction()) {
                        DBRuntimePlatform.Instance.RequeueEvent(privTrans, Id, hasError);
                        privTrans.Commit();
                    }
                    OSTrace.Debug(String.Format("EVENT SCHEDULER DEBUG: Successfully updated (and requeued) event (id={0},eSpace={1}). " +
                            (hasError ? "An error has occurred during the previous execution of the event, " : "An attempt has occurred to run several events at the same time, ") + "Thread: {2}",
                            Id.ToString(), EspaceId.ToString(), Thread.CurrentThread.ManagedThreadId));
                });
        }

        // NOTE: This func gets called with SandboxUtils.SetConfigurationContext() already called with the proper sandbox context
        protected void RemoveEvent() {
            RetryOnError(
                "deleting event (id= {0})".F(Id.ToString()),
                () => {
                    using (Transaction privTrans = context.DatabaseProvider.GetCommitableTransaction()) {
                        DBRuntimePlatform.Instance.DeleteEvent(privTrans, Id);
                        privTrans.Commit();
                    }
                    OSTrace.Debug(String.Format("EVENT SCHEDULER DEBUG: Successfully deleted event (id={0},eSpaceId={1}), Thread: {2}",
                        Id.ToString(), EspaceId.ToString(), Thread.CurrentThread.ManagedThreadId));
                });
        }

        private void GetEspaceInfo(out string eSpaceName, out string applicationName, out ObjectKey applicationKey) {
            using (Transaction trans = context.DatabaseProvider.GetReadOnlyTransaction()) {
                DBRuntimePlatform.Instance.GetEspaceAppInfo(trans, EspaceId, out eSpaceName, out applicationName, out applicationKey);
            }
        }
    }

}