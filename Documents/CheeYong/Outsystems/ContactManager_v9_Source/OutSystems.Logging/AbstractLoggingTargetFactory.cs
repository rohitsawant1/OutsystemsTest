/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using NLog.Targets;
using OutSystems.Logging.LogDefinition;

namespace OutSystems.Logging {

    public abstract class AbstractLoggingTargetFactory : ILoggingTargetFactory {

        public virtual Target CreateTargetForScreenLogs() {
            return CreateTargetFor<ScreenLogDefinition>();
        }

        public virtual Target CreateTargetForExtensionLogs() {
            return CreateTargetFor<ExtensionLogDefinition>();
        }

        public virtual Target CreateTargetForGeneralLogs() {
            return CreateTargetFor<GeneralLogDefinition>();
        }

        public virtual Target CreateTargetForErrorLogs() {
            return CreateTargetFor<ErrorLogDefinition>();
        }

        public virtual Target CreateTargetForCyclicJobLogs() {
            return CreateTargetFor<CyclicJobLogDefinition>();
        }

        public virtual Target CreateTargetForCustomLogs() {
            return CreateTargetFor<CustomLogDefinition>();
        }

        public virtual Target CreateTargetForIntegrationLogs() {
            return CreateTargetFor<IntegrationLogDefinition>();
        }

        public virtual Target CreateTargetForIntDetailLogs() {
            return CreateTargetFor<IntDetailLogDefinition>();
        }

        public virtual Target CreateTargetForRequestEvents() {
            return CreateTargetFor<RequestEventDefinition>();
        }

        public virtual Target CreateTargetForMobileRequestLogs() {
            return CreateTargetFor<MobileRequestLogDefinition>();
        }

        public virtual Target CreateTargetForMRDetailLogs() {
            return CreateTargetFor<MRDetailLogDefinition>();
        }

        public virtual Target CreateTargetForServiceAPILogs() {
            return CreateTargetFor<ServiceAPILogDefinition>();
        }

        public virtual Target CreateTargetForServiceAPIDetailLogs() {
            return CreateTargetFor<ServiceAPIDetailLogDefinition>();
        }

        protected abstract Target CreateTargetFor<T>() where T : AbstractLogDefinition;

    }

}
