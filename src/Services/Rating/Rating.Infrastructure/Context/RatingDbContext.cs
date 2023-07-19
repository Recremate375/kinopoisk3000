using Microsoft.EntityFrameworkCore;
using Rating.Domain.Models;

namespace Rating.Infrastructure.Context
{
	public class RatingDbContext : DbContext
	{
        public RatingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Domain.Models.Rating> Ratings { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
