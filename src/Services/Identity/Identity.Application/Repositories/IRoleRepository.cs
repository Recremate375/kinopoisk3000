using Identity.Domain.Models;

namespace Identity.Application.Repositories
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		Task<Role> GetRoleByNameAsync(string roleName);
	}
}
