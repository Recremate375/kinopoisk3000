using AutoMapper;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Identity.Application.Features
{
	public class RolesService : IRoleService
	{
		private readonly IRoleRepository _roleRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<RolesService> _logger;

		public RolesService(IRoleRepository roleRepository, IMapper mapper,
			ILogger<RolesService> logger)
		{
			_roleRepository = roleRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<List<RoleDTO>> GetAllRolesAsync()
		{
			var roles = await _roleRepository.GetAllAsync();
			var rolesDTO = _mapper.Map<List<RoleDTO>>(roles);

			_logger.LogInformation("All roles was successfully received.");

			return rolesDTO;
		}

		public async Task<Domain.Models.Role> CreateRoleAsync(RoleDTO roleDTO)
		{
			var role = _mapper.Map<Role>(roleDTO);

			await _roleRepository.CreateAsync(role);
			await _roleRepository.SaveAsync();

			_logger.LogInformation($"Role was successfully created. Id: {role.Id}");

			return role;
		}

		public async Task UpdateRoleAsync(RoleDTO roleDTO)
		{
			var role = await _roleRepository.GetRoleByNameAsync(roleDTO.RoleName);

			if (role is null)
			{
				_logger.LogError($"Role {roleDTO.RoleName} is not found.");

				throw new NotFoundException($"Role {roleDTO.RoleName} is not found.");
			}

			role = _mapper.Map<Role>(roleDTO);

			_roleRepository.Update(role);
			await _roleRepository.SaveAsync();

			_logger.LogInformation($"Role was successfully updated. Id: {role.Id}");
		}

		public async Task DeleteRoleAsync(int id)
		{
			var role = await _roleRepository.GetByIdAsync(id);

			if (role is null)
			{
				_logger.LogError($"Role with Id ({id}) is not found.");

				throw new NotFoundException($"Role with Id ({id}) is not found.");
			}

			_roleRepository.Delete(role);
			await _roleRepository.SaveAsync();

			_logger.LogInformation($"Role was successfully deleted. Id: {role.Id}");
		}

		public async Task<RoleDTO?> GetRoleByIdAsync(int id)
		{
			var role = await _roleRepository.GetByIdAsync(id);
			
			if (role is null)
			{
				_logger.LogError($"Role with Id ({id}) is not found.");

				throw new NotFoundException($"Role with Id ({id}) is not found.");
			}

			var roleDTO = _mapper.Map<RoleDTO>(role);

			_logger.LogInformation($"Role was successfully received. Id: {id}");

			return roleDTO;
		}
	}
}
