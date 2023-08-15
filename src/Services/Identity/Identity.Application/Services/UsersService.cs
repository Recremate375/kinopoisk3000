using AutoMapper;
using Grpc.Net.Client;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;
using Identity.WebApi.Protos;

namespace Identity.Application.Features
{
	public class UsersService : IUsersService
	{
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IGenerateJWTService _generateJWTClass;
        private readonly UserProtoService.UserProtoServiceClient _client;

        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository,
            IMapper mapper, IGenerateJWTService generateJWTClass, UserProtoService.UserProtoServiceClient client)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _generateJWTClass = generateJWTClass;
            _client = client;
        }

		public async Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO)
		{
			var user = await _userRepository.GetUserByEmailAsync(loginUserDTO.Email)
				?? throw new NotFoundException($"User with this email ({loginUserDTO.Email}) is not found.");

			var token = _generateJWTClass.GenerateJWT(user);

			return token;
		}

        public async Task<User?> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
            var role = await _roleRepository.GetRoleByNameAsync("user") 
                ?? throw new NotFoundException("Role is not found.");

            user.RoleId = role.Id;

			await _userRepository.CreateAsync(user);
			await _userRepository.SaveAsync();

			await SendDataToRatingServiceAsync(user, Operation.Create);

			return user;
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
                ?? throw new NotFoundException($"User with email {userDTO.Email} is not found.");

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

			await SendDataToRatingServiceAsync(user, Operation.Update);
		}

		public async Task DeleteUserAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id)
				?? throw new NotFoundException($"User with Id ({id}) is not found");

            _userRepository.Delete(user);
            await _userRepository.SaveAsync();

			await SendDataToRatingServiceAsync(user, Operation.Delete);
		}

		public async Task<UserDTO?> GetUserByIdAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id)
				?? throw new NotFoundException($"User with Id ({id}) is not found.");
			var userDTO = _mapper.Map<UserDTO>(user);

			return userDTO;
		}

		private async Task SendDataToRatingServiceAsync(User user, Operation operation)
		{
			await _client.SendUserOperationAsync(new Request
			{
				UserOperation = new GrpcUserOperationModel
				{
					Operation = operation,
					ThisRequest = new()
					{
						Id = user.Id,
						Login = user.Login
					},
				}
			});
		}
	}
}
