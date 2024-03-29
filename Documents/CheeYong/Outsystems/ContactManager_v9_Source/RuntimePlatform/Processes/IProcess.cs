/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform.Processes {

    public interface IProcess {
        IProcess Instance { get; }

        Dictionary<ObjectKey, IActivityVariable> ProcessOutputs { get; set; }

        ActivityVariable<T> GetProcessInput<T>(ActivityVariable<T> variableDefinition);
        ActivityVariable<T> GetProcessOutput<T>(ActivityVariable<T> variableDefinition);

        int ProcessId { get; }

        void SaveProcessOutputs(HeContext heContext);

        void OnProcessStartCallback(HeContext heContext);
        void OnActivityReadyCallback(HeContext heContext);
        void OnActivityOpenCallback(HeContext heContext);
        void OnActivityStartCallback(HeContext heContext);
        void OnActivityCloseCallback(HeContext heContext);
        void OnActivitySkipCallback(HeContext heContext);
        void ProcessImplicitLaunch(HeContext heContext, string dataId, out int processId);
        int ProcessLaunch(HeContext heContext, int parentActivityId, int parentProcessId, List<Pair<string, object>> inputs, out List<Pair<int, ActivityKind>> nextActIds);
        bool ProcessTerminate(HeContext heContext, int processId, out string failureMessage);
        bool SetProcessSuspension(HeContext heContext, int processId, bool suspend, out string failureMessage);

        /// <summary>
        /// Used to get a generic activity instance using a intance of a process definition
        /// </summary>
        bool GetProcessActivityInstance(int processId, int activityId, ObjectKey activityKey, bool isRunning, out IProcessActivity instance);
	}

}