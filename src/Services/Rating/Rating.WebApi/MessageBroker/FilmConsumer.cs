﻿using AutoMapper;
using MassTransit;
using Rating.Application.IRepositories;
using Rating.Domain.DTOs;
using Rating.Domain.Models;
using Rating.Domain.Enums;

namespace Rating.WebApi.MessageBroker
{
	public class FilmConsumer : IConsumer<FilmToBrokerDTO>
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IMapper _mapper;

		public FilmConsumer(IFilmRepository filmRepository, IMapper mapper)
		{
			_filmRepository = filmRepository;
			_mapper = mapper;
		}

		public async Task Consume(ConsumeContext<FilmToBrokerDTO> context)
		{
			var filmBrokerDto = context.Message;
			var film = _mapper.Map<Film>(filmBrokerDto);

			switch (filmBrokerDto.StateOfOperation)
			{
				case BrokerOpertaionsEnum.Create:
					await _filmRepository.CreateAsync(film);
					await _filmRepository.SaveAsync();
					break;
				case BrokerOpertaionsEnum.Update:
					_filmRepository.Update(film);
					await _filmRepository.SaveAsync();
					break;
				case BrokerOpertaionsEnum.Delete:
					_filmRepository.Delete(film);
					await _filmRepository.SaveAsync();
					break;
			}
		}
	}
}
