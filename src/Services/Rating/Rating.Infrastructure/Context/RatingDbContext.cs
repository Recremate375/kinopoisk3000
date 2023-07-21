using Microsoft.EntityFrameworkCore;
using Rating.Domain.Models;

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
			modelBuilder.Entity<Film>().HasIndex(f => f.FilmName).IsUnique();
			modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
