using Identity.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
