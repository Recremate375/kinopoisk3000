using Microsoft.EntityFrameworkCore;
using Identity.Domain.Models;
using Microsoft.IdentityModel.Abstractions;

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
			modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
			modelBuilder.Entity<Role>().HasIndex(u => u.RoleName).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
