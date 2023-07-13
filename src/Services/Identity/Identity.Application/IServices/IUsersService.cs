using Identity.Domain.DTO;

namespace Identity.Application.IServices
{
	public interface IUsersService
	{
		Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO);

		Task CreateUserAsync(CreateUserDTO createUserDTO);
		
		Task<List<UserDTO>> GetAllUsersAsync();
		
		Task UpdateUserAsync(UserDTO userDTO);
		
		Task DeleteUserAsync(int id);
	}
}
