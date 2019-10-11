/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {
    /// <summary>
    /// This interface defines methods that help build DML Identifiers for columns, tables, and others.
    /// </summary>
    public interface IDMLIdentifiers {

        /// <summary>
        /// Gets the associated DML service.
        /// </summary>
        /// <value>
        /// The DML service associated.
        /// </value>
        IDMLService DMLService { get; }

        /// <summary>
        /// Gets the maximum length of a simple (not compound) identifier. This value should be the minimum valid
        /// length for any kind of identifier (e.g. table name, parameter name)
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        int MaxLength { get; }
        
        /// <summary>
        /// Escapes a simple (not compound) identifier to prevent name clashing with reserved words.
        /// </summary>
        /// <param name="identifierName">Name that identifies a database object.</param>
        /// <returns>An escaped identifier.</returns>
        string EscapeIdentifier(string identifierName);

        /// <summary>
        /// Returns a name that can be used as a valid identifier (e.g. parameter name, constraint name).
        /// It should contain only valid characters and its length should not exceed the maximum defined in MaxLength.
        /// </summary>
        /// <param name="baseName">An identifier name.</param>
        /// <param name="truncateUsingRandomDigits">
        /// Indicates if the identifier should be truncated if its length exceeds the <see cref="MaxLength"/>. In this case, 
        /// random digits should be used as a suffix to prevent name clashing.
        /// </param>
        /// <returns>A string representing a valid identifier.</returns>
        string GetValidIdentifier(string baseName, bool truncateUsingRandomDigits);
    }
}
