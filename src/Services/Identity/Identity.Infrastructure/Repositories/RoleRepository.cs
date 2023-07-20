using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(IdentityDbContext context) : base(context) 
		{ }

		public async Task<Role?> GetRoleByNameAsync(string roleName)
		{
			return await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.RoleName == roleName);
		}

	}
}
