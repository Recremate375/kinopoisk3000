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
		private readonly ITypeCommandRepository typeCommandRepository;
		private readonly IMapper mapper;

        public CreateTypeCommandHandler(ITypeCommandRepository typeCommandRepository, IMapper mapper)
        {
			this.typeCommandRepository = typeCommandRepository;
			this.mapper = mapper;
        }

        public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
		{
			var type = mapper.Map<Domain.Models.FilmType>(request.Type);

			await typeCommandRepository.CreateAsync(type);
			await typeCommandRepository.SaveAsync();

			return type.FilmTypeId;
		}
	}
}
