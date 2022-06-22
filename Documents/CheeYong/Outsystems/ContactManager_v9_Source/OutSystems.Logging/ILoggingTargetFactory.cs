/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using NLog.Targets;

namespace OutSystems.Logging {

    public interface ILoggingTargetFactory {

        Target CreateTargetForScreenLogs();

        Target CreateTargetForExtensionLogs();

        Target CreateTargetForGeneralLogs();

        Target CreateTargetForErrorLogs();

        Target CreateTargetForCyclicJobLogs();

        Target CreateTargetForCustomLogs();

        Target CreateTargetForIntegrationLogs();

        Target CreateTargetForIntDetailLogs();

        Target CreateTargetForRequestEvents();

        Target CreateTargetForMobileRequestLogs();

        Target CreateTargetForMRDetailLogs();

        Target CreateTargetForServiceAPILogs();

        Target CreateTargetForServiceAPIDetailLogs();

    }

}