using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Homework1.Filters
{
    public class MyAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (base.IsAuthorized(actionContext))
            {
                Trace.WriteLine(HttpContext.Current.User.Identity.Name);
                return true;
            }
            else
            {
                Trace.WriteLine(actionContext.ActionDescriptor.ActionName + "  " + DateTime.Now.ToShortDateString());
                return false;
            }
            
        }
    }
}