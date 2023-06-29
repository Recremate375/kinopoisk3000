using Microsoft.AspNetCore.Mvc;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Identity.Application.IServices;

namespace Identity.Domain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class RolesController : ControllerBase
	{
		private readonly IRoleService rolesService;

		public RolesController(IRoleService roleService)
		{
			this.rolesService = roleService;
		}

		[Authorize(Roles = "admin")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
		{
			var roles = await rolesService.GetAllRolesAsync();
			
			return Ok(roles);
		}

		[Authorize(Roles = "admin")]
		[HttpPost]
		public async Task<ActionResult<Role>> AddNewRole([FromBody] RoleDTO roleDTO)
		{
			await rolesService.CreateRoleAsync(roleDTO);

			return Ok(roleDTO);
		}

		[Authorize(Roles = "admin")]
		[HttpPut]
		public async Task<ActionResult<Role>> ChangeRole([FromBody] RoleDTO roleDTO)
		{
			await rolesService.UpdateRoleAsync(roleDTO);

			return Ok(roleDTO);
		}

		[Authorize(Roles = "admin")]
		[HttpDelete]
		public async Task<IActionResult> DeleteRole(int id)
		{
			await rolesService.DeleteRoleAsync(id);

			return Ok();
		}
	}
}
