using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetFilmsByProductionYear
{
	public class GetFilmsByProductionYearQueryHandler : IRequestHandler<GetFilmsByProductionYearQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;

		public GetFilmsByProductionYearQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
		{
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
		}

		public async Task<List<FilmDTO>> Handle(GetFilmsByProductionYearQuery request, CancellationToken cancellationToken)
		{
			var films = await _filmQueryRepository.GetFilmsByProductionYear(request.ProductionYear) ??
				throw new NotFoundException($"Films with {request.ProductionYear} production year not found.");
			var filmsDTO = _mapper.Map<List<FilmDTO>>(films);

			return filmsDTO;
		}
	}
}
