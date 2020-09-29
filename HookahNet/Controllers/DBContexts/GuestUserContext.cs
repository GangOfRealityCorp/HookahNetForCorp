using HookahNet.Model;
using Microsoft.EntityFrameworkCore;

namespace HookahNet.Controllers.DBContexts
{
    public class GuestUserContext : DbContext
    {
        public DbSet<GuestUser> guestUserContext { get; set; }

    }
}
