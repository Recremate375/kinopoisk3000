using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.UpdateType
{
	public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand>
	{
		private readonly ITypeCommandRepository typeCommandRepository;
		private readonly ITypeQueryRepository typeQueryRepository;

        public UpdateTypeCommandHandler(ITypeCommandRepository typeCommandRepository, ITypeQueryRepository typeQueryRepository)
        {
			this.typeCommandRepository = typeCommandRepository;
			this.typeQueryRepository = typeQueryRepository;
        }

        public async Task Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await typeQueryRepository.GetByIdAsync(request.Type.FilmTypeId) ?? throw new NotFoundException($"Invalid type model");
			type.TypeName = request.Type.TypeName;

			typeCommandRepository.Update(type);
			await typeCommandRepository.SaveAsync();
		}
	}
}
