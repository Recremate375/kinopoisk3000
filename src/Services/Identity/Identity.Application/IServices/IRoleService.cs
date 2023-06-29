using Identity.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.IServices
{
	public interface IRoleService
	{
		Task<List<RoleDTO>> GetAllRolesAsync();
		Task CreateRoleAsync(RoleDTO roleDTO);
		Task UpdateRoleAsync(RoleDTO roleDTO);
		Task DeleteRoleAsync(int id);
	}
}
