using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Films.Queries.GetFilmsByType
{
	public class GetFilmsByTypeQueryHandler : IRequestHandler<GetFilmsByTypeQuery, List<FilmDTO>>
	{
		private readonly IFilmQueryRepository _filmQueryRepository;
		private readonly IMapper _mapper;

        public GetFilmsByTypeQueryHandler(IFilmQueryRepository filmQueryRepository, IMapper mapper)
        {
			_filmQueryRepository = filmQueryRepository;
			_mapper = mapper;
        }

        public async Task<List<FilmDTO>> Handle(GetFilmsByTypeQuery request, CancellationToken cancellationToken)
		{
			var type = _mapper.Map<Domain.Models.FilmType>(request.FilmTypeDTO);
			var films = await _filmQueryRepository.GetFilmsByTypeAsync(type) ?? throw new NotFoundException($"Films with {type.TypeName} type not found");
			var filmDTO = _mapper.Map<List<FilmDTO>>(films);

			return filmDTO;
		}
	}
}
