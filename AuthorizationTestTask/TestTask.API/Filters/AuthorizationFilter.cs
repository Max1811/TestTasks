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
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IUserService _userService;

        public AuthorizationFilter(IUserService userService)
        {
            _userService = userService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(context.HttpContext.Request.Cookies["token"] == null)
            {
                context.Result = new StatusCodeResult(403);
            }
            else
            {
                string id = context.HttpContext.Request.Cookies["token"];
                string token = context.HttpContext.Request.Cookies[id];

                if(_userService.GetToken(id).Value != token)
                {
                    context.Result = new StatusCodeResult(403);
                }
            }
        }
    }
}
