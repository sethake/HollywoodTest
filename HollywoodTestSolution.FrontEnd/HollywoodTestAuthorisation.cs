using HollywoodTestSolution.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTestSolution.FrontEnd
{
    public class HollywoodTestAuthorisation: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = httpContext.Session["AuthRequest"] != null;
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.RequestType == "POST")
            {
                filterContext.Result = new JsonResult() { Data = new ControllerResponse(System.Net.HttpStatusCode.Unauthorized, "Unauthorised , please log in"), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
                string url = urlHelper.Action("Index", "Account");
                filterContext.HttpContext.Server.TransferRequest(url);
            }
        }
    }
}