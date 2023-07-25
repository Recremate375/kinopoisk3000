using Microsoft.EntityFrameworkCore;
using Identity.Domain.Models;
using Identity.Infrastructure.Context.Configurations;

namespace Identity.Infrastructure.Context
{
    public class IdentityDbContext : DbContext
    {
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		public IdentityDbContext(DbContextOptions options) : base(options)
        { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration()).ApplyConfiguration(new RoleConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
