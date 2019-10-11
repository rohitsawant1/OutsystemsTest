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

namespace OutSystems.HubEdition.RuntimePlatform {
    public class ESpaceInternalCallDetails : RequestEventDetails {
        public const string NUMBER_OF_EXECUTIONS = "NE";
        public const string OBJECT_NAME = "ON";
        public const string OBJECT_KEY = "OK";
        public const string OBJECT_ESPACE_NAME = "OEN";
        public const string OBJECT_ESPACE_KEY = "OEK";

        public ESpaceInternalCallDetails() { }

        public ESpaceInternalCallDetails(string objectKey, string objectName, string eSpaceKey, string eSpaceName, RequestEventDetails details) : base(details) {
            Add(OBJECT_NAME, objectName);
            Add(OBJECT_KEY, objectKey);
            Add(OBJECT_ESPACE_NAME, eSpaceName);
            Add(OBJECT_ESPACE_KEY, eSpaceKey);
            Add(NUMBER_OF_EXECUTIONS, 0);
        }

        public void AddExecution() {
            this[NUMBER_OF_EXECUTIONS] = Convert.ToInt32(this[NUMBER_OF_EXECUTIONS]) + 1;
        }
    }
}
