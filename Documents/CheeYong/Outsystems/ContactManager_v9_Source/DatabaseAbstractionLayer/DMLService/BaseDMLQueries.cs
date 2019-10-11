/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;

namespace OutSystems.HubEdition.Extensibility.Data.DMLService {
    public abstract class BaseDMLQueries : IDMLQueries {

        public BaseDMLQueries(IDMLService dmlService) {
            DMLService = dmlService;
        }

        /// <summary>
        /// This property represents the associated <see cref="IDMLService"/>.
        /// </summary>
        public IDMLService DMLService { get; private set; }

        /// <summary>
        /// Returns the DML expressions to be inserted in a query statement,
        /// to make it count the number of records returned by the original query.
        /// </summary>
        /// <returns>An <see cref="IDictionary{TKey,TValue}"/> with the DML expressions.</returns>
        public abstract IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForMaxRecords(string maxRecordsParam);

        /// <summary>
        /// Returns the DML expressions to be inserted in the <code>SELECT</code> statement of a query
        /// to limit the number of records returned.
        /// This implementation adds placeholders to wrap the query in a select count statement:
        /// <code>SELECT COUNT(1) FROM (Query)</code>.
        /// </summary>
        public virtual IDictionary<StatementPlaceholder, string> SQLPlaceholderValuesForCountQuery() {
            IDictionary<StatementPlaceholder, string> placeholders = new Dictionary<StatementPlaceholder, string>();
            placeholders.Add(StatementPlaceholder.BeforeStatement, "SELECT COUNT(1) FROM (");
            placeholders.Add(StatementPlaceholder.AfterStatement, ")");
            return placeholders;
        }

        /// <summary>
        /// Determines if the given join type is supported.
        /// </summary>
        /// <param name="joinType">The join type</param>
        /// <returns>True if the join type is supported, false otherwise</returns>
        public virtual bool IsSupported(QueryJoinType joinType) {
            return true;
        }
    }
}
