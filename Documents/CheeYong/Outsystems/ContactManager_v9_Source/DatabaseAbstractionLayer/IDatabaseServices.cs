/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.HubEdition.Extensibility.Data.ConfigurationService;
using OutSystems.HubEdition.Extensibility.Data.DatabaseObjects;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.ExecutionService;
using OutSystems.HubEdition.Extensibility.Data.IntrospectionService;
using OutSystems.HubEdition.Extensibility.Data.TransactionService;

namespace OutSystems.HubEdition.Extensibility.Data {
    
    /// <summary>
    /// Represents the set of services that needs to be implemented to add support for a new database.
    /// </summary>
    public interface IDatabaseServices {

        /// <summary>
        /// Gets the <see cref="IRuntimeDatabaseConfiguration" /> object associated with a database.
        /// It encapsulates the necessary information to connect to a database instance.
        /// </summary>
        /// <value>
        /// The database configuration.
        /// </value>
        IRuntimeDatabaseConfiguration DatabaseConfiguration { get; }

        /// <summary>
        /// Returns a factory capable of creating database information objects from qualified names. If required, this object might access the database.
        /// </summary>
        /// <value>
        /// The object factory.
        /// </value>
        IDatabaseObjectFactory ObjectFactory { get; }

        /// <summary>
        /// Gets the <see cref="ITransactionService" /> object associated with a database.
        /// Represents a specific database connection or transaction.
        /// </summary>
        /// <value>
        /// The transaction service.
        /// </value>
        ITransactionService TransactionService { get; }

        /// <summary>
        /// Gets the <see cref="IExecutionService" /> associated with the database.
        /// Represents an execution context to run SQL commands on a database.
        /// </summary>
        /// <value>
        /// The execution service.
        /// </value>
        IExecutionService ExecutionService { get; }

        /// <summary>
        /// Gets the <see cref="IDMLService" /> object associated with the database.
        /// Represents a service that generates SQL statements.
        /// </summary>
        /// <value>
        /// The DML service.
        /// </value>
        IDMLService DMLService { get; }

        /// <summary>
        /// Gets the <see href="IIntrospectionService" /> object associated with the database.
        /// Represents a service that provides information about meta-data of the database.
        /// </summary>
        /// <value>
        /// The introspection service.
        /// </value>
        IIntrospectionService IntrospectionService { get; }
    }
}