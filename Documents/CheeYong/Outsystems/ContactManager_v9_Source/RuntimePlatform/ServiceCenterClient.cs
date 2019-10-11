using System.IO;
using System.Net;

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by wsdl, Version=1.1.4322.2032.
// 
namespace OutSystems.HubEdition.RuntimePlatform {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "IntegratedDebuggerSoap", Namespace = "http://ServiceCenter/IntegratedDebugger/")]
    public class IntegratedDebugger : System.Web.Services.Protocols.SoapHttpClientProtocol {

        /// <remarks/>
        public IntegratedDebugger(String url) {
            this.Url = url;
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ServiceCenter/IntegratedDebugger/CheckPermission", RequestNamespace = "http://www.outsystems.com", ResponseNamespace = "http://www.outsystems.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("ok")]
        public bool CheckPermission(string username, string password, string espaceGUID) {
            object[] results = this.Invoke("CheckPermission", new object[] {
                        username,
                        password,
                        espaceGUID});
            return ((bool)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCheckPermission(string username, string password, string espaceGUID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckPermission", new object[] {
                        username,
                        password,
                        espaceGUID}, callback, asyncState);
        }

        /// <remarks/>
        public bool EndCheckPermission(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
}
