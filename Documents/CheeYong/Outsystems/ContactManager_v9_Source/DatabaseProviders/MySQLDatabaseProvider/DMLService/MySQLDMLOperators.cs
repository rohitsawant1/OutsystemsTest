/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.DMLService {
    internal class MySQLDMLOperators : BaseDMLOperators {

        internal MySQLDMLOperators(IDMLService dmlService) : base(dmlService) { }

        //TODO dvn: eliminate need for a concatenate operator
        public override string Concatenate(string v1, string v2) {
            return "CONCAT(" + v1 + "," + v2 + ")";
        }

    }
}
