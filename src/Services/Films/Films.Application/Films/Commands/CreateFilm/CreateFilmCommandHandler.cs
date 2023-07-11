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
		private readonly IFilmCommandRepository _filmCommandRepository;
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly IMapper _mapper;

        public CreateFilmCommandHandler(IFilmCommandRepository filmCommandRepository, ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
			_filmCommandRepository = filmCommandRepository;
			_typeQueryRepository = typeQueryRepository;
			_mapper = mapper;
        }

        public async Task<Film> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
		{
			var type = await _typeQueryRepository.GetTypeByNameAsync(request.CreateFilmDTO.Type.TypeName);
			var film = _mapper.Map<Film>(request.CreateFilmDTO);
			film.Type = type;

			await _filmCommandRepository.CreateAsync(film);
			await _filmCommandRepository.SaveAsync();

			return film;
		}
	}
}
