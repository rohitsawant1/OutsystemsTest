/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.Scheduler.Core.Configuration {

    public static class SchedulerSettings {

        public static class Misc {
            public static readonly ISetting<int> MaxNumberOfConsumerThreadsInDevelopmentMachines = new Setting<int>("Scheduler.MaxNumberOfConsumerThreadsInDevelopmentMachines", 4);
            public static readonly ISetting<int> DelayAfterErrorsMs = new Setting<int>("Scheduler.DelayAfterErrorsMs", 20000);
            public static readonly ISetting<int> NumberOfRetries = new Setting<int>("Scheduler.NumberOfRetries", 3);
        }

        public static class Timers {
            public static readonly ISetting<int> NumberOfThreadsForTimers = new Setting<int>("Scheduler.NumberOfThreadsForTimers", 10);
            public static readonly ISetting<int> DelayBetweenExecutionsForTimersMs = new Setting<int>("Scheduler.DelayBetweenExecutionsForTimersMs", 1000);
            public static readonly ISetting<int> DelayBetweenDbTimerPollingMs = new Setting<int>("Scheduler.DelayBetweenDbTimerPollingMs", 20000);
            public static readonly ISetting<bool> DisableTimers = new Setting<bool>("Scheduler.DisableTimers", false);
        }

        public static class Activities {
            public static readonly ISetting<int> NumberOfThreadsForActivities = new Setting<int>("Scheduler.NumberOfThreadsForActivities", 10);
            public static readonly ISetting<int> NumberOfJobsPerThreadsForActivities = new Setting<int>("Scheduler.NumberOfJobsPerThreadsForActivities", 5);
            public static readonly ISetting<int> DelayBetweenExecutionsForActivitiesMs = new Setting<int>("Scheduler.DelayBetweenExecutionsForActivitiesMs", 200);
            public static readonly ISetting<int> DelayBetweenDbActivityPollingMs = new Setting<int>("Scheduler.DelayBetweenDbActivityPollingMs", 1500);
            public static readonly ISetting<int> ActivitiesTimeout = new Setting<int>("Scheduler.ActivitiesTimeout", 150);
            public static readonly ISetting<int> AutomaticActivitiesTimeout = new Setting<int>("Scheduler.AutomaticActivitiesTimeout", 300);
            public static readonly ISetting<bool> DisableProcesses = new Setting<bool>("Scheduler.DisableProcesses", false);
            public static readonly ISetting<int> ProcessBackoff_RetrybaseSec = new Setting<int>("Scheduler.ProcessBackoff.RetrybaseSec", 60);
            public static readonly ISetting<decimal> ProcessBackoffConstant = new Setting<decimal>("Scheduler.ProcessBackoffConstant", 1.2m);
        }

        public static class Events {
            public static readonly ISetting<int> NumberOfThreadsForEvents = new Setting<int>("Scheduler.NumberOfThreadsForEvents", 5);
            public static readonly ISetting<int> NumberOfJobsPerThreadForEvents = new Setting<int>("Scheduler.NumberOfJobsPerThreadForEvents", 4);
            public static readonly ISetting<int> DelayBetweenExecutionsForEventsMs = new Setting<int>("Scheduler.DelayBetweenExecutionsForEventsMs", 200);
            public static readonly ISetting<int> ProcessBackoffMaxDays = new Setting<int>("Scheduler.ProcessBackoffMaxDays", 7);
            public static readonly ISetting<int> NumberOfRetriesForEventsErrorHandling = new Setting<int>("Scheduler.NumberOfRetriesForEventsErrorHandling", 3);
        }

        public static class LightEvents {
            public static readonly ISetting<int> NumberOfThreadsForLightEvents = new Setting<int>("Scheduler.NumberOfThreadsForLightEvents", 20);
            public static readonly ISetting<int> DelayBetweenExecutionsForLightEventsMs = new Setting<int>("Scheduler.DelayBetweenExecutionsForLightEventsMs", 10);
            public static readonly ISetting<int> DelayBetweenDbLightEventPollingMs = new Setting<int>("Scheduler.DelayBetweenDbLightEventPollingMs", 500);
            public static readonly ISetting<int> LightProcessBackoffMaxDays = new Setting<int>("Scheduler.LightProcessBackoffMaxDays", 30);
            public static readonly ISetting<bool> EnableLightProcessExecution = new Setting<bool>("BPT.EnableLightProcessExecution", true);
        }

        public static class Emails {
            public static readonly ISetting<int> NumberOfThreadsForEmails = new Setting<int>("Scheduler.NumberOfThreadsForEmails", 2);
            public static readonly ISetting<int> DelayBetweenExecutionsForEmailsMs = new Setting<int>("Scheduler.DelayBetweenExecutionsForEmailsMs", 10);
            public static readonly ISetting<int> DelayBetweenDbEmailPollingMs = new Setting<int>("Scheduler.DelayBetweenDbEmailPollingMs", 5000);
            public static readonly ISetting<int> EmailBackoffMaxDays = new Setting<int>("Scheduler.EmailBackoffMaxDays", 2);
            public static readonly ISetting<int> RecoverEmailHangIntervalInMinutes = new Setting<int>("Scheduler.RecoverEmailHangIntervalInMinutes", 10);
            public static readonly ISetting<bool> DisableEmails = new Setting<bool>("Scheduler.DisableEmails", false);
            public static readonly ISetting<string> Server_Host = new Setting<string>("Email.Server.Host", "");
            public static readonly ISetting<int> Server_Port = new Setting<int>("Email.Server.Port", 25);
            public static readonly ISetting<bool> UseAuthentication = new Setting<bool>("Email.UseAuthentication", false);
            public static readonly ISetting<string> Username = new Setting<string>("Email.Username", "");
            public static readonly ISetting<string> Password = new Setting<string>("Email.Password", "", true);
            public static readonly ISetting<int> SendTimeout = new Setting<int>("OutSystems.HubEdition.SMTP.SendTimeout", 300000);
            public static readonly ISetting<int> ReceivedTimeout = new Setting<int>("OutSystems.HubEdition.SMTP.ReceivedTimeout", 300000);
        }

    }
}