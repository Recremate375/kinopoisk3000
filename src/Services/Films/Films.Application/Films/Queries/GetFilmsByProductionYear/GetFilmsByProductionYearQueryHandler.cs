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

namespace Films.Application.Films.Queries.GetFilmsByProductionYear
{
	public class GetFilmsByProductionYearQueryHandler : IRequestHandler<GetFilmsByProductionYearQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository filmQueryRepository;
		private readonly IMapper mapper;

        public GetFilmsByProductionYearQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
        {
            this.filmQueryRepository = filmQueryRepository;
			this.mapper = mapper;
        }

        public async Task<List<FilmDTO>> Handle(GetFilmsByProductionYearQuery request, CancellationToken cancellationToken)
		{
			var films = await filmQueryRepository.GetFilmsByProductionYear(request.ProductionYear) ??
				throw new NotFoundException($"Films with {request.ProductionYear} production year not found.");
			var filmsDTO = mapper.Map<List<FilmDTO>>(films);

			return filmsDTO;
		}
	}
}
