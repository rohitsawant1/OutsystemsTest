/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using OutSystems.HubEdition.Extensibility.Data.DMLService;
using OutSystems.HubEdition.Extensibility.Data.DMLService.DMLPlaceholders;

namespace OutSystems.HubEdition.DatabaseProvider.iDB2.DMLService {
    public class iDB2DMLQueries : BaseDMLQueries {

        internal iDB2DMLQueries(IDMLService dmlService) : base(dmlService) { }

        public override IDictionary<StatementPlaceholder, string> SQLPlaceholderValuesForCountQuery() {
            IDictionary<StatementPlaceholder, string> placeholders = new Dictionary<StatementPlaceholder, string>();
            placeholders.Add(StatementPlaceholder.BeforeStatement, "SELECT COUNT(1) FROM (");
            placeholders.Add(StatementPlaceholder.AfterStatement, ") as result");
            return placeholders;
        }

        public override IDictionary<SelectPlaceholder, string> SQLPlaceholderValuesForMaxRecords(string maxRecordsParam) {
            Dictionary<SelectPlaceholder, string> maxRecordsStatement = new Dictionary<SelectPlaceholder, string>();
            maxRecordsStatement.Add(SelectPlaceholder.AfterStatement, " FETCH FIRST " + maxRecordsParam + " ROWS ONLY ");
            return maxRecordsStatement;
        }

    }
}
