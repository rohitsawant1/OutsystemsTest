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

namespace OutSystems.RuntimeCommon {
    
    public enum JQueryVersion {
        JQuery183, 
        JQuery142, 
        NotApplicable
    }
    
    public static partial class DisplayNames {
        public static string DisplayName(this JQueryVersion value) {
            switch (value) {
                case JQueryVersion.JQuery183:
                    return "1.8.3";
                case JQueryVersion.JQuery142:
                    return "1.4.2 OS";
                case JQueryVersion.NotApplicable:
                    return "Not Applicable";
                default:
                    throw new InvalidOperationException("There's a case missing in this switch: " + value);
            }
        }
    }

    public static class JQueryVersionUtils {
        public static JQueryVersion ParseFromString(string value) {
            return (String.IsNullOrEmpty(value) || (value.Trim() == String.Empty))? JQueryVersion.NotApplicable: 
                (JQueryVersion) Enum.Parse(typeof(JQueryVersion), value);
        }
    }
}
