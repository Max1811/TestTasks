using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using Namotion.Reflection;
using TestTask.API.Filters;
using TestTask.Services.Contracts;

namespace TestTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopeController : ControllerBase
    {
        private readonly IUserService _userService;
        public DevelopeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("authorize")]
        [AuthorizationFilter]
        public IActionResult Authorize()
        {
            return new OkResult();
        }

        [HttpGet("get/token")]
        public IActionResult GetToken(string id)
        {
            KeyValuePair<string, string> token = _userService.GetToken(id);

            if (token.Equals(default(KeyValuePair<string, string>)))
            {
                return new StatusCodeResult(301);
            }

            if (HttpContext.Request.Cookies.ContainsKey("token"))
            {
                return new StatusCodeResult(409);
            }

            HttpContext.Response.Cookies.Append("token", token.Key);
            HttpContext.Response.Cookies.Append(token.Key, token.Value);

            return new OkResult();
        }
    }
}
