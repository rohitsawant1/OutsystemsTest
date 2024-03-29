/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;

namespace OutSystems.HubEdition.RuntimePlatform.Callbacks.Invoke {
    [Serializable]
    internal class WebServiceCallbackInvoke : AbstractStringCallbackInvoke {
        [NonSerialized]
        private string _url;

        private string _provider;
        private string _service;
        private string _method;        
        
        public WebServiceCallbackInvoke(string url, string serviceName, string providerName, string methodName) {
            _url = url;
            _service = serviceName;
            _provider = providerName;
            _method = methodName;            
        }

        public override string ProviderName {
            get { return _provider; }
        }

        protected override bool Equals(AbstractStringCallbackInvoke obj) {
            return obj is WebServiceCallbackInvoke && Equals((WebServiceCallbackInvoke) obj);
        }

        private bool Equals(WebServiceCallbackInvoke obj) {
            return _provider.Equals(obj._provider) &&
                _service.Equals(obj._service) &&
                _method.Equals(obj._method);
        }

        public override int GetHashCode() {
            return _provider.GetHashCode() ^
                _service.GetHashCode() ^
                _method.GetHashCode();
        }

        public override string InvokeInner(string locale, AppInfo app, SessionInfo session, AbstractCallback.EventListener listener) {
            return InvokeWebServiceCallback(
                GetESpaceId(app),
                GetTenantId(app),
                GetUserId(session),
                locale,
                "callbackName=" + GetCallbackEvent(listener).ToString());
        }

        private string InvokeWebServiceCallback(int eSpaceId, int tenantId, int userId, string locale, string data) {
            // prepare the web page we will be asking for
            var deploymentZoneSettings = Internal.DeploymentZoneResolution.ByModuleName(this._provider);
            // #RRCT-1871 - this code does not support callbacks that point to an external server, since it is always replacing
            // the host name by the local machine
            var zoneUrl = Internal.ModuleUrlTranformations.ReplaceHostAndScheme(new Uri(_url), deploymentZoneSettings.Address, deploymentZoneSettings.EnableHttps);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(zoneUrl);

            // Soap action : "http://Provider/WebService1/GetHtml"
            request.Headers.Add("SOAPAction", $"http://{_provider}/{_service}/{_method}");

            request.ContentType = "text/xml; charset=utf-8";
            //request.Expect = "100-continue";
            //request.Connection = "Keep-Alive";
            request.KeepAlive = true;
            request.Method = "POST";
            XmlDocument argsXml = new XmlDocument();
            XmlNode rootNode = argsXml.CreateElement("root");
            argsXml.AppendChild(rootNode);

            XmlNode nd = argsXml.CreateElement("eSpaceId");
            nd.InnerText = "" + eSpaceId;
            rootNode.AppendChild(nd);
            nd = argsXml.CreateElement("userId");
            nd.InnerText = "" + userId;
            rootNode.AppendChild(nd);
            nd = argsXml.CreateElement("data");
            nd.InnerText = data;
            rootNode.AppendChild(nd);
            if (locale != null) {
                nd = argsXml.CreateElement("locale");
                nd.InnerText = locale;
                rootNode.AppendChild(nd);
            }

            string req = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><soap:Body><" + _method + " xmlns=\"http://www.outsystems.com\" >" + rootNode.InnerXml + " </" + _method + "></soap:Body></soap:Envelope>";
            setRequestBody(request, req);

            // execute the request
            using (var response = request.GetResponse()) {            
                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
                string content = readUTF8Stream(resStream);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);

                XmlElement root = doc.DocumentElement;
                XmlNodeList ndLst;

                ndLst = root.GetElementsByTagName(_method + "Response", "http://www.outsystems.com");
                return System.Web.HttpUtility.HtmlDecode(ndLst[0].FirstChild.InnerXml);
            }
        }


        private static void setRequestBody(HttpWebRequest request, string req) {
            // Store the data in a byte array.
            byte[] ByteQuery = System.Text.Encoding.UTF8.GetBytes(req); // ASCII.GetBytes(req);
            request.ContentLength = ByteQuery.Length;
            Stream QueryStream = request.GetRequestStream();
            // write the data to be posted to the Request Stream
            QueryStream.Write(ByteQuery, 0, ByteQuery.Length);
            QueryStream.Close();
        }

        private static string readUTF8Stream(Stream resStream) {
            // used to build entire input
            using (StreamReader reader = new StreamReader(resStream, Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }
    }
}