/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Data;
using OutSystems.HubEdition.Extensibility.Data;
using OutSystems.RuntimeCommon;

namespace OutSystems.Internal.Db {

    // TODO JMR REFACTOR: To be moved to another project
    public class DatabaseConnection : IDisposable {

        public IDbConnection DriverConnection { get; private set; }

        public IDatabaseServices DatabaseServices { get; private set; }

        public IExecutionBehaviours DatabaseBehaviours { get; private set; }

        // TODO JMR REFACTOR: Review public/internal
        public DatabaseConnection(IDatabaseServices databaseServices, IDbConnection connection, IExecutionBehaviours behaviours) {
            if (databaseServices == null || connection == null) {
                throw new ArgumentNullException();
            }
            this.DatabaseServices = databaseServices;
            this.DriverConnection = connection;
            this.DatabaseBehaviours = behaviours;
        }

        public Transaction BeginTransaction() {
            return new Transaction(DatabaseServices, DriverConnection.BeginTransaction(), DatabaseBehaviours);
        }

        public Transaction BeginReadUncommittedTransaction() {
            return new Transaction(DatabaseServices, DriverConnection.BeginTransaction(IsolationLevel.ReadUncommitted), DatabaseBehaviours);
        }

        public new Type GetType() {
            return DriverConnection.GetType();
        }

        public string GetDatabase() {
            return DriverConnection.Database;
        }

        public void ChangeDatabase(string databaseName) {
            DriverConnection.ChangeDatabase(databaseName);
        }

        public Command CreateCommand() {
            return CreateCommand("");
        }

        public Command CreateCommand(string sql) {
            return new Command(DatabaseServices.ExecutionService, DatabaseServices.ExecutionService.CreateCommand(DriverConnection, sql), DatabaseBehaviours);
        }

        public bool IsClosed() {
            return DatabaseServices.TransactionService.IsClosed(DriverConnection);
        }

        public void Close() {
            DriverConnection.Close();
        }

        public void Dispose() {
            //DriverConnection.Close();
            DriverConnection.Dispose();
        }
    }

    public static class DatabaseConnectionExtensions {

        public static void SafeClose(this DatabaseConnection conn) {
            if (conn != null) {
                conn.Close();
            }
        }

    }
}
