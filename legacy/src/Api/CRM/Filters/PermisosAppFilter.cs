using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Security.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace CRM.Filters
{
    public class PermisosAppFilter : ActionFilterAttribute
    {
        private const string Token = "Token";
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}