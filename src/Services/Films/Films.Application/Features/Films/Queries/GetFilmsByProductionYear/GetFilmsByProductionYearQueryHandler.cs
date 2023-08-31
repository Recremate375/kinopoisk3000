using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Queries.GetFilmsByProductionYear
{
	public class GetFilmsByProductionYearQueryHandler : IRequestHandler<GetFilmsByProductionYearQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetFilmsByProductionYearQueryHandler> _logger;

		public GetFilmsByProductionYearQueryHandler(IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			ILogger<GetFilmsByProductionYearQueryHandler> logger)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<List<FilmDTO>> Handle(GetFilmsByProductionYearQuery request, CancellationToken cancellationToken)
		{
			var films = await _filmQueryRepository.GetFilmsByProductionYear(request.ProductionYear);
				
			if (films is null)
			{
				_logger.LogError($"Film with {request.ProductionYear} production year not found.");

				throw new NotFoundException($"Films with {request.ProductionYear} production year not found.");
			}

			var filmsDTO = _mapper.Map<List<FilmDTO>>(films);

			_logger.LogInformation($"Films was sccessfully received. ProductionYear: {request.ProductionYear}");

			return filmsDTO;
		}
	}
}
