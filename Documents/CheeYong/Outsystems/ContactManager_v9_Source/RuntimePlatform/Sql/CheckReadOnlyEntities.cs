/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using System.Linq;

namespace OutSystems.HubEdition.RuntimePlatform.Sql {

    public class CheckReadOnlyEntities : SimpleSQLParser {
        private Func<string, bool> isReadOnly;

        public CheckReadOnlyEntities(Func<string, bool> checkReadOnly) {
            this.isReadOnly = checkReadOnly;
        }


        private static Regex SQLCommentsRegex = new Regex(@"(/\*.*?\*/)|(--.*?$)|('([^']|'')*')", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline);
        private static Regex SQLCommentWithoutHintsRegex = new Regex(@"(/\*[^\+].*?\*/)|(--[^\+].*?$)|('([^']|'')*')", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.Singleline);
        private static Regex SQLSpanRegex = new Regex("(?:insert\\s+into|delete\\s+from|delete|update|truncate\\s+table)\\s+\\{([^}]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        protected override string ProcessSQLSpan(string sqlSpan, bool allowCommentHints) {
            /* Captures: "insert into {Entity}", 
             *           "delete from {Entity}", 
             *           "delete {Entity}",
             *           "truncate table {Entity}",
             *           and "update {Entity}" patterns
             * Stores:   entity name into group 1
             */
            // Note: previous to #1146855 fix, this was not removing the comments before checking for Referenced Entities
            string result = sqlSpan;
            if (allowCommentHints) {
                result = SQLCommentWithoutHintsRegex.Replace(sqlSpan, " ");
            } else {
                result = SQLCommentsRegex.Replace(sqlSpan, " ");
            }
            MatchCollection matches = SQLSpanRegex.Matches(result);
            foreach (Match match in matches) {
                if (isReadOnly(match.Groups[1].Value)) {
                    throw new DataBaseException("Referenced Entity '" + match.Groups[1].Value + "' is read-only. Database operations that modify records are not allowed.");
                }
            }
            return null;
        }
    }
}
