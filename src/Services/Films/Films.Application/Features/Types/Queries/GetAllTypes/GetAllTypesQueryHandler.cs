using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Types.Queries.GetAllTypes
{
    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, List<FilmTypeDTO>>
    {
        private readonly ITypeQueryRepository _typeQueryRepository;

        public GetAllTypesQueryHandler(ITypeQueryRepository typeQueryRepository)
        {
            _typeQueryRepository = typeQueryRepository;
        }

        public async Task<List<FilmTypeDTO>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _typeQueryRepository.GetAllAsync<FilmTypeDTO>()
                ?? throw new NotFoundException($"Types not found.");

            return types;
        }
    }
}
