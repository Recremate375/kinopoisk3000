using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Commands.DeleteFilm
{
	public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly IMapper _mapper;
		private readonly ILogger<DeleteFilmCommandHandler> _logger;

		public DeleteFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			IPublishEndpoint  publishEndpoint,
			ILogger<DeleteFilmCommandHandler> logger)
		{
			_filmCommandRepository = filmCommandRepository;
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_publishEndpoint = publishEndpoint;
			_logger = logger;
		}

		public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetByIdAsync(request.Id);

			if (film is null)
			{
				_logger.LogError($"Film with number {request.Id} not found.");

				throw new NotFoundException($"Film with number {request.Id} not found!");
			}

			_filmCommandRepository.Delete(film);
			await _filmCommandRepository.SaveAsync();

			var filmToBroker = _mapper.Map<FilmDtoForBroker>(film);
			filmToBroker.TypeOfBrokerOperation = Domain.Enums.BrokerOperationsEnum.Delete;
			
			await _publishEndpoint.Publish(filmToBroker);

			_logger.LogInformation($"Film {film.FilmName} was successfully deleted.");
		}

	}
}
