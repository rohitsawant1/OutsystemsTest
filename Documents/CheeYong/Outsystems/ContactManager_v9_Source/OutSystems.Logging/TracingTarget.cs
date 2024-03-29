/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using NLog.Common;
using NLog.Targets;
using NLog.Targets.Wrappers;
using OutSystems.RuntimeCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.Logging {
    public class TracingTarget : WrapperTargetBase {

        public TracingTarget(Target target) : base() {
            WrappedTarget = target;
            Name = "TracingTarget_" + target.Name;
        }

#region NLog overrides
        protected override void Write(IList<AsyncLogEventInfo> logEvents) {
            var timer = new Stopwatch();
            timer.Start();
            WrappedTarget.WriteAsyncLogEvents(logEvents);
            timer.Stop();
            InternalLogger.Trace($"Logging to target '{WrappedTarget.Name}' {logEvents.Count} logs took {timer.ElapsedMilliseconds} milliseconds.");
        }

        protected override void Write(AsyncLogEventInfo logEvent) {
            Write(logEvent.ToEnumerable().ToList());
        }
#endregion
    }
}
