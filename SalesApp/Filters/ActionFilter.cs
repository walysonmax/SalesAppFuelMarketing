using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using SalesApp.Domain;
using SalesApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Filters
{
    public class ActionFilter : ActionFilterAttribute
    {
        //After Method execution
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //Do stuff
        }

        //Before Method execution
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var user = context.HttpContext.Session.GetObjectFromJson<User>("UserInfo");
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Index", controller = "Login" }));
            }

            //Do stuff
        }
    }
}
