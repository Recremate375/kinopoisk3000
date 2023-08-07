using AutoMapper;
using Grpc.Core;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.WebApi.Protos;

namespace Rating.WebApi.GRPc
{
	public class UserService : UserProtoService.UserProtoServiceBase
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IMapper _mapper;

		public UserService(IFilmRepository filmRepository,
			IMapper mapper)
		{
			_filmRepository = filmRepository;
			_mapper = mapper;
		}

		public override async Task<Response> SendUserOperation(Request request, ServerCallContext context)
		{
			var film = _mapper.Map<Film>(request.UserOperation.Request);

			switch (request.UserOperation.Operation)
			{
				case Operation.Create:
					await _filmRepository.CreateAsync(film);

					break;
				case Operation.Update:
					_filmRepository.Update(film);

					break;
				case Operation.Delete:
					_filmRepository.Delete(film);

					break;
			}
			await _filmRepository.SaveAsync();

			return new Response();
		}
	}
}
