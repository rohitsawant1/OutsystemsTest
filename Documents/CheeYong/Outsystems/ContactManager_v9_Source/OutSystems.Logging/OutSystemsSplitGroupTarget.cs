/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using NLog;
using NLog.Common;
using NLog.Targets;
using NLog.Targets.Wrappers;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Log;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OutSystems.Logging {
    public class OutSystemsSplitGroupTarget : CompoundTargetBase {

        public OutSystemsSplitGroupTarget(IEnumerable<Target> destinationTargets) : base(destinationTargets.ToArray()){
            Name = "OutSystemsSplitGroupTarget(" + string.Join(",", Targets.Select(t => t.Name)) + ")";
            OptimizeBufferReuse = true;
        }

        private void Write(IEnumerable<AsyncLogEventInfo> logs) {
            var localLogs = logs
                    .Select(asyncEvent => 
                        new AsyncLogEventInfo(
                            asyncEvent.LogEvent, 
                            WrapContinuation(
                                asyncEvent.Continuation,
                                Targets.Count)))
                    .ToList();

            Task.WaitAll(
                Targets
                    .Select(target => TargetWriteAsync(target, localLogs))
                    .ToArray());
        }

        private Task TargetWriteAsync(Target target, IList<AsyncLogEventInfo> logs) {
            var writeTask = new Task(() => {
                try {
                    var logsCopy = new AsyncLogEventInfo[logs.Count];
                    logs.CopyTo(logsCopy, 0);
                    target.WriteAsyncLogEvents(logsCopy);
                } catch(Exception ex) {
                    EventLogger.WriteError(ex);
                    InternalLogger.Trace<Exception>("Outsystems Splited Async Log failed for target '" + target.Name + "': {0}", ex);
                }
            });

            writeTask.Start();

            return writeTask;
        }

        private AsyncContinuation WrapContinuation(AsyncContinuation originalContinuation, int counter) {
            if (counter == 1) {
                return originalContinuation;
            }
            var exceptions = new ConcurrentBag<Exception>();
            return (ex) => {
                int num = Interlocked.Decrement(ref counter);
                if(ex != null) {
                    exceptions.Add(ex);
                }
                if (num == 0) {
                    Exception combinedException = null;
                    if (!exceptions.IsEmpty) {
                        combinedException = AsyncHelpers.GetCombinedException(exceptions.ToList());
                        InternalLogger.Trace<Exception>("Combined exception: {0}", combinedException);
                    }
                    originalContinuation(combinedException);
                } else {
                    InternalLogger.Trace<int>("{0} remaining.", num);
                }
            };
        }

        #region NLog overrides

        protected override void Write(IList<AsyncLogEventInfo> logEvents) {
            Write(logEvents);
        }

        protected override void Write(AsyncLogEventInfo logEvent) {
            Write(logEvent.ToEnumerable());
        }

        protected override void Write(LogEventInfo logEvent) {
            throw new NotSupportedException("Synchronous logs not supported");
        }
        #endregion
    }
}
