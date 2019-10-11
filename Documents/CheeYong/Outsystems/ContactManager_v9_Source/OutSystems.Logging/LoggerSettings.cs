/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using NLog.Targets.Wrappers;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.Logging {
    public static class LoggerSettings {

        public static readonly ISetting<bool> EnableNLogImplementation = new Setting<bool>("OutSystems.Logging.EnableNLogImplementation", true);

        public static readonly ISetting<bool> CollectLicensingInformation = new Setting<bool>("OutSystems.HubEdition.Log.CollectLicensingInformation", false);
        public static readonly ISetting<int> QueueMessagesMaxAge = new Setting<int>("OutSystems.HubEdition.Log.QueueMessagesMaxAge", 1200);
                              
        public static readonly ISetting<string> QueuePath = new Setting<string>("OutSystems.HubEdition.Log.QueuePath", ".\\Private$\\outsystemslog");
        public static readonly ISetting<string> ScreenLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.ScreenLogQueuePath", ".\\Private$\\OutsystemsScreenLog");
        public static readonly ISetting<string> ExtensionLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.ExtensionLogQueuePath", ".\\Private$\\OutSystemsExtensionLog");
        public static readonly ISetting<string> GeneralLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.GeneralLogQueuePath", ".\\Private$\\OutsystemsGeneralLog");
        public static readonly ISetting<string> TimerLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.TimerLogQueuePath", ".\\Private$\\OutsystemsTimerLog");
        public static readonly ISetting<string> WebReferenceLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.WebReferenceLogQueuePath", ".\\Private$\\OutsystemsWebReferenceLog");
        public static readonly ISetting<string> WebServiceLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.WebServiceLogQueuePath", ".\\Private$\\OutsystemsWebServiceLog");
        public static readonly ISetting<string> CustomLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.CustomLogQueuePath", ".\\Private$\\OutsystemsCustomLog");
        public static readonly ISetting<string> IntegrationLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.IntegrationLogQueuePath", ".\\Private$\\OutsystemsIntegrationLog");
        public static readonly ISetting<string> IntDetailLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.IntDetailLogQueuePath", ".\\Private$\\OutsystemsIntDetailLog");
        public static readonly ISetting<string> AdminQueuePath = new Setting<string>("OutSystems.HubEdition.Log.AdminQueuePath", ".\\Private$\\OutsystemsAdminLog");
        public static readonly ISetting<string> ErrorLogQueuePath = new Setting<string>("OutSystems.HubEdition.Log.ErrorLogQueuePath", ".\\Private$\\OutsystemsErrorLog");
        public static readonly ISetting<string> RequestEventQueuePath = new Setting<string>("OutSystems.HubEdition.Log.RequestEventQueuePath", ".\\Private$\\OutsystemsRequestEvent");
        public static readonly ISetting<string> MobileRequestQueuePath = new Setting<string>("OutSystems.HubEdition.LogMobileRequestQueuePath", ".\\Private$\\OutsystemsMobileRequest"); // no dot after 'log'
        public static readonly ISetting<string> MobileRequestDetailQueuePath = new Setting<string>("OutSystems.HubEdition.LogMobileRequestDetailQueuePath", ".\\Private$\\OutsystemsMobileRequestDetail");

        public static readonly ISetting<bool> SupportBulkLogs = new Setting<bool>("OutSystems.HubEdition.Log.SupportBulkLogs", true);
        public static readonly ISetting<bool> SupportCustomLogs = new Setting<bool>("OutSystems.HubEdition.Log.SupportCustomLogs", true);
        public static readonly ISetting<bool> SupportAsynchronousLogs = new Setting<bool>("OutSystems.HubEdition.Log.SupportAsynchronousLogs", true);
        public static readonly ISetting<bool> SupportPerformanceCounters = new Setting<bool>("OutSystems.HubEdition.Log.SupportPerformanceCounters", true);
        
        public static readonly ISetting<int> LogServerMaxMessagesSizeInKbForLargeContentQueues = new Setting<int>("OutSystems.HubEdition.Log.MaxMessagesSizeInKbForLargeContentQueues", 1000);

        public static readonly ISetting<int> DbCycleSize = new Setting<int>("OutSystems.Logging.CycleSize", 10);
        public static readonly ISetting<int> DbCyclePeriod = new Setting<int>("OutSystems.Logging.CyclePeriod", 7);
        public static readonly ISetting<int> RequestEventsCycleSize = new Setting<int>("OutSystems.Logging.RequestEvents.CycleSize", 3);
        public static readonly ISetting<int> RequestEventsCyclePeriod = new Setting<int>("OutSystems.Logging.RequestEvents.CyclePeriod", 3);

        private static readonly string TimeToWaitBetweenBatchInMs_Key = "OutSystems.Logging.{0}.TimeToWaitBetweenBatchInMs";
        private static readonly string MaxMessagesPerBatch_Key = "OutSystems.Logging.{0}.MaxMessagesPerBatch";
        private static readonly string MaxMessagesInQueue_Key = "OutSystems.Logging.{0}.MaxMessagesInQueue";
        private static readonly string OnQueueOverflowAction_Key = "OutSystems.Logging.{0}.OnQueueOverflowAction";

        public static readonly ISetting<bool> EnableNLogIndependentTragetWrite = new Setting<bool>("OutSystems.Logging.EnableNLogIndependentTragetWrite", false);
        public static readonly ISetting<bool> EnableNLogInternalLogging = new Setting<bool>("OutSystems.Logging.EnableNLogInternalLogging", false);
        public static readonly ISetting<string> NLogInternalLoggingFile = new Setting<string>("OutSystems.Logging.NLogInternalLoggingFile", "");

        private static AsyncTargetWrapperOverflowAction ParseOverflowActionFromString(string overflowAction) {
            return (AsyncTargetWrapperOverflowAction)Enum.Parse(typeof(AsyncTargetWrapperOverflowAction), overflowAction, true);
        }

        public class LogTargetConfigurationSet {
            public readonly ISetting<int> TimeToWaitBetweenBatchInMs;
            public readonly ISetting<int> MaxMessagesPerBatch;
            public readonly ISetting<int> MaxMessagesInQueue;
            public readonly ISetting<string> OnQueueOverflowAction;

            public LogTargetConfigurationSet(string logTypeIdentifier, int TimeToWaitBetweenBatchInMsDefault, int MaxMessagesPerBatchDefault, int MaxMessagesInQueueDefault, string OnQueueOverflowActionDefault) {
                TimeToWaitBetweenBatchInMs = new Setting<int>(TimeToWaitBetweenBatchInMs_Key.F(logTypeIdentifier), TimeToWaitBetweenBatchInMsDefault);
                MaxMessagesPerBatch = new Setting<int>(MaxMessagesPerBatch_Key.F(logTypeIdentifier), MaxMessagesPerBatchDefault);
                MaxMessagesInQueue = new Setting<int>(MaxMessagesInQueue_Key.F(logTypeIdentifier), MaxMessagesInQueueDefault);
                OnQueueOverflowAction = new Setting<string>(OnQueueOverflowAction_Key.F(logTypeIdentifier), OnQueueOverflowActionDefault);
            }
        }

        public static readonly LogTargetConfigurationSet ErrorLog = new LogTargetConfigurationSet(logTypeIdentifier: "ErrorLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet GeneralLog = new LogTargetConfigurationSet(logTypeIdentifier: "GeneralLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet ScreenLog = new LogTargetConfigurationSet(logTypeIdentifier: "ScreenLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet CyclicJobLog = new LogTargetConfigurationSet(logTypeIdentifier: "CyclicJobLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet ExtensionLog = new LogTargetConfigurationSet(logTypeIdentifier: "ExtensionLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet CustomLog = new LogTargetConfigurationSet(logTypeIdentifier: "CustomLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet IntegrationLog = new LogTargetConfigurationSet(logTypeIdentifier: "IntegrationLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet MobileRequestLog = new LogTargetConfigurationSet(logTypeIdentifier: "MobileRequestLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet ServiceAPILog = new LogTargetConfigurationSet(logTypeIdentifier: "ServiceAPILog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet IntDetailLog = new LogTargetConfigurationSet(logTypeIdentifier: "IntDetailLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 50, MaxMessagesInQueueDefault: 500, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet MRDetailLog = new LogTargetConfigurationSet(logTypeIdentifier: "MRDetailLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 50, MaxMessagesInQueueDefault: 500, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet ServiceAPIDetailLog = new LogTargetConfigurationSet(logTypeIdentifier: "ServiceAPIDetailLog", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 50, MaxMessagesInQueueDefault: 500, OnQueueOverflowActionDefault: "Discard");
        public static readonly LogTargetConfigurationSet RequestEvent = new LogTargetConfigurationSet(logTypeIdentifier: "RequestEvent", TimeToWaitBetweenBatchInMsDefault: 2000, MaxMessagesPerBatchDefault: 1000, MaxMessagesInQueueDefault: 10000, OnQueueOverflowActionDefault: "Discard");

        // Large Content
        public static readonly ISetting<int> MaxMessagesSizeInKbForLargeContentQueues = new Setting<int>("OutSystems.Logging.MaxMessagesSizeInKbForLargeContentQueues", 1000);

        // Window Sizes (they are being excluded from appSettings.config)
        public static readonly ISetting<int> DbWindowSize = new Setting<int>("LogServer.Db.WindowSize", 4);
        public static readonly ISetting<int> RequestEventsWindowSize = new Setting<int>("LogServer.Db.WindowSize.RequestEvent", 2);
    }
}
