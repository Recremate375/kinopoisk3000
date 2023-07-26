using Microsoft.EntityFrameworkCore;
using Rating.Domain.Models;
using System.Reflection;

namespace Rating.Infrastructure.Context
{
	public class RatingDbContext : DbContext
	{
		public DbSet<Domain.Models.Rating> Ratings { get; set; }
		public DbSet<Film> Films { get; set; }
		public DbSet<User> Users { get; set; }

		public RatingDbContext(DbContextOptions options) : base(options)
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
