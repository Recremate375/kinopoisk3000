using AutoMapper;
using FluentValidation;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;

namespace Identity.Application.Features
{
	public class RolesService : IRoleService
	{
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        private readonly IValidator<RoleDTO> validator;
        public RolesService(IRoleRepository roleRepository, IMapper mapper, IValidator<RoleDTO> validator)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<List<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await roleRepository.GetAllAsync();
            var rolesDTO = mapper.Map<List<RoleDTO>>(roles);

            return rolesDTO;
        }

        public async Task CreateRoleAsync(RoleDTO roleDTO)
        {
            var validateResult = await validator.ValidateAsync(roleDTO);

            if (!validateResult.IsValid)
            {
                throw new BadRequestException(validateResult.ToString());
            }

            var role = mapper.Map<Role>(roleDTO);

            await roleRepository.CreateAsync(role);
            await roleRepository.SaveAsync();
        }

        public async Task UpdateRoleAsync(RoleDTO roleDTO)
        {
            var validateResult = await validator.ValidateAsync(roleDTO);

            if (!validateResult.IsValid)
            {
				throw new BadRequestException(validateResult.ToString());
			}

            var role = mapper.Map<Role>(roleDTO);

            roleRepository.Update(role);
            await roleRepository.SaveAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);

            roleRepository.Delete(role);
            await roleRepository.SaveAsync();
        }
    }
}
