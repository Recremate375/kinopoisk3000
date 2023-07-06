using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.DeleteType
{
	public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
	{
		private readonly ITypeCommandRepository typeCommandRepository;
		private readonly ITypeQueryRepository typeQueryRepository;

        public DeleteTypeCommandHandler(ITypeCommandRepository typeCommandRepository, ITypeQueryRepository typeQueryRepository)
        {
			this.typeCommandRepository = typeCommandRepository;
			this.typeQueryRepository = typeQueryRepository;
        }

        public async Task Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await typeQueryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException($"Type with {request.Id} Id not found");

			typeCommandRepository.Delete(type);
		}
	}
}
