using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using Films.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Commands.UpdateFilm
{
	public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand>
	{
		private readonly IFilmCommandRepository filmCommandRepository;
		private readonly IFilmQueryRepository filmQueryRepository;
		private readonly ITypeQueryRepository typeQueryRepository;
		private readonly IMapper mapper;

		public UpdateFilmCommandHandler(IFilmCommandRepository filmCommandRepository,
			IFilmQueryRepository filmQueryRepository, IMapper mapper, ITypeQueryRepository typeQueryRepository)
		{
			this.filmCommandRepository = filmCommandRepository;
			this.filmQueryRepository = filmQueryRepository;
			this.mapper = mapper;
			this.typeQueryRepository = typeQueryRepository;
		}

		public async Task Handle(UpdateFilmCommand request, 
			CancellationToken cancellationToken)
		{
			var type = await typeQueryRepository.GetTypeByNameAsync(request.UpdateFilm.Type.TypeName);
			var entity = await filmQueryRepository.GetByIdAsync(request.FilmId) ?? throw new NotFoundException($"Entity {request.UpdateFilm.FilmName} not found!");
			entity.Type = type;

			entity = mapper.Map<Film>(request.UpdateFilm);

			filmCommandRepository.Update(entity);
			await filmCommandRepository.SaveAsync();
		}
	}
}
