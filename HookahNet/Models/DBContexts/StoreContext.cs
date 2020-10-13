using HookahNet.Models;
using HookahNet.Models.Products;
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
        public DbSet<Organization> organizationTable { get; set; }
        public DbSet<Catalog> catalogTable { get; set; }
        public DbSet<Product> productTable { get; set; }
        public DbSet<HookahProduct> hookahProductTable { get; set; }
        public DbSet<TobaccoProduct> tobaccoProductTable { get; set; }
        public DbSet<FlaskFluidProduct> flaskFluidProductTable { get; set; }

    }
}
