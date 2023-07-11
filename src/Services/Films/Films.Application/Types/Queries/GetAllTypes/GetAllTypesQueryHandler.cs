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

namespace Films.Application.Types.Queries.GetAllTypes
{
	public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, List<FilmTypeDTO>>
	{
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly IMapper _mapper;

        public GetAllTypesQueryHandler(ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
			_typeQueryRepository = typeQueryRepository;
			_mapper = mapper;
        }

        public async Task<List<FilmTypeDTO>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await _typeQueryRepository.GetAllAsync() ?? throw new NotFoundException($"Types not found.");
			var typesDTO = _mapper.Map<List<FilmTypeDTO>>(types);
				
			return typesDTO;
		}
	}
}
