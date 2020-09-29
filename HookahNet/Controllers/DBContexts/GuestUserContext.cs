using HookahNet.Models;
using Microsoft.EntityFrameworkCore;

namespace HookahNet.Controllers.DBContexts
{
    public class GuestUserContext : DbContext
    {
        public GuestUserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<GuestUser> guestUserContext { get; set; }

    }
}
