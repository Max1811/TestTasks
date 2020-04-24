using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestTask.Services.Contracts;

namespace TestTask.API.Filters
{
    public class AuthorizationFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            IUserService userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
            if (context.HttpContext.Request.Cookies["token"] != null)
            {
                string id = context.HttpContext.Request.Cookies["token"];
                string token = context.HttpContext.Request.Cookies[id];

                if(userService.GetToken(id).Value == token)
                {
                    return;
                }
            }

            context.Result = new StatusCodeResult(403);
            return;
        }
    }
}
