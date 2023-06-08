using Identity.Application.Features;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly IRoleRepository roleRepository;
		public UsersController(IUserRepository userRepository, IRoleRepository roleRepository)
		{
			this.userRepository = userRepository;
			this.roleRepository = roleRepository;
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
		{
			var users = await userRepository.GetAll();
			if (users == null)
			{
				return NoContent();
			}
			List<UserDTO> userDTOs = new List<UserDTO>();
			foreach (var user in users)
			{
				UserDTO userDTO = new UserDTO()
				{
					Name = user.Name,
					Email = user.Email,
					Password = user.Password,
					Login = user.Login,
					Surname = user.Surname,
					UserRole = user.UserRole
				};
				userDTOs.Add(userDTO);
			}
			return Ok(userDTOs);
		}

		[HttpPost]
		public async Task<ActionResult<CreateUserDTO>> Register([FromBody] CreateUserDTO createUserDTO)
		{
			await userRepository.Create(createUserDTO);
			await userRepository.Save();

			return Created("GetUserById", createUserDTO);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
		{
			var user = await userRepository.GetUserByEmail(loginUserDTO.Email);

			try
			{
				if (user != null)
				{
					if (loginUserDTO.Password != user.Password)
					{
						return BadRequest("Incorrect Password");
					}
					GenerateJWTClass JWTtoken = new GenerateJWTClass(roleRepository);
					var token = JWTtoken.GenerateJWT(user);

					return Ok(new { Token = token });
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok();
		}


	}
}
