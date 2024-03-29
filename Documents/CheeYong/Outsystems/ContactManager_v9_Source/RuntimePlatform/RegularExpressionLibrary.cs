/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OutSystems.RuntimeCommon;

namespace OutSystems.HubEdition.RuntimePlatform {

    // Abstract the several implementations of regular expressions (.NET, java.util.regex and gnu.regex)
    // This allows us to use one implementation or the other, taking advantage of the most performant
    // implementation for each scenario
    public abstract class AbstractRegularExpression {

        public abstract Match Match(string input);
        public abstract bool IsMatch(string input);
        public abstract MatchCollection Matches(string input);

        public abstract string Replace(string input, string replacement);
        public abstract string Replace(string input, MatchEvaluator evaluator);

    }

    public sealed class DotNetRegularExpression : AbstractRegularExpression {

        private readonly Regex regex;

        public DotNetRegularExpression(Regex regex) {
            this.regex = regex;
        }

        public override Match Match(string input) {
            return regex.Match(input);
        }

        public override bool IsMatch(string input) {
            return regex.IsMatch(input);
        }

        public override MatchCollection Matches(string input) {
            return regex.Matches(input);
        }

        public override string Replace(string input, MatchEvaluator evaluator) {
            return regex.Replace(input, evaluator);
        }

        public override string Replace(string input, string replacement) {
            return regex.Replace(input, replacement);
        }
    }

}
