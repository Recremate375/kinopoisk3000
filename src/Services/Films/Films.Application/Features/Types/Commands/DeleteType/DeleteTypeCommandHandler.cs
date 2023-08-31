using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Commands.DeleteType
{
	public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
	{
		private readonly ITypeCommandRepository _typeCommandRepository;
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly ILogger<DeleteTypeCommandHandler> _logger;

		public DeleteTypeCommandHandler(ITypeCommandRepository typeCommandRepository,
			ITypeQueryRepository typeQueryRepository,
			ILogger<DeleteTypeCommandHandler> logger)
		{
			_typeCommandRepository = typeCommandRepository;
			_typeQueryRepository = typeQueryRepository;
			_logger = logger;
		}

		public async Task Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await _typeQueryRepository.GetByIdAsync(request.Id);

			if (type is null)
			{
				_logger.LogError($"Type with {request.Id} Id not found.");

				throw new NotFoundException($"Type with {request.Id} Id not found");
			}

			_typeCommandRepository.Delete(type);
			await _typeCommandRepository.SaveAsync();

			_logger.LogInformation($"Type {type.TypeName} was successfully deleted.");
		}
	}
}
