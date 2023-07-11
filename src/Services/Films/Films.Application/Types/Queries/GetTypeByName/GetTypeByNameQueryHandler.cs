using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Queries.GetTypeByName
{
	public class GetTypeByNameQueryHandler : IRequestHandler<GetTypeByNameQuery, FilmTypeDTO>
	{
		private readonly ITypeQueryRepository _repository;
		private readonly IMapper _mapper;

        public GetTypeByNameQueryHandler(ITypeQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
			_mapper = mapper;
        }

        public async Task<FilmTypeDTO> Handle(GetTypeByNameQuery request, CancellationToken cancellationToken)
		{
			var type = await _repository.GetTypeByNameAsync(request.TypeName);
			var typeDTO = _mapper.Map<FilmTypeDTO>(type);

			return typeDTO;
		}
	}
}
