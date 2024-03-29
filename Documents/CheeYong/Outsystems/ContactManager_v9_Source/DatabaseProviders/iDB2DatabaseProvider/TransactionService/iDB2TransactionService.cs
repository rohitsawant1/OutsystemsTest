/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Data;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.RuntimeCommon.ObfuscationProperties;
using IBM.Data.DB2.iSeries;
using OutSystems.HubEdition.DatabaseProvider.iDB2.ConfigurationService;

namespace OutSystems.HubEdition.DatabaseProvider.iDB2.TransactionService
{
    [DoNotObfuscate]
    public class iDB2TransactionService : BaseTransactionService {

        public iDB2TransactionService(IDatabaseServices databaseServices) : base(databaseServices) { }
        
        protected override IsolationLevel IsolationLevel { get { return IsolationLevel.ReadCommitted; } }

        protected override IDbConnection GetConnectionFromDriver() {
            IDbConnection conn = IBM.Data.DB2.iSeries.iDB2Factory.Instance.CreateConnection();
            conn.ConnectionString = DatabaseServices.DatabaseConfiguration.ConnectionString;
           
            return conn;
        }

        public override ITransactionManager CreateTransactionManager() {
            return new GenericTransactionManager(this);
        }

        public override IDbTransaction CreateTransaction(IDbConnection conn) {
            if (((iDB2RuntimeDatabaseConfiguration)base.DatabaseServices.DatabaseConfiguration).AutoCommit) {
                return conn.BeginTransaction(System.Data.IsolationLevel.Chaos);
            } else {
                return base.CreateTransaction(conn);
            }
        }

        public override void CloseTransaction(IDbTransaction tran) {
            base.CloseTransaction(tran);
        }

        protected override void ReleaseAllPooledConnections() {
            iDB2ProviderSettings.CleanupPooledConnections();
        }
        
        public override bool NeedsSeparateAdminConnection { get { return false; } }

    }
}
