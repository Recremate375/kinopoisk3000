using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Commands.DeleteFilm
{
	public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand>
	{
		private readonly IFilmCommandRepository filmCommandRepository;
		private readonly IFilmQueryRepository filmQueryRepository;

        public DeleteFilmCommandHandler(IFilmCommandRepository filmCommandRepository, IFilmQueryRepository filmQueryRepository)
        {
			this.filmCommandRepository = filmCommandRepository;
			this.filmQueryRepository = filmQueryRepository;
        }

        public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
		{
			var entity = await filmQueryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Entity with number {request.Id} not found!");

			filmCommandRepository.Delete(entity);
			await filmCommandRepository.SaveAsync();
		}

	}
}
