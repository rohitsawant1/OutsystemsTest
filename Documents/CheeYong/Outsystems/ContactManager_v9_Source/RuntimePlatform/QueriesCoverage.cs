/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Xml;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform {

    public interface QueriesCoverageProvider {
        bool ShouldExecuteNonDefaultValues { get; }
        void ExecuteDefaultValues(HeContext heContext, out string queryPathName, out string queryType, out int numParameters, out bool executedOk, out string exceptionMessage);
        void ExecuteNonDefaultValues(HeContext heContext, out string queryPathName, out string queryType, out int numParameters, out bool executedOk, out string exceptionMessage);
    }

    public static class QueriesCoverage {
        private static IEnumerable<QueriesCoverageProvider> GetQueries(Type screenType) {
            foreach (Type type in screenType.Assembly.GetTypes()) {
                if (type != typeof(QueriesCoverageProvider) && typeof(QueriesCoverageProvider).IsAssignableFrom(type)) {
                    QueriesCoverageProvider cov = (QueriesCoverageProvider)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                    yield return cov;
                }
            }
        }

        /// <summary>
        /// Retrieves information about Queries
        /// </summary>
        /// <param name="heContext"> Context</param>
        /// <param name="screenType">The type of the screen.</param>
        /// <returns>A Xml Document with the information</returns>
        public static XmlDocument ExecAllQueriesGetXml(HeContext heContext, Type screenType) {
            XmlDocument xmldoc = new XmlDocument();
            string queryPathName;
            string queryType;
            int numParameters;
            bool executedOk;
            string exceptionMessage;
            int totalExecutionsOk = 0;
            int totalExecutionsNotOk = 0;
            int totalExecutions = 0;
            xmldoc = new XmlDocument();
            xmldoc.LoadXml("<QueriesCoverage/>");

            IEnumerable<QueriesCoverageProvider> queries = GetQueries(screenType);
            foreach (QueriesCoverageProvider cov in queries) {
                cov.ExecuteDefaultValues(heContext, out queryPathName, out queryType, out numParameters, out executedOk, out exceptionMessage);
                AddQryExecResult(xmldoc, queryPathName, queryType, numParameters, true, executedOk, exceptionMessage);
                if (cov.ShouldExecuteNonDefaultValues) {
                    cov.ExecuteNonDefaultValues(heContext, out queryPathName, out queryType, out numParameters, out executedOk, out exceptionMessage);
                    AddQryExecResult(xmldoc, queryPathName, queryType, numParameters, false, executedOk, exceptionMessage);
                }
            }

            XmlNodeList nodes = xmldoc.DocumentElement.SelectNodes(".//QueryExecution[@executedOk='True']");
            totalExecutionsOk = nodes.Count;
            nodes = xmldoc.DocumentElement.SelectNodes(".//QueryExecution[@executedOk!='True']");
            totalExecutionsNotOk = nodes.Count;
            totalExecutions = totalExecutionsOk + totalExecutionsNotOk;
            XmlAttribute attr = xmldoc.CreateAttribute("totalExecutions");
            attr.Value = totalExecutions.ToString();
            xmldoc.DocumentElement.Attributes.Append(attr);
            attr = xmldoc.CreateAttribute("totalExecutionsOk");
            attr.Value = totalExecutionsOk.ToString();
            xmldoc.DocumentElement.Attributes.Append(attr);
            attr = xmldoc.CreateAttribute("totalExecutionsNotOk");
            attr.Value = totalExecutionsNotOk.ToString();
            xmldoc.DocumentElement.Attributes.Append(attr);
            return xmldoc;
        }


        private static void AddQryExecResult(XmlDocument xmldoc, string queryPathName, string queryType, int numParameters, bool usedDefaultParamValues, bool executedOk, string exceptionMessage) {

            XmlElement qryExecElem = xmldoc.CreateElement("QueryExecution");

            XmlAttribute attr = xmldoc.CreateAttribute("queryPath");
            attr.Value = queryPathName;
            qryExecElem.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("queryType");
            attr.Value = queryType;
            qryExecElem.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("numParameters");
            attr.Value = numParameters.ToString();
            qryExecElem.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("usedDefaultParamValues");
            attr.Value = usedDefaultParamValues.ToString();
            qryExecElem.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("executedOk");
            attr.Value = executedOk.ToString();
            qryExecElem.Attributes.Append(attr);

            attr = xmldoc.CreateAttribute("exceptionMessage");
            attr.Value = exceptionMessage;
            qryExecElem.Attributes.Append(attr);

            xmldoc.DocumentElement.AppendChild(qryExecElem);
        }

    }
}