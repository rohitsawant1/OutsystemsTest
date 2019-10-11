/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService;
using System.Globalization;

namespace OutSystems.HubEdition.DatabaseProvider.iDB2.DMLService {

    public class iDB2DMLDefaultValues : BaseDMLDefaultValues {

        internal iDB2DMLDefaultValues(IDMLService dmlService) : base(dmlService) { }

        public override string Null
        {
            get
            {
                return "cast(NULL as SMALLINT)";
            }
        }

        public override string BinaryData
        {
            get
            {
                return this.Null;
            }
        }
    }
}
