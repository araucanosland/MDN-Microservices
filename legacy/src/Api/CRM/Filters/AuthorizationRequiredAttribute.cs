using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRM.Filters
{
    public class AuthorizationRequiredAttribute : Attribute, IActionFilter
    {
        private const string Token = "Token";

        public AuthorizationRequiredAttribute()
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var provider = new CRM.Providers.TokenService();
            if (context.HttpContext.Request.Headers.ContainsKey(Token))
            {
                var tokenValue = context.HttpContext.Request.Headers.FirstOrDefault(d => d.Key == Token).Value;
                // Validate Token
                if (provider != null && !provider.ValidateToken(tokenValue))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}