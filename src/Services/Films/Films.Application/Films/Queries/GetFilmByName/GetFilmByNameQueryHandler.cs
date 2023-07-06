using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Queries.GetFilmByName
{
	public class GetFilmByNameQueryHandler : IRequestHandler<GetFilmByNameQuery, FilmDTO>
	{
		private readonly IFilmQueryRepository filmQueryRepository;
		private readonly IMapper mapper;

        public GetFilmByNameQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
        {
            this.filmQueryRepository = filmQueryRepository;
			this.mapper = mapper;
        }
        public async Task<FilmDTO> Handle(GetFilmByNameQuery request, CancellationToken cancellationToken)
		{
			var film = await filmQueryRepository.GetFilmByNameAsync(request.FilmName) ??
				throw new NotFoundException($"Film with name ({request.FilmName}) not found!");
			var filmDTO = mapper.Map<FilmDTO>(film);

			return filmDTO;
		}
	}
}
