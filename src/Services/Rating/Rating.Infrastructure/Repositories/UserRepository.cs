using Microsoft.EntityFrameworkCore;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.Infrastructure.Context;

namespace Rating.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(RatingDbContext context) : base(context)
		{

		}

		public async Task<User?> GetUserByLoginAsync(string login)
		{
			return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
		}
	}
}
