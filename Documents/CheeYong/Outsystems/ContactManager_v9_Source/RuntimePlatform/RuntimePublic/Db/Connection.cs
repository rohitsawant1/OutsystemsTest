/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using OutSystems.RuntimeCommon;

namespace OutSystems.RuntimePublic.Db {
    /// <summary>
    /// Represents a connection to a database.
    /// </summary>
    public sealed class Connection : IDisposable {
        private OutSystems.Internal.Db.DatabaseConnection connection;

        internal Connection(OutSystems.Internal.Db.DatabaseConnection connection) {
            if (connection == null) {
                throw new ArgumentNullException("Connection cannot be initialized with null.");
            }
            this.connection = connection;
        }

        /// <summary>
        /// Returns the native connection object used by the stack in which the application is running.
        /// It allows to reuse existing code that receives a native connection object as parameter.
        /// </summary>
        /// <returns>The native connection object.</returns>
        public IDbConnection GetDriverConnection() {
            return connection.DriverConnection;
        }

        /// <summary>
        /// Creates a <see cref="CommittableTransaction"/> with the transaction isolation level set
        /// to read uncommitted.
        /// </summary>
        /// <returns>A <see cref="CommittableTransaction"/>.</returns>
        [Obsolete("Connection.BeginReadUncommittedTransaction has been deprecated because OutSystems only provides connections associated to a transaction and multiple transactions running on a single connection are not supported. This method will be removed in OutSystems 12")]
        public CommittableTransaction BeginReadUncommittedTransaction() {
            try {
                return new CommittableTransaction(connection.BeginReadUncommittedTransaction());
            } catch (ArgumentNullException) {
                throw new InvalidOperationException("A new transaction cannot be created from this connection.");
            }
        }

        /// <summary>
        /// Creates a <see cref="CommittableTransaction"/> with the transaction isolation level set
        /// to read committed.
        /// </summary>
        /// <returns>A <see cref="CommittableTransaction"/>.</returns>
        [Obsolete("Connection.BeginTransaction has been deprecated because OutSystems only provides connections associated to a transaction and multiple transactions running on a single connection are not supported. This method will be removed in OutSystems 12")]
        public CommittableTransaction BeginTransaction() {
            try {
                return new CommittableTransaction(connection.BeginTransaction());
            } catch (ArgumentNullException) {
                throw new InvalidOperationException("A new transaction cannot be created from this connection.");
            }
        }

        /// <summary>
        /// Creates an empty command that does not have an associated transaction.
        /// </summary>
        /// <returns>A <see cref="Command"/> with no SQL associated.</returns>
        public Command CreateCommand() {
            try {
                return new Command(connection.CreateCommand(""));
            } catch (ArgumentNullException) {
                throw new InvalidOperationException("A command cannot be created from this connection.");
            }
        }

        /// <summary>
        /// Creates a command that does not have an associated transaction.
        /// </summary>
        /// <param name="sql">The SQL Statement to be executed</param>
        /// <returns>A <see cref="Command"/> with SQL associated.</returns>
        public Command CreateCommand(string sql) {
            try {
                return new Command(connection.CreateCommand(sql));
            } catch (ArgumentNullException) {
                throw new InvalidOperationException("A command cannot be created from this connection.");
            }
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void Close() {
            connection.Close();
        }

        /// <summary>
        /// Checks if the connection is closed.
        /// </summary>
        /// <returns>True if the connection is closed, False otherwise.</returns>
        public bool IsClosed() {
            return connection.IsClosed();
        }

        #region IDisposable Members

        /// <summary>
        /// Closes the connection and frees the resources used by this object.
        /// </summary>
        public void Dispose() {
            connection.Dispose();
        }

        #endregion
    }
}
