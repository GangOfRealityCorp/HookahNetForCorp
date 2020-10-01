using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HookahNet.Controllers.Account
{
    [Route("Account/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult ValidateStatus()
        {
            return Ok("everything is ok");
        }
    }
}
