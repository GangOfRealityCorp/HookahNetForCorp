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
using HookahNet.Controllers.ControllerModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<IActionResult> LoginGuestUser([FromBody] LoginModel loginModel)
        {
            bool isIdentity = await GetIdentity(loginModel);

            if(!isIdentity)
                return BadRequest($"Invalid username or password.");

            var response = new
            {
                access_token = GenerateToken(loginModel),
                username = loginModel.Email
            };

            return Json(response);
        }

        private async Task<bool> GetIdentity(LoginModel loginModel)
        {
            var guestUser = await context.guestUserTable.FirstOrDefaultAsync((user) => user.Email == loginModel.Email && user.Password == loginModel.Password);
            if (guestUser == null)
                return false;
            return true;
        }

        private string GenerateToken(LoginModel loginModel)
        {
            var currentTime = DateTime.UtcNow;
            // create JWT-token
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: currentTime,
                    claims: null,
                    expires: currentTime.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
