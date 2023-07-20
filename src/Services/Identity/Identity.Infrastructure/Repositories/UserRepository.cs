using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(IdentityDbContext context) : base(context) 
		{ }

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			var user = await _context.Users.Include(x => x.UserRole).AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

			return user;
		}

		public new async Task<List<User>> GetAllAsync()
		{
			return await _context.Users.Include(x => x.UserRole).AsNoTracking().ToListAsync();
		}

	}
}
