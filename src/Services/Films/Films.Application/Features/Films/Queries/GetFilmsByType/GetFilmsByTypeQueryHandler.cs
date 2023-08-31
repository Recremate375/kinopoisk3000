using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Queries.GetFilmsByType
{
	public class GetFilmsByTypeQueryHandler : IRequestHandler<GetFilmsByTypeQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetFilmsByTypeQueryHandler> _logger;

		public GetFilmsByTypeQueryHandler(IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			ILogger<GetFilmsByTypeQueryHandler> logger)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<List<FilmDTO>> Handle(GetFilmsByTypeQuery request, CancellationToken cancellationToken)
		{
			var films = await _filmQueryRepository.GetFilmsByTypeIdAsync(request.FilmTypeDTO.Id);
				
			if (films is null)
			{
				_logger.LogError($"Films with {request.FilmTypeDTO.TypeName} type not found");

				throw new NotFoundException($"Films with {request.FilmTypeDTO.TypeName} type not found");
			}

			var filmDTO = _mapper.Map<List<FilmDTO>>(films);

			_logger.LogInformation($"Films was successfully received. FilmType: {request.FilmTypeDTO.TypeName}");

			return filmDTO;
		}
	}
}
