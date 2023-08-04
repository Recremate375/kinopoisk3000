﻿using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using Films.Domain.Models;
using MassTransit;
using MediatR;

namespace Films.Application.Features.Films.Commands.UpdateFilm
{
	public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;
		private readonly IPublishEndpoint _publishEndpoint;

		public UpdateFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			IPublishEndpoint publishEndpoint)
		{
			_filmCommandRepository = filmCommandRepository;
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_publishEndpoint = publishEndpoint;
		}

		public async Task Handle(UpdateFilmCommand request,
			CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetByIdAsync(request.FilmId)
				?? throw new NotFoundException($"Entity {request.UpdateFilm.FilmName} not found!");

			film = _mapper.Map<Film>(request.UpdateFilm);

			_filmCommandRepository.Update(film);
			await _filmCommandRepository.SaveAsync();

			var filmToBroker = _mapper.Map<FilmDtoForBroker>(film);
			filmToBroker.TypeOfBrokerOperation = Domain.Enums.BrokerOperationsEnum.Update;

			await _publishEndpoint.Publish(filmToBroker);
		}
	}
}
