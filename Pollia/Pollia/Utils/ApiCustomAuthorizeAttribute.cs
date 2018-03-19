using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;

namespace Pollia.Utils
{
    public class ApiCustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                Content = new StringContent("You are unauthorized to access this resource")
            };
        }
    }
}