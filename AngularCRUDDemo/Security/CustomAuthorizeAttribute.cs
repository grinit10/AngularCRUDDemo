using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AngularCRUDDemo.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (string.IsNullOrEmpty(SessionPersister.Username))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Account", Action = "login" }));
            else
            {
                CustomPrincipal cm = new CustomPrincipal(SessionPersister.Username);
                if(!cm.IsInRole(Roles))
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "AccessDenied", Action = "index" }));
            }
        }
    }
}