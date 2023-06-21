using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Identity.Application.Repositories;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Data;

namespace Identity.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class RolesController : ControllerBase
	{
		private readonly IRoleRepository roleRepository;
		private readonly IMapper mapper;

		public RolesController(IRoleRepository roleRepository, IMapper mapper)
		{
			this.roleRepository = roleRepository;
			this.mapper = mapper;
		}

		[HttpGet]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
		{
			var roles = await roleRepository.GetAllAsync();
			var rolesDTO = mapper.Map<List<RoleDTO>>(roles);

			return Ok(rolesDTO);
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<ActionResult<Role>> AddNewRole([FromBody] RoleDTO roleDTO)
		{
			if(!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);
			}

			var role = mapper.Map<Role>(roleDTO);

			await roleRepository.CreateAsync(role);
			await roleRepository.SaveAsync();

			return Ok(roleDTO);
		}

		[HttpPut]
		public async Task<ActionResult<Role>> ChangeRole([FromBody] RoleDTO roleDTO)
		{
			var role = mapper.Map<Role>(roleDTO);

			roleRepository.Update(role);
			await roleRepository.SaveAsync();

			return Ok(role);
		}

		[HttpDelete]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> DeleteRole(int id)
		{
			roleRepository.DeleteAsync(id);
			await roleRepository.SaveAsync();

			return Ok();
		}
	}
}
