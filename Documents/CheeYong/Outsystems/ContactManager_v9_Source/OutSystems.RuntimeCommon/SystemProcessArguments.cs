/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Linq;
using System.Collections.Generic;

namespace OutSystems.RuntimeCommon {

	public class SystemProcessArguments {

        protected readonly List<string> arguments;

        public SystemProcessArguments(params string[] initialArgs) {
            arguments = new List<string>(initialArgs);
        }

        public SystemProcessArguments Append(string arg) {
            return AppendIf(true, arg);
        }

        public SystemProcessArguments AppendIf(bool condition, string arg) {
            if (condition) {
                arguments.Add(arg);
            }
            return this;
        }

        public SystemProcessArguments Append(string argName, string argValue) {
            return AppendIf(true, argName, argValue);
        }

        public SystemProcessArguments AppendIf(bool condition, string argName, string argValue) {
            if (condition) {
                arguments.Add(argName);
                arguments.Add(argValue);
            }
            return this;
        }

        public SystemProcessArguments Prepend(string arg) {
            return PrependIf(true, arg);
        }

        public SystemProcessArguments PrependIf(bool condition, string arg) {
            if (condition) {
                arguments.Insert(0, arg);
            }
            return this;
        }

        public SystemProcessArguments Prepend(string argName, string argValue) {
            return PrependIf(true, argName, argValue);
        }

        public SystemProcessArguments PrependIf(bool condition, string argName, string argValue) {
            if (condition) {
                arguments.Insert(0, argName);
                arguments.Insert(1, argValue);
            }
            return this;
        }

        public string[] ToArray() {
            return arguments.ToArray();
        }

        public override string ToString() {
            return ToArray().Select(a => a.IndexOf(' ') == -1 ? a : ("\"" + a  + "\"")).StrCat(" ");
        }
    }
}
