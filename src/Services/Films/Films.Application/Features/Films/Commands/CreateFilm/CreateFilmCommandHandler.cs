using AutoMapper;
using Films.Application.Hubs;
using Films.Application.Hubs.IHubs;
using Films.Application.Repositories.Commands;
using Films.Domain.DTO;
using Films.Domain.Enums;
using Films.Domain.Models;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Films.Application.Features.Films.Commands.CreateFilm
{
	public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IMapper _mapper;
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly IHubContext<NotificationHub> _notificationHub;

		public CreateFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IMapper mapper,
			IPublishEndpoint publishEndpoint,
			IHubContext<NotificationHub> notificationHub)
		{
			_filmCommandRepository = filmCommandRepository;
			_mapper = mapper;
			_publishEndpoint = publishEndpoint;
			_notificationHub = notificationHub;
		}

		public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
		{
			var film = _mapper.Map<Film>(request.CreateFilmDTO);

			await _filmCommandRepository.CreateAsync(film);
			await _filmCommandRepository.SaveAsync();

			var filmToBroker = _mapper.Map<FilmDtoForBroker>(film);
			filmToBroker.TypeOfBrokerOperation = BrokerOperationsEnum.Create;

			await _publishEndpoint.Publish(filmToBroker);

			await _notificationHub.Clients.All.SendAsync($"Film {film.FilmName} has been added to the site!");

			return film;
		}
	}
}
