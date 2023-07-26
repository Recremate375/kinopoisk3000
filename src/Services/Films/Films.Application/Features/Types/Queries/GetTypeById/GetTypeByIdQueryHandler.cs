using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Types.Queries.GetTypeById
{
    public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQuery, FilmTypeDTO>
    {
        private readonly ITypeQueryRepository _typeQueryRepository;
        private readonly IMapper _mapper;

        public GetTypeByIdQueryHandler(ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
            _typeQueryRepository = typeQueryRepository;
            _mapper = mapper;
        }

        public async Task<FilmTypeDTO> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var type = await _typeQueryRepository.GetByIdAsync(request.Id) 
                ?? throw new NotFoundException($"Type not Found!");
            var typeDTO = _mapper.Map<FilmTypeDTO>(type);

            return typeDTO;
        }
    }
}
