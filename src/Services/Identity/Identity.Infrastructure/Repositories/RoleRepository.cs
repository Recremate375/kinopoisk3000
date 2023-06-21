using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		private readonly IdentityDbContext context;

		public RoleRepository(IdentityDbContext context) : base(context) 
		{
			this.context = context;
		}

		public async Task CreateAsync(Role entity)
		{
			await context.Roles.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<Role> GetRoleByNameAsync(string roleName)
		{
			return await context.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);
		}

	}
}
