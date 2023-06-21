using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly IdentityDbContext _context;
		private readonly IRoleRepository roleRepository;

		public UserRepository(IdentityDbContext context, IRoleRepository roleRepository) : base(context) 
		{
			_context = context;
			this.roleRepository = roleRepository;
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			var user = await _context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Email == email);

			return user;
		}

		public async Task CreateAsync(User entity)
		{
			var role = await roleRepository.GetRoleByNameAsync("user");

			entity.UserRole = role;

			await _context.Users.AddAsync(entity);
		}

	}
}
