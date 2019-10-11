/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutSystems.REST {
    /// <summary>
    /// Utility class containing methods to parse and write dates in the WCF format.
    /// </summary>
    /// It is especially useful for applications using the Windows Communication Foundation.
    public static class WCFDateTimeHelper {

        private static readonly DateTime EpochDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        /// <summary>
        /// Parse the received input string as a WCF datetime and return an object representing it.
        /// </summary>
        /// <param name="text">Text to parse.</param>
        /// <returns>The read datetime.</returns>
        public static DateTime TextToDateTime(string text) {
            string timestamp = System.Text.RegularExpressions.Regex.Replace(text, "[^(]*\\(([+-]?\\d+)([+-]\\d+)?\\).*", "$1");
            long millisecondsSinceEpoch = long.Parse(timestamp);
            return EpochDate.AddMilliseconds(millisecondsSinceEpoch).ToLocalTime();
        }

        /// <summary>
        /// Return the textual representation of the input datetime.
        /// </summary>
        /// <param name="date"> Datetime to convert to string.</param>
        /// <returns>a string  of <code>date</code> in the WCF format.</returns>
        public static String DateTimeToText(DateTime date) {
            long millisecondsSinceEpoch = (long)(date - EpochDate).TotalMilliseconds;
            return "/Date(" + millisecondsSinceEpoch + ")/";
        }
    }
}
