using AutoMapper;
using Grpc.Net.Client;
using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Exceptions;
using Identity.Domain.Models;
using Identity.WebApi.Protos;
using Microsoft.Extensions.Logging;

namespace Identity.Application.Features
{
	public class UsersService : IUsersService
	{
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IGenerateJWTService _generateJWTClass;
        private readonly UserProtoService.UserProtoServiceClient _client;
		private readonly ILogger<UsersService> _logger;

        public UsersService(IUserRepository userRepository, IRoleRepository roleRepository,
            IMapper mapper, IGenerateJWTService generateJWTClass, UserProtoService.UserProtoServiceClient client,
			ILogger<UsersService> logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _generateJWTClass = generateJWTClass;
            _client = client;
			_logger = logger;
        }

		public async Task<string> GetAuthenticationTokenAsync(LoginUserDTO loginUserDTO)
		{
			var user = await _userRepository.GetUserByEmailAsync(loginUserDTO.Email); 

			if (user is null)
			{
				_logger.LogError($"User with this email ({loginUserDTO.Email}) is not found.");

				throw new NotFoundException($"User with this email ({loginUserDTO.Email}) is not found.");
			}

			var token = _generateJWTClass.GenerateJWT(user);

			_logger.LogInformation($"Token {token} was successfully received.");

			return token;
		}

        public async Task<User?> CreateUserAsync(CreateUserDTO createUserDTO)
        {
            var user = _mapper.Map<User>(createUserDTO);
			var role = await _roleRepository.GetRoleByNameAsync("user");

			if (role is null)
			{
				_logger.LogError("Role is not found.");

				throw new NotFoundException("Role is not found.");
			}

            user.RoleId = role.Id;

			await _userRepository.CreateAsync(user);
			await _userRepository.SaveAsync();

			await SendDataToRatingServiceAsync(user, Operation.Create);

			_logger.LogInformation($"User {user.Id} was successfully created.");

			return user;
        }

		public async Task<List<UserDTO>> GetAllUsersAsync()
		{
			var users = await _userRepository.GetAllAsync();
			var usersDTOs = _mapper.Map<List<UserDTO>>(users);

			_logger.LogInformation("All users was successfully received.");

			return usersDTOs;
		}

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
			var user = await _userRepository.GetUserByEmailAsync(userDTO.Email);

			if (user is null)
			{
				_logger.LogError($"User with email {userDTO.Email} is not found.");

				throw new NotFoundException($"User with email {userDTO.Email} is not found.");
			}

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

			_logger.LogInformation($"User was successfully updated. ID: {user.Id}");

			await SendDataToRatingServiceAsync(user, Operation.Update);
		}

		public async Task DeleteUserAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			if (user is null)
			{
				_logger.LogError($"User with Id ({id}) is not found");

				throw new NotFoundException($"User with Id ({id}) is not found");
			}

			_userRepository.Delete(user);
            await _userRepository.SaveAsync();

			await SendDataToRatingServiceAsync(user, Operation.Delete);

			_logger.LogInformation($"User was successfully deleted. ID: {user.Id}");
		}

		public async Task<UserDTO?> GetUserByIdAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			if (user is null)
			{
				_logger.LogError($"User with Id ({id}) is not found.");

				throw new NotFoundException($"User with Id ({id}) is not found.");
			}

			var userDTO = _mapper.Map<UserDTO>(user);

			_logger.LogInformation("All users was successfully received.");

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

			_logger.LogInformation("Information was successfully received.");
		}
	}
}
