/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.DatabaseProvider.Oracle.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.Platform.DMLService;

namespace OutSystems.HubEdition.DatabaseProvider.Oracle.Platform.DMLService {
    internal class PlatformDMLFunctions : DMLFunctions, IPlatformDMLFunctions {

        internal PlatformDMLFunctions(IDMLService dmlService) : base(dmlService) { }

        public string CheckRole(string RoleId, string UserId) {
            return string.Format("CheckRole({0}, {1})", RoleId, UserId);
        }
    }
}
