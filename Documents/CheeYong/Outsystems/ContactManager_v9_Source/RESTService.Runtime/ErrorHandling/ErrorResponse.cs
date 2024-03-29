/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using System.Collections.Generic;

namespace OutSystems.RESTService.ErrorHandling {

    public class ErrorResponse {
        public List<string> Errors { get; set; }
        public int StatusCode { get;  set; }

        public ErrorResponse() { }

        public ErrorResponse(String error, int statuscode) : this(new List<string>(1) { error }, statuscode) { }

        public ErrorResponse(List<String> errors, int statuscode) {
            this.Errors = errors;
            this.StatusCode = statuscode;
        }
    }

}
