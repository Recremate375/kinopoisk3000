using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Films.Commands.DeleteFilm
{
	public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand>
	{
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly IFilmQueryRepository _filmQueryRepository;

		public DeleteFilmCommandHandler(IFilmCommandRepository filmCommandRepository, IFilmQueryRepository filmQueryRepository)
		{
			_filmCommandRepository = filmCommandRepository;
			_filmQueryRepository = filmQueryRepository;
		}

		public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
		{
			var entity = await _filmQueryRepository.GetByIdAsync(request.Id)
				?? throw new NotFoundException($"Entity with number {request.Id} not found!");

			_filmCommandRepository.Delete(entity);
			await _filmCommandRepository.SaveAsync();
		}

	}
}
