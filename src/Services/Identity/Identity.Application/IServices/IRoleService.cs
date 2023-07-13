using Identity.Domain.DTO;

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
