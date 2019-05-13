using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRM.Filters
{
    public class UserResourceAttribute : ActionFilterAttribute
    {
        public UserResourceAttribute()
        {
        }
    }
}