using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Films.Queries.GetFilmsByType
{
	public class GetFilmsByTypeQueryHandler : IRequestHandler<GetFilmsByTypeQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository filmQueryRepository;
		private readonly IMapper mapper;

        public GetFilmsByTypeQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
        {
			this.filmQueryRepository = filmQueryRepository;
			this.mapper = mapper;
        }

        public async Task<List<FilmDTO>> Handle(GetFilmsByTypeQuery request, CancellationToken cancellationToken)
		{
			var type = mapper.Map<Domain.Models.FilmType>(request.FilmTypeDTO);
			var films = await filmQueryRepository.GetFilmsByTypeAsync(type) ?? throw new NotFoundException($"Films with {type.TypeName} type not found");
			var filmDTO = mapper.Map<List<FilmDTO>>(films);

			return filmDTO;
		}
	}
}
