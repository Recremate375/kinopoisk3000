using AutoMapper;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;

namespace Identity.Application.Features
{
	public class RolesService : IRoleService
	{
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            var rolesDTO = _mapper.Map<List<RoleDTO>>(roles);

            return rolesDTO;
        }

        public async Task CreateRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);

            await _roleRepository.CreateAsync(role);
            await _roleRepository.SaveAsync();
        }

        public async Task UpdateRoleAsync(RoleDTO roleDTO)
        {
            var role = await _roleRepository.GetRoleByNameAsync(roleDTO.RoleName)
                ?? throw new NotFoundException($"Role {roleDTO.RoleName} is not found.");

            role = _mapper.Map<Role>(roleDTO);

            _roleRepository.Update(role);
            await _roleRepository.SaveAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Role with Id ({id}) is not found.");
			
            _roleRepository.Delete(role);
			await _roleRepository.SaveAsync();
		}
    }
}
