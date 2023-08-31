using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Queries.GetFilmByName
{
	public class GetFilmByNameQueryHandler : IRequestHandler<GetFilmByNameQuery, FilmDTO>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetFilmByNameQueryHandler> _logger;

		public GetFilmByNameQueryHandler(IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			ILogger<GetFilmByNameQueryHandler> logger)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_logger = logger;
		}
		public async Task<FilmDTO> Handle(GetFilmByNameQuery request, CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetFilmByNameAsync(request.FilmName);
				
			if (film is null)
			{
				_logger.LogError($"Film with name {request.FilmName} not found.");

				throw new NotFoundException($"Film with name ({request.FilmName}) not found!");
			}

			var filmDTO = _mapper.Map<FilmDTO>(film);

			_logger.LogInformation($"Film was successfully received. FilmName: {request.FilmName}");

			return filmDTO;
		}
	}
}
