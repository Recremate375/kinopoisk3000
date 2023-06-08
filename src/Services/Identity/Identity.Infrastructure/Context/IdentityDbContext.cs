using Microsoft.EntityFrameworkCore;
using Identity.Domain.Models;

namespace Identity.Infrastructure.Context
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
