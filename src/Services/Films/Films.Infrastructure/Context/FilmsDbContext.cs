using Films.Domain.Models;
using Films.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.Context
{
	public class FilmsDbContext : DbContext
	{
		public FilmsDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Film> Films { get; set; }
		public DbSet<FilmType> Types { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new FilmConfiguration()).ApplyConfiguration(new FilmTypeConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
