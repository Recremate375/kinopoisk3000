using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MassTransit;
using MediatR;

namespace Films.Application.Features.Films.Commands.DeleteFilm
{
	public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IPublishEndpoint _publishEndpoint;
		private readonly IMapper _mapper;

		public DeleteFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IFilmQueryRepository filmQueryRepository,
			IMapper mapper,
			IPublishEndpoint  publishEndpoint)
		{
			_filmCommandRepository = filmCommandRepository;
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
			_publishEndpoint = publishEndpoint;
		}

		public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetByIdAsync(request.Id)
				?? throw new NotFoundException($"Entity with number {request.Id} not found!");

			_filmCommandRepository.Delete(film);
			await _filmCommandRepository.SaveAsync();

			var filmToBroker = _mapper.Map<FilmDtoForBroker>(film);
			filmToBroker.TypeOfBrokerOperation = "Delete";
			
			await _publishEndpoint.Publish(filmToBroker);
		}

	}
}
