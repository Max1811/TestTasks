using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API.MiddlewareComponents
{
    public class TokenCheck
    {
        private readonly RequestDelegate _next;

        public TokenCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Cookies["token"] == null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("no access");
            }

            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
