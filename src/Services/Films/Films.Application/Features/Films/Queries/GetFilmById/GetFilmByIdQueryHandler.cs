using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Queries.GetFilmById
{
	public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDTO>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<GetFilmByIdQueryHandler> _logger;

		public GetFilmByIdQueryHandler(IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			ILogger<GetFilmByIdQueryHandler> logger)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<FilmDTO> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetByIdAsync(request.FilmId);

			if (film is null)
			{
				_logger.LogError($"Film with ID {request.FilmId} not found.");

				throw new NotFoundException($"Film with this ID not found");
			}

			var filmDTO = _mapper.Map<FilmDTO>(film);

			_logger.LogInformation($"Film was successfully received. ID: {film.Id}");

			return filmDTO;
		}
	}
}
