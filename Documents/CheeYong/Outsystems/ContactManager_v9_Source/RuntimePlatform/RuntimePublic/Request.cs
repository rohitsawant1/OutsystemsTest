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
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimeCommon;


namespace OutSystems.RuntimePublic {

    /// <summary>
    /// API used to obtain data from RequestEvents
    /// </summary>
    public static class Request {

        /// <summary>
        /// Returns the current RequestKey, consistent with RequestEvents being logged in the database for the current request.
        /// If there is no RequestKey available in the current context, an empty string is returned.
        /// </summary>
        /// <returns>A string containing the request key.</returns>
        public static string GetRequestKey() {
            RequestTracer tracer = RuntimePlatformUtils.GetRequestTracer();

            if (tracer != null) {
                return tracer.RequestKey;
            }

            return "";
        }

    }
}
