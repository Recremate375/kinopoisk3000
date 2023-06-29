using AutoMapper;
using FluentValidation;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;

namespace Identity.Application.Features
{
	public class UsersService : IUsersService
	{
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        private readonly IGenerateJWTService generateJWTClass;
        private readonly IValidator<UserDTO> userDTOValidator;
        private readonly IValidator<CreateUserDTO> createUserDTOValidator;
        private readonly IValidator<LoginUserDTO> loginUserDTOValidator;
        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository,
            IMapper mapper, IGenerateJWTService generateJWTClass,
            IValidator<UserDTO> userDTOvalidator, IValidator<CreateUserDTO> createUserDTOValidator,
			IValidator<LoginUserDTO> loginUserDTOValidator)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.generateJWTClass = generateJWTClass;
            this.userDTOValidator = userDTOvalidator;
            this.createUserDTOValidator = createUserDTOValidator;
            this.loginUserDTOValidator = loginUserDTOValidator;
        }

        public async Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO)
        {
            var validationResult = await loginUserDTOValidator.ValidateAsync(loginUserDTO);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.ToString());
            }

            var user = await userRepository.GetUserByEmailAsync(loginUserDTO.Email);

            var token = generateJWTClass.GenerateJWT(user);

            return token;
        }
        public async Task CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var validationResult = await createUserDTOValidator.ValidateAsync(createUserDTO);

            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.ToString());
            }

            var user = mapper.Map<User>(createUserDTO);
            var role = await roleRepository.GetRoleByNameAsync("user");

            user.UserRole = role;

            await userRepository.CreateAsync(user);
            await userRepository.SaveAsync();
        }
        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            var usersDTOs = mapper.Map<List<UserDTO>>(users);

            return usersDTOs;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var validationResult = await userDTOValidator.ValidateAsync(userDTO);

            if(!validationResult.IsValid)
            {
				throw new BadRequestException(validationResult.ToString());
			}

            var user = await userRepository.GetUserByEmailAsync(userDTO.Email);

            userRepository.Update(user);
            await userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            userRepository.Delete(user);
            await userRepository.SaveAsync();
        }
    }
}
