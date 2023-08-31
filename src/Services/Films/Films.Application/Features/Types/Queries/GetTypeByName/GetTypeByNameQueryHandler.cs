using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Queries.GetTypeByName
{
	public class GetTypeByNameQueryHandler : IRequestHandler<GetTypeByNameQuery, FilmTypeDTO>
	{
		private readonly ITypeQueryRepository _repository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetTypeByNameQueryHandler> _logger;

		public GetTypeByNameQueryHandler(ITypeQueryRepository repository,
			IMapper mapper,
			ILogger<GetTypeByNameQueryHandler> logger)
		{
			_repository = repository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<FilmTypeDTO> Handle(GetTypeByNameQuery request, CancellationToken cancellationToken)
		{
			var type = await _repository.GetTypeByNameAsync(request.TypeName);

			if (type is null)
			{
				_logger.LogError($"Type {request.TypeName} is not found.");

				throw new NotFoundException($"Type {request.TypeName} is not found.");
			}

			var typeDTO = _mapper.Map<FilmTypeDTO>(type);

			_logger.LogInformation($"Type was successfully received. Name: {type.TypeName}");

			return typeDTO;
		}
	}
}
