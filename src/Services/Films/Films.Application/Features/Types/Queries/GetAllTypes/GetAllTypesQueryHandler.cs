using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Queries.GetAllTypes
{
	public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, List<FilmTypeDTO>>
	{
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly ILogger<GetAllTypesQueryHandler> _logger;

		public GetAllTypesQueryHandler(ITypeQueryRepository typeQueryRepository,
			ILogger<GetAllTypesQueryHandler> logger)
		{
			_typeQueryRepository = typeQueryRepository;
			_logger = logger;
		}

		public async Task<List<FilmTypeDTO>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await _typeQueryRepository.GetAllAsync<FilmTypeDTO>();

			if (types is null)
			{
				_logger.LogError($"Types not found.");

				throw new NotFoundException($"Types not found.");
			}

			_logger.LogInformation($"Types was successfully received.");

			return types;
		}
	}
}
