/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Common;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using OutSystems.Logging.LogDefinition;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Settings;
using System.Collections.Concurrent;
using OutSystems.RuntimeCommon.Log;
using System.Diagnostics;

namespace OutSystems.Logging.Implementations {
    public class NLogLoggerImplementation : LoggerImplementation {
        
        private const string TruncatedLogMessageSuffix = "\r\n<Message truncated in logging because it exceeded the maximum size>";

        private readonly string loggerIdentity = Guid.NewGuid().ToString();
        private readonly ConcurrentDictionary<Type, Target> targets = new ConcurrentDictionary<Type, Target>();
        private readonly ISettingsProvider settingsProvider;
        private readonly IEnumerable<ILoggingTargetFactory> targetFactories;
        private readonly Func<Target, WrapperTargetBase> extraTargetWrapper;

        private readonly int maxMessagesSizeInKbForLargeContentQueues;

        private void SendLog<T>(T log) {
            var targetType = typeof(T);
            var target = targets[targetType];
            if (target != null) { // Only deliver logs if there are targets defined for them
                var syncEvent = new OutSystemsLogEventInfo(log as AbstractLogDefinition);
                AsyncLogEventInfo @event = new AsyncLogEventInfo(syncEvent, onAfterSend);
                target.WriteAsyncLogEvent(@event);
            }
        }

        public virtual void onAfterSend(Exception ex) {
            if (ex != null) {
                EventLogger.WriteError(ex);
            }
        }

        public override void Log(ScreenLogDefinition log) {
            SendLog(log);
        }

        public override void Log(ExtensionLogDefinition log) {
            SendLog(log);
        }

        public override void Log(GeneralLogDefinition log) {
            SendLog(log);
        }

        public override void Log(ErrorLogDefinition log) {
            SendLog(log);
        }

        public override void Log(CyclicJobLogDefinition log) {
            SendLog(log);
        }

        public override void Log(CustomLogDefinition log) {
            if (!settingsProvider.Get(LoggerSettings.SupportBulkLogs)) {
                throw new NotSupportedException("Bulk logs not supported in this installation. Please contact {C}.".ReplaceBranding());
            }

            if (!settingsProvider.Get(LoggerSettings.SupportCustomLogs)) {
                throw new NotSupportedException("Custom Logs not supported in this installation. Please contact {C} support.".ReplaceBranding());
            }
            SendLog(log);
        }

        public override void Log(IntegrationLogDefinition log) {
            SendLog(log);
        }

        public override void Log(IntDetailLogDefinition log) {
            if (log.Detail != null && log.Detail.Length > maxMessagesSizeInKbForLargeContentQueues) {
                var builder = new StringBuilder(maxMessagesSizeInKbForLargeContentQueues + TruncatedLogMessageSuffix.Length + 1);
                builder.Append(log.Detail, 0, maxMessagesSizeInKbForLargeContentQueues - TruncatedLogMessageSuffix.Length);
                builder.Append(TruncatedLogMessageSuffix);
                log.Detail = builder.ToString();
            }

            SendLog(log);
        }

        public override void Log(RequestEventDefinition log) {
            SendLog(log);
        }

        public override void Log(MobileRequestLogDefinition log) {
            SendLog(log);
        }

        public override void Log(MRDetailLogDefinition log) {
            if (log.Detail != null && log.Detail.Length > maxMessagesSizeInKbForLargeContentQueues) {
                var builder = new StringBuilder(maxMessagesSizeInKbForLargeContentQueues + TruncatedLogMessageSuffix.Length + 1);
                builder.Append(log.Detail, 0, maxMessagesSizeInKbForLargeContentQueues - TruncatedLogMessageSuffix.Length);
                builder.Append(TruncatedLogMessageSuffix);
                log.Detail = builder.ToString();
            }

            SendLog(log);
        }

        public override void Log(ServiceAPILogDefinition log) {
            SendLog(log);
        }

        public override void Log(ServiceAPIDetailLogDefinition log) {
            if (log.Detail != null && log.Detail.Length > maxMessagesSizeInKbForLargeContentQueues) {
                var builder = new StringBuilder(maxMessagesSizeInKbForLargeContentQueues + TruncatedLogMessageSuffix.Length + 1);
                builder.Append(log.Detail, 0, maxMessagesSizeInKbForLargeContentQueues - TruncatedLogMessageSuffix.Length);
                builder.Append(TruncatedLogMessageSuffix);
                log.Detail = builder.ToString();
            }

            SendLog(log);
        }

        public NLogLoggerImplementation(IServiceProvider serviceProvider, Func<Target, WrapperTargetBase> extraTargetWrapper = null) {
            this.settingsProvider = serviceProvider.GetRequiredService<ISettingsProvider>();
            this.extraTargetWrapper = extraTargetWrapper;

            var pluginProvider = serviceProvider.GetRequiredService<LoggingPluginProvider>();

            this.targetFactories = pluginProvider.Implementations
                                                 .Where(impl => impl.AppliesTo(settingsProvider))
                                                 .OrderByDescending((plugin) => plugin.Priority)
                                                 .Select(impl => impl.GetLoggingTargetFactory(serviceProvider))
                                                 .ToArray();
            
            this.maxMessagesSizeInKbForLargeContentQueues = settingsProvider.Get(LoggerSettings.MaxMessagesSizeInKbForLargeContentQueues) * 1000;
        }

        private void AddLogTarget(Type logType, List<Target> finalTargets, LoggerSettings.LogTargetConfigurationSet config){
            if (finalTargets != null) { // Only register targets if there are implementations
                targets[logType] = WrapTargetAndRegister(logType, finalTargets, config);
            }
        }

        private Target WrapTargetAndRegister(Type logType, List<Target> targets, LoggerSettings.LogTargetConfigurationSet config) {
            if (targets == null) {
                return null;
            }

            var internalLoggingEnabled = settingsProvider.Get(LoggerSettings.EnableNLogInternalLogging);
            Target buffer, asyncTarget, splitTarget, finalTarget;

            if (settingsProvider.Get(LoggerSettings.EnableNLogIndependentTragetWrite)) {
                var destinationTargets = targets.Select(t => {
                    if (extraTargetWrapper != null) {
                        t = extraTargetWrapper(t);
                    }

                    if (internalLoggingEnabled) {
                        t = new TracingTarget(t);
                    }

                    buffer = CreateBufferTarget(t, logType, config);
                    asyncTarget = CreateAsyncTarget(buffer, logType, config);
                    return asyncTarget;
                });

                splitTarget = new OutSystemsSplitGroupTarget(destinationTargets.ToArray());

                finalTarget = splitTarget;
            } else {
                var destinationTargets = targets.Select(t => {
                    if (extraTargetWrapper != null) {
                        return extraTargetWrapper(t);
                    }
                    return t;
                });

                splitTarget = new OutSystemsSplitGroupTarget(destinationTargets.ToArray());

                if (internalLoggingEnabled) {
                    splitTarget = new TracingTarget(splitTarget);
                }

                buffer = CreateBufferTarget(splitTarget, logType, config);

                asyncTarget = CreateAsyncTarget(buffer, logType, config);

                finalTarget = asyncTarget;
            }

            LogManager.Configuration.AddTarget(GetTargetNameUsedForConfiguration(logType), finalTarget);

            return finalTarget;
        }

        private Target CreateAsyncTarget(Target innerTarget, Type logType, LoggerSettings.LogTargetConfigurationSet config) {
            return new AsyncTargetWrapper(
                                                    innerTarget,
                                                    settingsProvider.Get(config.MaxMessagesInQueue),
                                                    ParseOverflowActionFromString(
                                                        settingsProvider.Get(config.OnQueueOverflowAction))) {
                Name = "AsyncTargetFor" + logType.Name,
                FullBatchSizeWriteLimit = 15,
                OptimizeBufferReuse = true// Ensure targets are always optimized
            };
        }

        private Target CreateBufferTarget(Target innerTarget, Type logType, LoggerSettings.LogTargetConfigurationSet config) {
            return new BufferingTargetWrapper(
                                                    innerTarget,
                                                    settingsProvider.Get(config.MaxMessagesPerBatch),
                                                    settingsProvider.Get(config.TimeToWaitBetweenBatchInMs),
                                                    overflowAction: BufferingTargetWrapperOverflowAction.Flush) {
                Name = "BufferingTargetFor" + logType.Name,
                SlidingTimeout = false,
                OptimizeBufferReuse = true // Ensure targets are always optimized
            };
        }
        private static AsyncTargetWrapperOverflowAction ParseOverflowActionFromString(string overflowAction) {
            return (AsyncTargetWrapperOverflowAction)Enum.Parse(typeof(AsyncTargetWrapperOverflowAction), overflowAction, true);
        }

        private string GetTargetNameUsedForConfiguration(Type logType) {
            return loggerIdentity + "|" + logType.Name + "Target";
        }

        public override void SetUp() {
            if (LogManager.Configuration == null) { // Ensure we have a configuration object even if there is no config file
                LogManager.Configuration = new LoggingConfiguration();
            }

            Dictionary<Type, List<Target>> targetsToAdd = new Dictionary<Type, List<Target>>() {
                { typeof(ErrorLogDefinition), new List<Target>() } ,
                { typeof(GeneralLogDefinition), new List<Target>() } ,
                { typeof(ScreenLogDefinition), new List<Target>() } ,
                { typeof(CyclicJobLogDefinition), new List<Target>() } ,
                { typeof(ExtensionLogDefinition), new List<Target>() } ,
                { typeof(CustomLogDefinition), new List<Target>() } ,
                { typeof(IntegrationLogDefinition), new List<Target>() } ,
                { typeof(MobileRequestLogDefinition), new List<Target>() } ,
                { typeof(ServiceAPILogDefinition), new List<Target>() } ,
                { typeof(IntDetailLogDefinition), new List<Target>() } ,
                { typeof(MRDetailLogDefinition), new List<Target>() } ,
                { typeof(ServiceAPIDetailLogDefinition), new List<Target>() } ,
                { typeof(RequestEventDefinition), new List<Target>() }
            };

            foreach(ILoggingTargetFactory factory in targetFactories) {
                targetsToAdd[typeof(ErrorLogDefinition)].Add(factory.CreateTargetForErrorLogs());
                targetsToAdd[typeof(GeneralLogDefinition)].Add(factory.CreateTargetForGeneralLogs());
                targetsToAdd[typeof(ScreenLogDefinition)].Add(factory.CreateTargetForScreenLogs());
                targetsToAdd[typeof(CyclicJobLogDefinition)].Add(factory.CreateTargetForCyclicJobLogs());
                targetsToAdd[typeof(ExtensionLogDefinition)].Add(factory.CreateTargetForExtensionLogs());
                targetsToAdd[typeof(CustomLogDefinition)].Add(factory.CreateTargetForCustomLogs());
                targetsToAdd[typeof(IntegrationLogDefinition)].Add(factory.CreateTargetForIntegrationLogs());
                targetsToAdd[typeof(MobileRequestLogDefinition)].Add(factory.CreateTargetForMobileRequestLogs());
                targetsToAdd[typeof(ServiceAPILogDefinition)].Add(factory.CreateTargetForServiceAPILogs());
                targetsToAdd[typeof(IntDetailLogDefinition)].Add(factory.CreateTargetForIntDetailLogs());
                targetsToAdd[typeof(MRDetailLogDefinition)].Add(factory.CreateTargetForMRDetailLogs());
                targetsToAdd[typeof(ServiceAPIDetailLogDefinition)].Add(factory.CreateTargetForServiceAPIDetailLogs());
                targetsToAdd[typeof(RequestEventDefinition)].Add(factory.CreateTargetForRequestEvents());
            }

            foreach(KeyValuePair<Type, List<Target>> targets in targetsToAdd) {
                AddLogTarget(targets.Key, targets.Value, GetLogTypeSettings(targets.Key));
            }
            
            if (settingsProvider.Get(LoggerSettings.EnableNLogInternalLogging)) {
                InternalLogger.LogFile = settingsProvider.Get(LoggerSettings.NLogInternalLoggingFile);
                InternalLogger.LogLevel = LogLevel.Trace;
            }

            LogManager.ReconfigExistingLoggers();
        }

        private LoggerSettings.LogTargetConfigurationSet GetLogTypeSettings(Type logType) {
            if(typeof(ErrorLogDefinition).Equals(logType)) {
                return LoggerSettings.ErrorLog;
            } else if (typeof(GeneralLogDefinition).Equals(logType)) {
                return LoggerSettings.GeneralLog;
            } else if (typeof(ScreenLogDefinition).Equals(logType)) {
                return LoggerSettings.ScreenLog;
            } else if (typeof(CyclicJobLogDefinition).Equals(logType)) {
                return LoggerSettings.CyclicJobLog;
            } else if (typeof(ExtensionLogDefinition).Equals(logType)) {
                return LoggerSettings.ExtensionLog;
            } else if (typeof(CustomLogDefinition).Equals(logType)) {
                return LoggerSettings.CustomLog;
            } else if (typeof(IntegrationLogDefinition).Equals(logType)) {
                return LoggerSettings.IntegrationLog;
            } else if (typeof(MobileRequestLogDefinition).Equals(logType)) {
                return LoggerSettings.MobileRequestLog;
            } else if (typeof(ServiceAPILogDefinition).Equals(logType)) {
                return LoggerSettings.ServiceAPIDetailLog;
            } else if (typeof(IntDetailLogDefinition).Equals(logType)) {
                return LoggerSettings.IntDetailLog;
            } else if (typeof(MRDetailLogDefinition).Equals(logType)) {
                return LoggerSettings.MRDetailLog;
            } else if (typeof(ServiceAPIDetailLogDefinition).Equals(logType)) {
                return LoggerSettings.ServiceAPIDetailLog;
            } else if (typeof(RequestEventDefinition).Equals(logType)) {
                return LoggerSettings.RequestEvent;
            }
            return null;
        }

        public override void Stop() {
            base.Stop();

            foreach (var logType in targets.Keys.ToArray()) {
                if (targets.TryRemove(logType, out Target target)) {
                    string registedTargetName = GetTargetNameUsedForConfiguration(logType);
                    LogManager.Configuration.RemoveTarget(registedTargetName);
                    target.Dispose(); // The RemoveTarget should close it internally, but lets make sure we Dispose it
                }
            }
        }
    }
}
