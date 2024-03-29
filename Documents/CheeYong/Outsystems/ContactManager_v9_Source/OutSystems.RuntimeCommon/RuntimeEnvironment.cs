/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.RuntimeCommon {

    public static class RuntimeEnvironment {

        private static readonly Lazy<string> machineName = new Lazy<string>(() => Environment.MachineName.ToUpperInvariant());

        /// <summary>
        /// Gets the name of this local computer in uppercase.
        /// </summary>
        public static string MachineName {
            get {
                return machineName.Value;
            }
        }

        public static string FixHostIPForIPV6(string host) {
            return (host.Contains(":") && !host.StartsWith("[")) ? "[" + host + "]" : host;
        }
    }
}
