/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;

namespace OutSystems.HubEdition.RuntimePlatform {
    public class ESpaceExternalCallDetails : RequestEventDetails {
        public const string NUMBER_OF_EXECUTIONS = "NE";
        public const string OBJECT_NAME = "ON";
        public const string OBJECT_KEY = "OK";
        public const string OBJECT_ESPACE_NAME = "OEN";
        public const string OBJECT_ESPACE_KEY = "OEK";
        public const string PRODUCER_ESPACE_KEY = "PEK";

        public ESpaceExternalCallDetails() { }

        public ESpaceExternalCallDetails(string objectKey, string objectName, string eSpaceKey, string eSpaceName, string producerEspaceKey, RequestEventDetails details) : base(details) {
            Add(OBJECT_NAME, objectName);
            Add(OBJECT_KEY, objectKey);
            Add(OBJECT_ESPACE_NAME, eSpaceName);
            Add(OBJECT_ESPACE_KEY, eSpaceKey);
            Add(NUMBER_OF_EXECUTIONS, 0);
            Add(RequestEventDetails.DURATION, 0);
            Add(RequestEventDetails.ERROR_COUNT, 0);
            if (!String.IsNullOrEmpty(producerEspaceKey)) {
                Add(PRODUCER_ESPACE_KEY, producerEspaceKey);
            }
        }

        public void AddExecution(int executionDuration, bool executedWithError) {
            this[NUMBER_OF_EXECUTIONS] = Convert.ToInt32(this[NUMBER_OF_EXECUTIONS]) + 1;
            this[RequestEventDetails.DURATION] = Convert.ToInt32(this[RequestEventDetails.DURATION]) + executionDuration;
            if (executedWithError) {
                this[RequestEventDetails.ERROR_COUNT] = Convert.ToInt32(this[RequestEventDetails.ERROR_COUNT]) + 1;
            }
        }
    }
}
