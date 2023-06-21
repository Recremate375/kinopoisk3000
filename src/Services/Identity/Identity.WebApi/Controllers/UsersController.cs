using AutoMapper;
using Identity.Application.Features;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Identity.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository userRepository;
		private readonly IRoleRepository roleRepository;
		private IOptions<AuthOptions> options;
		private readonly IMapper mapper;

		public UsersController(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
		{
			this.userRepository = userRepository;
			this.roleRepository = roleRepository;
			this.mapper = mapper;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
		{
			var user = await userRepository.GetUserByEmailAsync(loginUserDTO.Email);

			GenerateJWTClass JWTtoken = new GenerateJWTClass(roleRepository, options);
			var token = JWTtoken.GenerateJWT(user);

			return Ok(new { Token = token });
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
		{
			var users = await userRepository.GetAllAsync();
			var userDTOs = mapper.Map<List<UserDTO>>(users);

			return Ok(userDTOs);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<ActionResult<CreateUserDTO>> Register([FromBody] CreateUserDTO createUserDTO)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);
			}

			var user = mapper.Map<User>(createUserDTO);

			await userRepository.CreateAsync(user);
			await userRepository.SaveAsync();

			return CreatedAtAction("GetUserById", createUserDTO);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles="admin")]
		public async Task<IActionResult> UpdateUser(UserDTO userDTO)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);
			}

			var user = mapper.Map<User>(userDTO);

			userRepository.Update(user);
			await userRepository.SaveAsync();

			return Ok();
		}

		[HttpDelete]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			userRepository.DeleteAsync(id);
			await userRepository.SaveAsync();

			return Ok();
		}
	}
}
