using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Identity.Application.Repositories;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Authorization;

namespace Identity.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "admin")]
	public class RolesController : ControllerBase
	{
		private readonly IRoleRepository roleRepository;
		public RolesController(IRoleRepository roleRepository)
		{
			this.roleRepository = roleRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
		{
			return await roleRepository.GetAll();
		}

		[HttpPost]
		public async Task<ActionResult<Role>> AddNewRole([FromBody] Role role)
		{
			await roleRepository.Create(role);
			await roleRepository.Save();

			return Ok(role);
		}
	}
}
