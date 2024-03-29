/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;
using OutSystems.ObjectKeys;

namespace OutSystems.RuntimeCommon {

    public static class LocalKeyValueUtils {

        private static readonly IDictionary<string, LocalKeyValue> namesToKeys;

        static LocalKeyValueUtils() {
            namesToKeys = new Dictionary<string, LocalKeyValue>();
            foreach (LocalKeyValue value in Enum.GetValues(typeof(LocalKeyValue))) {
                namesToKeys.Add(value.ToString(), value);
            }
        }

        public static LocalKeyValue ToLocalKeyValue(string value) {
            return namesToKeys[value];
        }
    }
}