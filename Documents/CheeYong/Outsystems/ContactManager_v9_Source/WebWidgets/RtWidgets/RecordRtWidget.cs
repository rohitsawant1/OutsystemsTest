/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Xml;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Web;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.WebWidgets {
    public class RecordRtWidget : RtWidget, IRecordRtWidget {
        public object record;

        public object Record {
            get { return this.record; }
            set { this.record = value; }
        }

        public override void InnerToXml(XmlElement widgetElem, int detailLevel) {
            if (Record != null)
                VarValue.InvokeToXml(Record, this, widgetElem, "Record", detailLevel - 1);
        }

        public override void InnerEvaluateField(VarValue variable, string field) {
            if (field == "record")
                variable.Value = Record;
        }
    }
}
