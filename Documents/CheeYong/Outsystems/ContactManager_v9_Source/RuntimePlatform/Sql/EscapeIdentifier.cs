/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Text.RegularExpressions;

namespace OutSystems.HubEdition.RuntimePlatform.Sql {
    public class EscapeIdentifier : SimpleSQLParser {

        private MatchEvaluator meReplaceAttributeName;

        public EscapeIdentifier(MatchEvaluator meReplaceAttributeName) {
            this.meReplaceAttributeName = meReplaceAttributeName;
        }

        private static Regex AttributesRegex = new Regex(@"(\[\w+\])", RegexOptions.CultureInvariant | RegexOptions.Compiled);

        protected override string ProcessSQLSpan(string sqlSpan, bool allowCommentHints) {
            return AttributesRegex.Replace(sqlSpan, meReplaceAttributeName);
        }
    }
}
