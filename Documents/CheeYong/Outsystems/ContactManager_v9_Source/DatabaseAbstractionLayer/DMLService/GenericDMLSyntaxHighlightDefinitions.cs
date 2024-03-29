/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {

    /// <summary>
    /// Defines a set of fragments (e.g. keywords, operators) of Generic (ANSI) SQL
    /// that can be used to provide syntax highlighting in SQL statements. This is based on the book
    /// "SQL in a nutshell - A Desktop Quick Reference", from Kevin Kline and Daniel Kline (2001)
    /// </summary>
    public partial class GenericDMLSyntaxHighlightDefinitions : IDMLSyntaxHighlightDefinitions {

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDMLSyntaxHighlightDefinitions"/> class.
        /// </summary>
        /// <param name="dmlService">The DML service.</param>
        public GenericDMLSyntaxHighlightDefinitions(IDMLService dmlService) {
            DMLService = dmlService;
        }

        /// <summary>
        /// This property represents the associated <see cref="IDMLService" />.
        /// </summary>
        /// <value>
        /// The DML service associated.
        /// </value>
        public IDMLService DMLService { get; private set; }

        /// <summary>
        /// Returns a set of reserved keywords (e.g. SELECT, FROM, JOIN)
        /// This implementation returns the Ansi SQL 99 keywords
        /// </summary>
        public virtual IEnumerable<string> Keywords { get { return KEYWORDS; } }

        /// <summary>
        /// Returns a set of function names (e.g. MAX, ROUND, UPPER))
        /// This implementation returns the Ansi SQL 99 functions
        /// </summary>
        public virtual IEnumerable<string> Functions { get { return FUNCTIONS; } }

        /// <summary>
        /// Returns a set of operators (e.g. +, LIKE, EXISTS)
        /// This implementation returns the Ansi SQL 99 operators
        /// </summary>
        public virtual IEnumerable<string> Operators { get { return OPERATORS; } }

        /// <summary>
        /// Returns a set of data types (e.g. INTEGER, CHAR, NVARCHAR)
        /// This implementation returns the Ansi SQL 99 data types
        /// </summary>
        public virtual IEnumerable<string> DataTypes { get { return DATA_TYPES; } }
    }
}
