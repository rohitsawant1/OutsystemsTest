/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Data;
using OutSystems.HubEdition.DatabaseProvider.MySQL.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.Platform;
using OutSystems.HubEdition.Extensibility.Data.Platform.ExecutionService;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.DatabaseProvider.MySQL.Platform.ExecutionService {

    public class MySQLPlatformExecutionService : MySQLExecutionService, IPlatformExecutionService {
        IPlatformDatabaseServices IPlatformExecutionService.DatabaseServices { get { return (IPlatformDatabaseServices) base.DatabaseServices; } }
        
        public MySQLPlatformExecutionService(IPlatformDatabaseServices databaseServices) : base(databaseServices) {}

        /// <summary>
        /// Executes a stored procedure using a command.
        /// This implementation changes the command type to <c>StoredProcedure</c> and calls
        /// <see cref="IExecutionService.ExecuteReader"/>.
        /// </summary>
        /// <param name="cmd">The stored procedure command.</param>
        /// <param name="readerParamName">Name of the output parameter, without the prefix, to associate a reader with, if the procedure returns one (e.g. a cursor)</param>
        /// <returns>A reader with the results of the stored procedure.</returns>
        public virtual IDataReader ExecuteStoredProcedureWithResultSet(IDbCommand cmd, string readerParamName) {
            cmd.CommandType = CommandType.StoredProcedure;
            return ExecuteReader(cmd);
        }
    }
}
