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

namespace Films.Application.Films.Queries.GetFilmById
{
	public class GetFilmByIdQueryHandler : IRequestHandler<GetFilmByIdQuery, FilmDTO>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;

        public GetFilmByIdQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
        {
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
        }

        public async Task<FilmDTO> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
		{
			var film = await _filmQueryRepository.GetByIdAsync(request.FilmId) ?? throw new NotFoundException($"Film with this ID not found");
			var filmDTO = _mapper.Map<FilmDTO>(film);

			return filmDTO;
		}
	}
}
