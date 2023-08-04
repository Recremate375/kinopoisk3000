using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Types.Commands.DeleteType
{
	public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
	{
		private readonly ITypeCommandRepository _typeCommandRepository;
		private readonly ITypeQueryRepository _typeQueryRepository;

		public DeleteTypeCommandHandler(ITypeCommandRepository typeCommandRepository, ITypeQueryRepository typeQueryRepository)
		{
			_typeCommandRepository = typeCommandRepository;
			_typeQueryRepository = typeQueryRepository;
		}

		public async Task Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await _typeQueryRepository.GetByIdAsync(request.Id)
				?? throw new NotFoundException($"Type with {request.Id} Id not found");

			_typeCommandRepository.Delete(type);
			await _typeCommandRepository.SaveAsync();
		}
	}
}
