using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using HookahNet.Controllers.DBContexts;
using HookahNet.Models;
using HookahNet.Controllers.ControllerDTO;
using HookahNet.Controllers.Account;
using System.Net;

namespace HookahNet.Controllers
{
    [ApiController]
    [Route("Account/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly StoreContext context;

        public RegistrationController(StoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// POST: Account/Registration
        /// </summary>
        /// <param name="guestUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegistrateGuestUser([FromBody] RegistrationDTO registrationModel)
        {
            var guestUser = await context.guestUserTable.FirstOrDefaultAsync((user) => user.Email == registrationModel.Email);
            if (guestUser == null)
            {
                context.guestUserTable.Add(new GuestUser(
                    registrationModel.Email,
                    registrationModel.Name,
                    registrationModel.Password));
                await context.SaveChangesAsync();

                var response = new
                {
                    access_token = Token.Generate(),
                    userEmail = registrationModel.Email,
                    message = "User has been created"
                };
                return Json(response);
            }
            return Conflict($"User with Email '{registrationModel.Email}' already exist");
        }
    }
}
