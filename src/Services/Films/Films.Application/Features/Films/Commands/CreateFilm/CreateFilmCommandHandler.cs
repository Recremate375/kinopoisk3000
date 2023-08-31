using AutoMapper;
using Films.Application.Hubs;
using Films.Application.Hubs.IHubs;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.MongoRepositories.Commands;
using Films.Domain.DTO;
using Films.Domain.Enums;
using Films.Domain.Models;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Films.Commands.CreateFilm
{
	public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IMapper _mapper;
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly IHubContext<NotificationHub, INotificationHub> _notificationHub;
		private readonly ILogger<CreateFilmCommandHandler> _logger;
		private readonly IFilmMongoCommandRepository _filmMongoCommandRepository;

		public CreateFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IMapper mapper,
			IPublishEndpoint publishEndpoint,
			IHubContext<NotificationHub,
			INotificationHub> notificationHub,
			ILogger<CreateFilmCommandHandler> logger,
			IFilmMongoCommandRepository filmMongoCommandRepository)
		{
			_filmCommandRepository = filmCommandRepository;
			_mapper = mapper;
			_publishEndpoint = publishEndpoint;
			_notificationHub = notificationHub;
			_logger = logger;
			_filmMongoCommandRepository = filmMongoCommandRepository;
		}

		public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
		{
			var film = _mapper.Map<Film>(request.CreateFilmDTO);

			await _filmCommandRepository.CreateAsync(film);
			await _filmCommandRepository.SaveAsync();

			if (request.file != null)
			{
				FilmToMongo filmToMongo = new();
				using (var binaryReader = new BinaryReader(request.file.OpenReadStream()))
				{
					filmToMongo.PosterImage = binaryReader.ReadBytes((int)request.file.Length);
				}
				filmToMongo.FilmName = film.FilmName;

				await _filmMongoCommandRepository.CreateAsync(filmToMongo);
			}

			var filmToBroker = _mapper.Map<FilmDtoForBroker>(film);
			filmToBroker.TypeOfBrokerOperation = BrokerOperationsEnum.Create;

			_logger.LogInformation($"Film {film.FilmName} successully created.");

			await _publishEndpoint.Publish(filmToBroker);

			await _notificationHub.Clients.All.SendMessage($"Film {film.FilmName} has been added to the site!");

			return film;
		}
	}
}
