using Identity.Domain.DTO;

namespace Identity.Application.IServices
{
	public interface IRoleService
	{
		Task<List<RoleDTO>> GetAllRolesAsync();

		Task<Domain.Models.Role?> CreateRoleAsync(RoleDTO roleDTO);

		Task UpdateRoleAsync(RoleDTO roleDTO);
		
		Task DeleteRoleAsync(int id);

		Task<RoleDTO?> GetRoleByIdAsync(int id);
	}
}
