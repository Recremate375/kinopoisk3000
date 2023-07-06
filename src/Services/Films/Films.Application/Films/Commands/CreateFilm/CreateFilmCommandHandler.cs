using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Commands.CreateFilm
{
	public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Film>
	{
		private readonly IFilmCommandRepository filmCommandRepository;
		private readonly ITypeQueryRepository typeQueryRepository;
		private readonly IMapper mapper;

        public CreateFilmCommandHandler(IFilmCommandRepository filmCommandRepository, ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
			this.filmCommandRepository = filmCommandRepository;
			this.typeQueryRepository = typeQueryRepository;
			this.mapper = mapper;
        }

        public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
		{
			var type = await typeQueryRepository.GetTypeByNameAsync(request.CreateFilmDTO.Type.TypeName);
			var film = mapper.Map<Film>(request.CreateFilmDTO);
			film.Type = type;

			await filmCommandRepository.CreateAsync(film);
			await filmCommandRepository.SaveAsync();

			return film;
		}
	}
}
