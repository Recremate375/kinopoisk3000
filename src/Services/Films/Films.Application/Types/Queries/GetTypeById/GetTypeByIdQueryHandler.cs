using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Queries.GetTypeById
{
	public class GetTypeByIdQueryHandler : IRequestHandler<GetTypeByIdQuery, FilmTypeDTO>
	{
		private readonly ITypeQueryRepository typeQueryRepository;
		private readonly IMapper mapper;

        public GetTypeByIdQueryHandler(ITypeQueryRepository typeQueryRepository, IMapper mapper)
        {
			this.typeQueryRepository = typeQueryRepository;
			this.mapper = mapper;
        }

        public async Task<FilmTypeDTO> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
		{
			var type = await typeQueryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Type not Found!");
			var typeDTO = mapper.Map<FilmTypeDTO>(type);

			return typeDTO;
		}
	}
}
