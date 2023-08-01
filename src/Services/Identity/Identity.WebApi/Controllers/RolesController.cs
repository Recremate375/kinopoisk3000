using Identity.Application.IServices;
using Identity.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Domain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "admin")]
	public class RolesController : ControllerBase
	{
		private readonly IRoleService _rolesService;

		public RolesController(IRoleService roleService)
		{
			_rolesService = roleService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRoles()
		{
			var roles = await _rolesService.GetAllRolesAsync();

			return Ok(roles);
		}

		[HttpPost]
		public async Task<IActionResult> AddNewRole([FromBody] RoleDTO roleDTO)
		{
			var result = await _rolesService.CreateRoleAsync(roleDTO);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> ChangeRole([FromBody] RoleDTO roleDTO)
		{
			await _rolesService.UpdateRoleAsync(roleDTO);

			return Ok(roleDTO);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteRole(int id)
		{
			await _rolesService.DeleteRoleAsync(id);

			return Ok();
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<IActionResult> GetRoleById([FromRoute] int id)
		{
			return Ok(await _rolesService.GetRoleByIdAsync(id));
		}
	}
}
