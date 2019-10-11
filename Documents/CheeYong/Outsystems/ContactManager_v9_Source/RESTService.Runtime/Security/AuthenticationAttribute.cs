/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using OutSystems.Plugin.RESTService.Controllers;
using OutSystems.Plugin.RESTService.ErrorHandling;
using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace OutSystems.Plugin.RESTService.Security {

    public class AuthenticationAttribute : AuthorizeAttribute {

        public bool RequireAuthentication { get; set; }

        public AuthenticationAttribute()
            : this(true) {
        }

        public AuthenticationAttribute(bool requireAuthentication) {
            RequireAuthentication = requireAuthentication;
        }

        public override void OnAuthorization(HttpActionContext actionContext) {
            try {
                if (RequireAuthentication) {
                    RestServiceApiController controller = (RestServiceApiController)actionContext.ControllerContext.Controller;
                    controller.StartExecution = DateTime.Now;
                    controller.OnAuthentication();
                }
            } catch (Exception e) {
                throw new ExposeRestException(e.Message, System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}