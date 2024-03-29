/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using System.Data;
using System.Data.Common;

namespace OutSystems.HubEdition.DatabaseProvider.Oracle.TransactionService {
    public class TransactionManager : GenericTransactionManager {
        public TransactionManager(ITransactionService transactionService)
            : base(transactionService) {}
        
        protected override void EndTransaction(TransactionInfo transInfo, bool commit, bool toFreeResources) {
            //Keep the request transaction open if possible
            if (!toFreeResources && RequestTransactionInfo != null && RequestTransactionInfo.Equals(transInfo)) {
                IDbCommand cmd = ExecutionService.CreateCommand(transInfo.Transaction, commit ? "COMMIT" : "ROLLBACK");
                try {
                    ExecutionService.ExecuteNonQuery(cmd);
                } catch (DbException e) {
                    ExecutionService.OnExecuteException(e, cmd, null, transInfo.Connection, transInfo.Transaction, this);
                    throw;
                }
            } else {
                base.EndTransaction(transInfo, commit, toFreeResources);
            }
        }
    }
}
