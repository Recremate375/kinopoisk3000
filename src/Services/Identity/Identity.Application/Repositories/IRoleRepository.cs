using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Repositories
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		Task<Role> GetRoleByNameAsync(string roleName);
	}
}
