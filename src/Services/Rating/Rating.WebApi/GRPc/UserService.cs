using AutoMapper;
using Grpc.Core;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.WebApi.Protos;

namespace Rating.WebApi.GRPc
{
	public class UserService : UserProtoService.UserProtoServiceBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository,
			IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public override async Task<Response> SendUserOperation(Request request, ServerCallContext context)
		{
			var user = new User() 
			{
				//Id = request.UserOperation.Request.Id,
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


			return new Response();
		}
	}
}
