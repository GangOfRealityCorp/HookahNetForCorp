using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HookahNet.Controllers.DBContexts;
using HookahNet.Models;

namespace HookahNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestUsersController : ControllerBase
    {
        private readonly GuestUserContext context;

        public GuestUsersController(GuestUserContext context)
        {
            this.context = context;
        }

        // GET: api/GuestUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestUser>>> GetguestUserContext()
        {
            return await context.guestUserContext.ToListAsync();
        }

        // POST: api/GuestUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GuestUser>> PostGuestUser(GuestUser guestUser)
        {
            context.guestUserContext.Add(guestUser);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetGuestUser", new { id = guestUser.Id }, guestUser);
        }
    }
}
