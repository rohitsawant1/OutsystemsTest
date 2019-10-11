/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.DMLService;

namespace OutSystems.HubEdition.Extensibility.Data.Platform.DMLService {

    /// <summary>
    /// Generates the SQL functions required by the applications to perform simple queries.
    /// </summary>
    public interface IPlatformDMLFunctions : IDMLFunctions {
        
        /// <summary>
        /// Provides a DML expression that returns true when the given user has the specific role.
        /// </summary>
        /// <param name="RoleId">DML expression that evaluates to an integer role identifier</param>
        /// <param name="UserId">DML expression that evaluates to an integer user identifier</param>
        /// <returns>DML Expression of type Boolean</returns>
        string CheckRole(string RoleId, string UserId);

    }
}
