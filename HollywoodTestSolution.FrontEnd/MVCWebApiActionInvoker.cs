using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HollywoodTestSolution.FrontEnd
{
    public class MVCWebApiActionInvoker : ControllerActionInvoker
    {
        protected override ActionResult CreateActionResult(
     ControllerContext controllerContext,
     ActionDescriptor actionDescriptor,
     Object actionReturnValue)
        {
            if (actionReturnValue == null)
                return new EmptyResult();

            var actionResult = actionReturnValue as ActionResult;
            if (actionResult == null)
            {
                return new JsonResult
                {
                    Data = actionReturnValue,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = 50000000
                };
            }
            return base.CreateActionResult(controllerContext, actionDescriptor,
                          actionReturnValue);
        }
    }
}