using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.CreateType
{
	public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, int>
	{
		private readonly ITypeCommandRepository _typeCommandRepository;
		private readonly IMapper _mapper;

        public CreateTypeCommandHandler(ITypeCommandRepository typeCommandRepository, IMapper mapper)
        {
			_typeCommandRepository = typeCommandRepository;
			_mapper = mapper;
        }

        public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
		{
			var type = _mapper.Map<FilmType>(request.Type);

			await _typeCommandRepository.CreateAsync(type);
			await _typeCommandRepository.SaveAsync();

			return type.FilmTypeId;
		}
	}
}
