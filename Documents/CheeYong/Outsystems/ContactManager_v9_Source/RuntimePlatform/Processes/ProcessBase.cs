/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.ObfuscationProperties;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.HubEdition.RuntimePlatform.Processes {

    [DoNotObfuscateType]
    public abstract partial class ProcessBase : IProcess {
        public delegate IProcessActivity CreateActivityDelegate(int processId, int activityId, bool isRunning);
        public static readonly int DummyId = BuiltInFunction.NullIdentifier();
        protected abstract GlobalObjectKey GlobalKey { get; }

        IProcess IProcess.Instance { get { return null; } }
        protected abstract IProcess NewInstance();

        private int processIdOverride = DummyId;
        private int ProcessIdOverride {
            get { return processIdOverride; }
            set { processIdOverride = value; }
        }

        private readonly IProcessActivity ownerActivity;
        public int ProcessId {
            get {
                if (ownerActivity != null) {
                    return ownerActivity.ProcessId;
                }
                return processIdOverride;
            }
        }

        public abstract string Name { get; }

        //A process instance in runtime always has an activity instance associated to allow the callbacks to have the correct values
        public int ActivityId {
            get {
                if (ownerActivity != null) {
                    return ownerActivity.ActivityId;
                }
                return DummyId;
            }
        }

        protected ProcessBase(IProcessActivity ownerActivity) {
            this.ownerActivity = ownerActivity;
        }

        /// <summary>
        /// This delegate is used to retrieve outputs from the database
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="SSKey"></param>
        /// <param name="id"></param>
        /// <returns>A reader with the attributes "SS_Key", "Value" and "Data_Type"</returns>
        protected delegate IDataReader GetVariablesDelegate(Transaction tran, ObjectKey SSKey, int id);

        protected static ActivityVariable<T> GetVariable<T>(ActivityVariable<T> variableDefinition, GetVariablesDelegate getMethod, int id) {
            object rawVariable = null;

            if (id != DummyId) {
                using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                    using (IDataReader reader = getMethod(trans, variableDefinition.Key, id)) {
                        if (reader.Read()) {
                            rawVariable = RuntimePlatformUtils.ConvertFromString((string) reader["Value"], (string) reader["Data_Type"]);
                        }
                    }
                }            
            }
            
            return ((rawVariable != null) ? variableDefinition.NewInstance<T>(rawVariable) : variableDefinition.NewInstance<T>());
        }

        protected static ActivityVariable<T> GetVariable<T>(Dictionary<ObjectKey, IActivityVariable> collection, ActivityVariable<T> variableDefinition, GetVariablesDelegate getMethod, int id) {
            IActivityVariable variable;
            ActivityVariable<T> variableGeneric;

            if (collection.TryGetValue(variableDefinition.Key, out variable)) {
                variableGeneric = variable as ActivityVariable<T>;
                if (variableGeneric == null) { //for some reason it has the wrong type, so lets fix it here
                    variableGeneric = variableDefinition.NewInstance<T>(variable.ValueObj);
                    collection[variableDefinition.Key] = variableGeneric;
                }
            } else {
                variableGeneric = GetVariable(variableDefinition, getMethod, id);
                collection[variableDefinition.Key] = variableGeneric;
            }
            return variableGeneric;
        }

        
        //Process Inputs Cache
        private Dictionary<ObjectKey, IActivityVariable> processInputs = null;
        protected Dictionary<ObjectKey, IActivityVariable> ProcessInputs {
            get {
                return processInputs ?? (processInputs = new Dictionary<ObjectKey, IActivityVariable>());
            }
        }

        protected virtual Dictionary<ObjectKey, IActivityVariable> AllProcessInputsDefinitions {
            get { return new Dictionary<ObjectKey, IActivityVariable>(0); }
        }

        public ActivityVariable<T> GetProcessInput<T>(ActivityVariable<T> variableDefinition) {
            return GetVariable(ProcessInputs, variableDefinition, DBRuntimePlatform.Instance.GetProcessInput, ProcessId);
        }

        //Process Outputs Cache
        private Dictionary<ObjectKey, IActivityVariable> processOutputs = null;
        public Dictionary<ObjectKey, IActivityVariable> ProcessOutputs {
            get {
                return processOutputs ?? (processOutputs = new Dictionary<ObjectKey, IActivityVariable>());
            }
            set {
                processOutputs = value;
            }
        }
        
        protected virtual Dictionary<ObjectKey, IActivityVariable> AllProcessOutputsDefinitions {
            get { return new Dictionary<ObjectKey, IActivityVariable>(0); }
        }

        public ActivityVariable<T> GetProcessOutput<T>(ActivityVariable<T> variableDefinition) {
            return GetVariable(ProcessOutputs, variableDefinition, DBRuntimePlatform.Instance.GetProcessOutput, ProcessId);
        }

        public void SaveProcessOutputs(HeContext heContext) {
            using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                int tenantId = heContext.AppInfo.Tenant.Id;

                foreach (IActivityVariable output in ProcessOutputs.Values.Where(val => val.WasSet)) {
                    DBRuntimePlatform.Instance.AddOrUpdateProcessOutput(trans, ProcessId, tenantId, output);
                }
            }
        }

        public void SaveUnsetProcessOutputs(HeContext heContext) {
            using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                int tenantId = heContext.AppInfo.Tenant.Id;

                List<IActivityVariable> defaultOutputs = new List<IActivityVariable>();

                using (IDataReader reader = DBRuntimePlatform.Instance.GetUnsetProcessOutputs(trans, ProcessId)) {
                    while (reader.Read()) {
                        string sskey = (string) reader["SS_KEY"];
                        IActivityVariable outputDef;
                        if (AllProcessOutputsDefinitions.TryGetValue(ObjectKey.Parse(sskey), out outputDef)) {
                            defaultOutputs.Add(outputDef);
                        }
                    }
                }

                foreach (IActivityVariable output in defaultOutputs) {
                    DBRuntimePlatform.Instance.AddProcessOutput(trans, ProcessId, tenantId, output);
                }
            }
        }

        public virtual void OnProcessStartCallback(HeContext heContext) { }
        public virtual void OnActivityReadyCallback(HeContext heContext) { }
        public virtual void OnActivityOpenCallback(HeContext heContext) { }
        public virtual void OnActivityStartCallback(HeContext heContext) { }
        public virtual void OnActivityCloseCallback(HeContext heContext) { }
        public virtual void OnActivitySkipCallback(HeContext heContext) { }

        public abstract bool GetProcessActivityInstance(int processId, int activityId, ObjectKey activityKey, bool isRunning, out IProcessActivity instance);

        public abstract void FillActivitiesDefinitions(Dictionary<ObjectKey, CreateActivityDelegate> dic);

        public virtual void ProcessImplicitLaunch(HeContext heContext, string dataId, out int processId) {
            processId = DummyId;
        }

        public int ProcessLaunch(HeContext heContext, int parentActivityId, int parentProcessId, List<Pair<string, object>> inputs, out List<Pair<int, ActivityKind>> nextActIds) {
            nextActIds = new List<Pair<int, ActivityKind>>();
            //Sanity check to make sure we dont get here with the singleton process instance for the "definitions"
            if (Object.ReferenceEquals(((IProcess)this).Instance, this)) {
                return NewInstance().ProcessLaunch(heContext, parentActivityId, parentProcessId, inputs, out nextActIds);
            }

            int tenantId = heContext.AppInfo.Tenant.Id;
            Pair<int, ObjectKey> startActivity;
            processIdOverride = BPMRuntime.CreateProcessInstance(heContext, tenantId, GlobalKey.OwnerKey, GlobalKey.Key, parentActivityId, parentProcessId, out startActivity);
            
            var inputDefinitions = AllProcessInputsDefinitions;
            Dictionary<ObjectKey, IActivityVariable> inputsProcessed = new Dictionary<ObjectKey, IActivityVariable>(inputDefinitions.Count);
            IActivityVariable curInput;

            foreach (Pair<string, object> input in inputs) {
                ObjectKey key = ObjectKey.Parse(input.First);
                if(inputDefinitions.TryGetValue(key, out curInput)) {
                    inputsProcessed[key] = curInput.NewInstance(input.Second);
                }
            }

            using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                foreach (var input in inputsProcessed.Values) {
                    DBRuntimePlatform.Instance.AddProcessInput(trans, ProcessId, tenantId, input);
                    this.ProcessInputs[input.Key] = input;
                }
            }

            Debugger.SetRequestName("Launch '" + Name + "'" );

            OnProcessStartCallback(heContext);
            
            //#586734 Check if the process was created.
            //A rollback in the OnProcessStart can delete the process that was created.
            using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                if (!DBRuntimePlatform.Instance.CheckProcessExists(trans, ProcessId)) {
                    throw new InvalidOperationException("Failed to created process " + ProcessId);
                }
            }

            int previousTenantId = tenantId;
            tenantId = heContext.AppInfo.Tenant.Id;
            if (previousTenantId != tenantId) {
                //Do not use the same variable as above because that transaction can already be commited
                using (Transaction trans = DatabaseAccess.ForRuntimeDatabase.GetRequestTransaction()) {
                    DBRuntimePlatform.Instance.SwitchProcessTenant(trans, ProcessId, previousTenantId, tenantId);
                }
            }

            SaveProcessOutputs(heContext);
            DatabaseAccess.CommitAllTransactions();
                try {
                    IProcessActivity startActivityInstance;
                    if (GetProcessActivityInstance(ProcessId, startActivity.First, startActivity.Second, true, out startActivityInstance)) {
                        var nextActivities = startActivityInstance.StartWork(heContext, false, ActivityStatus.Created)
                                                    .Select(nextAct => Pair.Create(nextAct.First, nextAct.Second));
                
                        nextActIds = new List<Pair<int,ActivityKind>>(nextActivities);

                        //TODO #124852
                        //if (!nextActivities.IsEmpty()) {
                        //    //Do not use the same variable as above because that transaction will already be commited
                        //    nextHumanActivity = BPMRuntime.GetNextHumanActivity(heContext,
                        //        DBTransactionManager.Current.SystemConnectionManager.GetMainTransaction(), nextActivities, heContext.Session.UserId);
                        //}
                    }
                } catch (Exception e) {
                    // This should only happen if there are problems getting the next human activity, but we still want to return the process Id that was already created.
                    Log.ErrorLog.StaticWrite(DateTime.Now, "", heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
                        heContext.Session.UserId, e.Message, e.StackTrace, "BPM");
                }

            return ProcessId;
        }

        public bool ProcessTerminate(HeContext heContext, int processId, out string failureMessage) {
            return SafeExecuteAction(() => BPMRuntime.TerminateProcessInstance(heContext, this, processId), out failureMessage);
        }

        public bool SetProcessSuspension(HeContext heContext, int processId, bool suspend, out string failureMessage) {
            return SafeExecuteAction(() => BPMRuntime.SuspendProcessInstance(heContext, processId, suspend), out failureMessage);
        }

        private bool SafeExecuteAction(Action method, out string failureMessage) {
            bool success = false;
            failureMessage = string.Empty;

            try {
                method();
                DatabaseAccess.CommitAllTransactions();
                success = true;
            } catch (Exception e) {
                DatabaseAccess.RollbackAllTransactions();
                
                if (e.InnerException != null && (e is TypeInitializationException))
                    e = e.InnerException;

                failureMessage = e.Message;
            }
            return success;
        }

        public static string ProcessException(HeContext heContext, Exception e, string extraMessage, bool skipLog) {
            string errorId;
            return ProcessException(heContext, e, string.Empty, skipLog, out errorId);
        }
        
        public static string ProcessException(HeContext heContext, Exception e, string extraMessage, bool skipLog, out string errorId) {
            DatabaseAccess.RollbackAllTransactions();

            if (e.InnerException != null && (e is TypeInitializationException)) {
                e = e.InnerException;
            }

            errorId = null;
            if (!skipLog) {
                if (e is AbortActivityChangeException) {
                    if (heContext.AppInfo.Properties.AllowAuditing) {
                        Log.GeneralLog.StaticWrite(DateTime.Now, "", heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
                        heContext.Session.UserId, e.Message, "USER", "AbortActivity", "");
                    }
                } else {
                    errorId = Log.ErrorLog.StaticWrite(DateTime.Now, "", heContext.AppInfo.eSpaceId, heContext.AppInfo.Tenant.Id,
                        heContext.Session.UserId, e.Message, e.StackTrace, "BPM");
                }
            } else {
                errorId = null;
            }

            string message = e.Message;
            if (!extraMessage.IsEmpty()) {
                message = extraMessage + " " + message;
            }

            Type exceptionType = e.GetType();
            String fullExceptionName = exceptionType.FullName;
            fullExceptionName += ", " + exceptionType.Assembly.GetName().Name;

            return string.Format("[Exception:{0}]{1}", fullExceptionName, message);
        }

        public static void ThrowSpecificException(string failureMessage) {
            string exceptionMessage = failureMessage;
            Exception specificException = null;

            try {
                string pattern = "\\[Exception:([^\\]]+)\\](.*)";
                Match match = Regex.Match(failureMessage, pattern, RegexOptions.Singleline);

                if (match.Success) {
                    string exceptionType = match.Groups[1].Value;
                    exceptionMessage = match.Groups[2].Value;
                    Type currType = Type.GetType(exceptionType, /*throwOnError*/false, /*ignoreCase*/true);
                    Boolean cond = currType != null && currType.IsSubclassOf(typeof(Exception));

                    if (cond) {
                        var constructor = currType.GetConstructor(new Type[] { typeof(String) });
                        if (constructor != null) {
                            specificException = (Exception)constructor.Invoke(new object[] { exceptionMessage });
                        }
                    }
                }
            } catch { }

            if (specificException == null) {
                specificException = new InvalidOperationException(exceptionMessage);
            }

            throw specificException;
        }
    }
}
