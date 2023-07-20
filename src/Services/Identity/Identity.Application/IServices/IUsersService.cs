using Identity.Domain.DTO;
using Identity.Domain.Models;

namespace Identity.Application.IServices
{
	public interface IUsersService
	{
		Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO);

		Task<User> CreateUserAsync(CreateUserDTO createUserDTO);
		
		Task<List<UserDTO>> GetAllUsersAsync();
		
		Task UpdateUserAsync(UserDTO userDTO);
		
		Task DeleteUserAsync(int id);

		Task<UserDTO> GetUserByIdAsync(int id);
	}
}
