/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.RuntimeCommon;
using System;

namespace OutSystems.HubEdition.Extensibility.Data.ConfigurationService {

    /// <summary>
    /// Base implementation of the <see cref="IIntegrationDatabaseConfiguration"/> interface, that
    /// encapsulates a connection string and other configuration information required
    /// to connect to a database.
    /// Extend this class to create a specific database configuration.
    /// </summary>
    public abstract class BaseDatabaseConfiguration : IIntegrationDatabaseConfiguration {

        /// <summary>
        /// Gets the database provider. It provides information about the database,
        /// and access to its services.
        /// </summary>
        public abstract IDatabaseProvider DatabaseProvider { get; }

        /// <summary>
        /// Gets the connection string that allows connecting to a database.
        /// If the <see cref="ConnectionStringOverride"/> is defined, returns it,
        /// if an advanced connection string is defined returns the result of <see cref="AssembleAdvancedConnectionString"/>.
        /// Otherwise returns the result of <see cref="AssembleBasicConnectionString"/>.
        /// </summary>
        public virtual string ConnectionString { 
            get {
                if (!String.IsNullOrEmpty(ConnectionStringOverride)) {
                    return ConnectionStringOverride;
                }
                return AdvancedConfiguration.IsSet() ? AssembleAdvancedConnectionString() : AssembleBasicConnectionString();
            }
        }

        /// <summary>
        /// Returns a basic connection string with attributes such as username and password.
        /// </summary>
        /// <returns>A basic connection string.</returns>
        protected abstract string AssembleBasicConnectionString();

        /// <summary>
        /// Returns an advanced connection string with attributes that might be specific for a particular database.
        /// </summary>
        /// <returns>An advanced connection string.</returns>
        protected abstract string AssembleAdvancedConnectionString();

        /// <summary>
        /// This property represents the connection string that overrides specified configuration parameter values.
        /// </summary>
        [ConfigurationParameter]
        public virtual string ConnectionStringOverride { get; set; }

        /// <summary>
        /// This property represents the advanced configuration object.
        /// </summary>
        /// <value>The advanced configuration object.</value>
        public abstract AdvancedConfiguration AdvancedConfiguration { get; set; }

        /// <summary>
        /// This property represents the database identifier to be used in the configuration.
        /// </summary>
        public abstract string DatabaseIdentifier { get; }

        /// <summary>
        /// Concatenates the connection string with the supplied extra parameters.
        /// </summary>
        /// <param name="connectionStringWithoutExtras">Connection string without any extra parameters.</param>
        /// <param name="extras">Extra parameters to be added to the connection string.</param>
        /// <returns>A string representation of the new connection string after joining the extra parameters.</returns>
        public static string Join(string connectionStringWithoutExtras, string extras) {
            if (!connectionStringWithoutExtras.TrimEnd().EndsWith(";")) {
                connectionStringWithoutExtras += ";";
            }

            return connectionStringWithoutExtras + (extras ?? string.Empty);
        }

        /// <summary>
        /// Determines whether the current object is equal to the specified <see cref="T:System.Object" />.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> to compare with.</param>
        /// <returns>True if the instance is equal to the specified <see cref="T:System.Object" />, False otherwise.</returns>
        public override bool Equals(object obj) {
            var other = obj as BaseDatabaseConfiguration;

            return (
                (other != null) && EqualsBasedOnParts(
                    new object[] { ConnectionStringOverride, AdvancedConfiguration.AdvancedConnectionStringField, ConnectionString }, 
                    new object[] { other.ConnectionStringOverride, other.AdvancedConfiguration.AdvancedConnectionStringField, ConnectionString }
                )
            );
        }

        /// <summary>
        /// Returns the hash code for this object.
        /// </summary>
        /// <returns>The hash code for this object.</returns>
        public override int GetHashCode() {
            return GetHashCodeBasedOnParts(ConnectionStringOverride, AdvancedConfiguration.AdvancedConnectionStringField, ConnectionString);
        }
        
        /// <summary>
        /// Returns the hash code of a list of objects.
        /// </summary>
        /// <param name="parts">A list of objects.</param>
        /// <returns>An hash code.</returns>
        protected static int GetHashCodeBasedOnParts(params object[] parts) {
            var result = 0;

            for (int i = 0; i < parts.Length; i++) {
                if (parts[i] != null) {
                    result ^= parts[i].GetHashCode();
                }
            }

            return result;
        }

        /// <summary>
        /// Compares two lists of objects.
        /// </summary>
        /// <param name="parts1">A list of objects.</param>
        /// <param name="parts2">Another list of objects.</param>
        /// <returns>True if the two lists are equal, False otherwise.</returns>
        protected static bool EqualsBasedOnParts(object[] parts1, object[] parts2) {
            for (int i = 0; i < parts1.Length; i++) {
                if (!Object.Equals(parts1[i], parts2[i])) {
                    return false;
                }
            } 

            return true;
        }

        public abstract  IRuntimeDatabaseConfiguration RuntimeDatabaseConfiguration { get; }
    }
}
