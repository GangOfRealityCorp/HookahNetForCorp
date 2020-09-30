using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using HookahNet.Controllers.DBContexts;
using HookahNet.Models;
using HookahNet.Controllers.ControllerModels;

namespace HookahNet.Controllers.Account
{
    [Route("Account/{controller}")]
    [ApiController]
    public class LoginController : ControllerBase
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
            var guestUser = await context.guestUserTable.FirstOrDefaultAsync((user) => user.Email == loginModel.Email);
            if(guestUser == null)
                return Conflict($"User with Email '{loginModel.Email}' not found");

            if (guestUser.Password != loginModel.Password)
                return Conflict($"Password incorrect");

            return Ok("Login successful");
            //TODO: responce token.
        }
    }
}
