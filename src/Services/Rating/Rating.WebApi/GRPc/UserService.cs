using Grpc.Core;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.WebApi.Protos;

namespace Rating.WebApi.GRPc
{
	public class UserService : UserProtoService.UserProtoServiceBase
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public override async Task<Response> SendUserOperation(Request request, ServerCallContext context)
		{
			var user = new User() 
			{
				Login = request.UserOperation.Request.Login
			};

			switch (request.UserOperation.Operation)
			{
				case Operation.Create:
					await _userRepository.CreateAsync(user);

					break;
				case Operation.Update:
					_userRepository.Update(user);

					break;
				case Operation.Delete:
					_userRepository.Delete(user);

					break;
			}
			await _userRepository.SaveAsync();

			var response = new Response() { Message = "The operation was a success" };

			return response;
		}
	}
}
