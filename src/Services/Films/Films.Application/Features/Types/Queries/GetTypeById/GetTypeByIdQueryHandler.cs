using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Queries.GetTypeById
{
	public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQuery, FilmTypeDTO>
	{
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetTypeByIdQueryHandler> _logger;

		public GetTypeByIdQueryHandler(ITypeQueryRepository typeQueryRepository,
			IMapper mapper,
			ILogger<GetTypeByIdQueryHandler> logger)
		{
			_typeQueryRepository = typeQueryRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<FilmTypeDTO> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
		{
			var type = await _typeQueryRepository.GetByIdAsync(request.Id);

			if (type is null)
			{
				_logger.LogError($"Type not found. Id: {request.Id}");

				throw new NotFoundException($"Type not Found!");
			}

			var typeDTO = _mapper.Map<FilmTypeDTO>(type);

			_logger.LogInformation($"Type was successfully received. Id: {type.Id}");

			return typeDTO;
		}
	}
}
