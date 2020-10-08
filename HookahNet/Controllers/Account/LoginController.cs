using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;

using HookahNet.Controllers.DBContexts;
using HookahNet.Models;
using HookahNet.Controllers.ControllerDTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HookahNet.Controllers.Account
{
    [Route("Account/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly StoreContext context;
        public LoginController(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET: Account/Login
        /// </summary>
        /// <param name="guestUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginGuestUser([FromBody] LoginDTO loginModel)
        {
            bool isIdentity = await GetIdentity(loginModel);

            if (!isIdentity)
                return StatusCode(
                    (int)HttpStatusCode.BadRequest, 
                    "Invalid username or password.");

            var response = new
            {
                access_token = Token.Generate(),
                userEmail = loginModel.Email
            };

            return Json(response);
        }

        private async Task<bool> GetIdentity(LoginDTO loginModel)
        {
            var guestUser = await context.guestUserTable.FirstOrDefaultAsync((user) => user.Email == loginModel.Email && user.Password == loginModel.Password);
            if (guestUser == null)
                return false;
            return true;
        }
    }
}
