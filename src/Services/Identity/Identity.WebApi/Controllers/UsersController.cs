using Identity.Application.IServices;
using Identity.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Domain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUsersService _usersService;

		public UsersController(IUsersService usersService)
		{
			_usersService = usersService;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
		{
			var token = await _usersService.GetAuthenticationTokenAsync(loginUserDTO);
			
			return Ok(new { Token = token });
		} 

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<CreateUserDTO>> Register([FromBody] CreateUserDTO createUserDTO)
		{
			await _usersService.CreateUserAsync(createUserDTO);

			return CreatedAtAction("GetUserById", createUserDTO);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
		{
			return Ok(await _usersService.GetAllUsersAsync());
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> UpdateUser(UserDTO userDTO)
		{
			await _usersService.UpdateUserAsync(userDTO);

			return Ok();
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			await _usersService.DeleteUserAsync(id);

			return Ok();
		}
	}
}