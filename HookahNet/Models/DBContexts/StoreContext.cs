using HookahNet.Models;
using Microsoft.EntityFrameworkCore;

namespace HookahNet.Controllers.DBContexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<GuestUser> guestUserTable { get; set; }

    }
}
