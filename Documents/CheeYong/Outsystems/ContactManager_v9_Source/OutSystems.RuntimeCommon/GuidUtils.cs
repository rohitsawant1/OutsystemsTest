/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Text.RegularExpressions;

namespace OutSystems.RuntimeCommon {
    
    public static class GuidUtils {

        private static Regex isGuidRegex;
        private static Regex IsGuidRegex {
            get {
                if (isGuidRegex == null) {
                    isGuidRegex = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                }
                return isGuidRegex;
            }
        }

        public static bool IsGuid(string str) {
            if (!string.IsNullOrEmpty(str)) {
                if (IsGuidRegex.IsMatch(str)) {
                    return true;
                }
            }

            return false;
        }

        public static bool TryParse(string value, out Guid guid) {
            if (IsGuid(value)) {
                guid = new Guid(value);
                return true;
            }

            guid = Guid.Empty;
            return false;
        }
    }
}