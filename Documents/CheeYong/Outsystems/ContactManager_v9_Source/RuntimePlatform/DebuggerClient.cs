//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=1.1.4322.2032.
// 

using System;
using System.Reflection;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform {
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DebuggerSoap", Namespace="http://tempuri.org/")]
    public class _Debugger : System.Web.Services.Protocols.SoapHttpClientProtocol {
        /// <remarks/>
        public _Debugger(string url) {
            this.Url = url;
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetIsRunning", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool GetIsRunning() {
            object[] results = this.Invoke("GetIsRunning", new object[0]);
            return ((bool)(results[0]));
        }
    
        /// <remarks/>
        public System.IAsyncResult BeginGetIsRunning(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetIsRunning", new object[0], callback, asyncState);
        }
    
        /// <remarks/>
        public bool EndGetIsRunning(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StartDebugSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string StartDebugSession(string eSpaceUID, string userName, string password) {
            object[] results = this.Invoke("StartDebugSession", new object[] { eSpaceUID, userName, GetEncryptedPassword(password) });
            return (string) results[0];
        } 
        
        /// <remarks/>
        public System.IAsyncResult BeginStartDebugSession(string eSpaceUID, string userName, string password, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StartDebugSession", new object[] { eSpaceUID, userName, GetEncryptedPassword(password) }, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndStartDebugSession(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StopDebugSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void StopDebugSession(string debugSessionToken) {
            this.Invoke("StopDebugSession", new object[] {
                        debugSessionToken});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStopDebugSession(string debugSessionToken, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StopDebugSession", new object[] {
                        debugSessionToken}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndStopDebugSession(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/OnBeforeDeploy", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void OnBeforeDeploy(string debugSessionToken) {
            this.Invoke("OnBeforeDeploy", new object[] {
                        debugSessionToken});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginOnBeforeDeploy(string debugSessionToken, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("OnBeforeDeploy", new object[] {
                        debugSessionToken}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndOnBeforeDeploy(System.IAsyncResult asyncResult) {
            this.EndInvoke(asyncResult);
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetHandleExceptionMode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetHandleExceptionMode(string debugSessionToken, bool breakOnAllErrors) {
            object[] results = this.Invoke("SetHandleExceptionMode", new object[] {
                        debugSessionToken,
                        breakOnAllErrors});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSetHandleExceptionMode(string debugSessionToken, string mode, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SetHandleExceptionMode", new object[] {
                        debugSessionToken,
                        mode}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSetHandleExceptionMode(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddBreakpoints", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddBreakpoints(string debugSessionToken, string breakpointsIds) {
            object[] results = this.Invoke("AddBreakpoints", new object[] {
                        debugSessionToken,
                        breakpointsIds});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddBreakpoints(string debugSessionToken, string breakpointsIds, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("AddBreakpoints", new object[] {
                        debugSessionToken,
                        breakpointsIds}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndAddBreakpoints(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RemoveBreakpoint", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RemoveBreakpoint(string debugSessionToken, string breakpointId) {
            object[] results = this.Invoke("RemoveBreakpoint", new object[] {
                        debugSessionToken,
                        breakpointId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRemoveBreakpoint(string debugSessionToken, string breakpointId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RemoveBreakpoint", new object[] {
                        debugSessionToken,
                        breakpointId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndRemoveBreakpoint(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClearBreakpoints", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ClearBreakpoints(string debugSessionToken) {
            object[] results = this.Invoke("ClearBreakpoints", new object[] {
                        debugSessionToken});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClearBreakpoints(string debugSessionToken, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClearBreakpoints", new object[] {
                        debugSessionToken}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndClearBreakpoints(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SuspendAllThreads", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SuspendAllThreads(string debugSessionToken) {
            object[] results = this.Invoke("SuspendAllThreads", new object[] {
                        debugSessionToken});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSuspendAllThreads(string debugSessionToken, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SuspendAllThreads", new object[] {
                        debugSessionToken}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSuspendAllThreads(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ContinueThread", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ContinueThread(string debugSessionToken, string threadId) {
            object[] results = this.Invoke("ContinueThread", new object[] {
                        debugSessionToken,
                        threadId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginContinueThread(string debugSessionToken, string threadId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ContinueThread", new object[] {
                        debugSessionToken,
                        threadId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndContinueThread(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Stop", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Stop(string debugSessionToken, string threadId) {
            object[] results = this.Invoke("Stop", new object[] {
                        debugSessionToken,
                        threadId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStop(string debugSessionToken, string threadId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Stop", new object[] {
                        debugSessionToken,
                        threadId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndStop(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RunTo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RunTo(string debugSessionToken, string threadId, string breakpointId) {
            object[] results = this.Invoke("RunTo", new object[] {
                        debugSessionToken,
                        threadId,
                        breakpointId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRunTo(string debugSessionToken, string threadId, string breakpointId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RunTo", new object[] {
                        debugSessionToken,
                        threadId,
                        breakpointId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndRunTo(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StepInto", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string StepInto(string debugSessionToken, string threadId) {
            object[] results = this.Invoke("StepInto", new object[] {
                        debugSessionToken,
                        threadId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStepInto(string debugSessionToken, string threadId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StepInto", new object[] {
                        debugSessionToken,
                        threadId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndStepInto(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StepOver", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string StepOver(string debugSessionToken, string threadId) {
            object[] results = this.Invoke("StepOver", new object[] {
                        debugSessionToken,
                        threadId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStepOver(string debugSessionToken, string threadId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StepOver", new object[] {
                        debugSessionToken,
                        threadId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndStepOver(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/StepOut", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string StepOut(string debugSessionToken, string threadId) {
            object[] results = this.Invoke("StepOut", new object[] {
                        debugSessionToken,
                        threadId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginStepOut(string debugSessionToken, string threadId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("StepOut", new object[] {
                        debugSessionToken,
                        threadId}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndStepOut(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDebugEvent", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetDebugEvent(string debugSessionToken, long lastEventReceived) {
            object[] results = this.Invoke("GetDebugEvent", new object[] {
                        debugSessionToken,
                        lastEventReceived});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDebugEvent(string debugSessionToken, long lastEventReceived, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDebugEvent", new object[] {
                        debugSessionToken,
                        lastEventReceived}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetDebugEvent(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Evaluate", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Evaluate(string debugSessionToken, string threadId, string vars) {
            object[] results = this.Invoke("Evaluate", new object[] {
                        debugSessionToken,
                        threadId,
                        vars});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginEvaluate(string debugSessionToken, string threadId, string vars, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Evaluate", new object[] {
                        debugSessionToken,
                        threadId,
                        vars}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndEvaluate(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        private static string GetEncryptedPassword(string password) {
            // Since we will be communicating with the same server it is safe so always use the latest version encryption
            return EncryptPasswordForWebServiceRequest.Encrypt(password, EncryptPasswordForWebServiceRequest.EMPTY_VERSION);
        }
    }
}
