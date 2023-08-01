using Films.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Films.Infrastructure.Context
{
	public class FilmsDbContext : DbContext
	{
		public FilmsDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Film> Films { get; set; }
		public DbSet<FilmType> Types { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
