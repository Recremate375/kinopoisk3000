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
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IGenerateJWTService _generateJWTClass;

        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository,
            IMapper mapper, IGenerateJWTService generateJWTClass)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _generateJWTClass = generateJWTClass;
        }

        public async Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginUserDTO.Email)
                ?? throw new NotFoundException($"User with this email ({loginUserDTO.Email}) is not found.");

            var token = _generateJWTClass.GenerateJWT(user);

            return token;
        }

        public async Task CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            var role = await _roleRepository.GetRoleByNameAsync("user");

            user.UserRole = role;

            await _userRepository.CreateAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDTOs = _mapper.Map<List<UserDTO>>(users);

            return usersDTOs;
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(userDTO.Email) 
                ?? throw new NotFoundException($"User with email {userDTO.Email} is not fount.");

            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"User with Id ({id}) is not found");

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }
    }
}
