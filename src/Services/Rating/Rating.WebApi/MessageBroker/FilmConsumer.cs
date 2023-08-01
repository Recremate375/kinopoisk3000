using AutoMapper;
using MassTransit;
using Newtonsoft.Json;
using Rating.Application.IRepositories;
using Rating.Domain.DTOs;
using Rating.Domain.Models;

namespace Rating.WebApi.MessageBroker
{
	public class FilmConsumer : IConsumer<CreateFilmDTO>
	{
		private readonly IFilmRepository _filmRepository;
		private readonly IMapper _mapper;

		public FilmConsumer(IFilmRepository filmRepository, IMapper mapper)
		{
			_filmRepository = filmRepository;
			_mapper = mapper;
		}

		public async Task Consume(ConsumeContext<CreateFilmDTO> context)
		{
			var jsonMessage = JsonConvert.SerializeObject(context.Message);
			var createFilmDto = JsonConvert.DeserializeObject<CreateFilmDTO>(jsonMessage);
			var film = _mapper.Map<Film>(createFilmDto);

			await _filmRepository.CreateAsync(film);
			await _filmRepository.SaveAsync();
		}
	}
}
