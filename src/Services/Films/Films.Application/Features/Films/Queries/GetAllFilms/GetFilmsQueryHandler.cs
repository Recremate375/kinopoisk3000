using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Queries.GetAllFilms
{
	public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly ILogger<GetFilmsQueryHandler> _logger;

		public GetFilmsQueryHandler(IFilmQueryRepository filmQueryRepository,
			ILogger<GetFilmsQueryHandler> logger)
		{
			_filmQueryRepository = filmQueryRepository;
			_logger = logger;
		}

		public async Task<List<FilmDTO>> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
		{
			var films = await _filmQueryRepository.GetAllAsync<FilmDTO>();

			if (films is null)
			{
				_logger.LogError($"Films not found.");

				throw new NotFoundException($"Films not found");
			}

			_logger.LogInformation("All film were successfully received. Count:{Count}", films.Count);

			return films;
		}
	}
}
