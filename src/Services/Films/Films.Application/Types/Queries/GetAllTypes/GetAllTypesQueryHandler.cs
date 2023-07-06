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
		private readonly ITypeQueryRepository typeQueryRepository;
		private readonly IMapper mapper;

        public GetAllTypesQueryHandler(ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
			this.typeQueryRepository = typeQueryRepository;
			this.mapper = mapper;
        }

        public async Task<List<FilmTypeDTO>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await typeQueryRepository.GetAllAsync() ?? throw new NotFoundException($"Types not found.");
			var typesDTO = mapper.Map<List<FilmTypeDTO>>(types);
				
			return typesDTO;
		}
	}
}
