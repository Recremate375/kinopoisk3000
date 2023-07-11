using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Queries.GetAllFilms
{
	public class GetFilmsQueryHandler : IRequestHandler<GetFilmsQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;

		public GetFilmsQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
		}

		public async Task<List<FilmDTO>> Handle(GetFilmsQuery request, CancellationToken cancellationToken)
		{
			var films = await _filmQueryRepository.GetAllAsync() ?? throw new NotFoundException($"Films not found");
			var filmsDTO = _mapper.Map<List<FilmDTO>>(films);

			return filmsDTO;
		}
	}
}
