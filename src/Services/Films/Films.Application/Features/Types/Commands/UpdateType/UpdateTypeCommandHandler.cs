using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Commands.UpdateType
{
	public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand>
	{
		private readonly ITypeCommandRepository _typeCommandRepository;
		private readonly ITypeQueryRepository _typeQueryRepository;
		private readonly ILogger<UpdateTypeCommandHandler> _logger;

		public UpdateTypeCommandHandler(ITypeCommandRepository typeCommandRepository,
			ITypeQueryRepository typeQueryRepository,
			ILogger<UpdateTypeCommandHandler> logger)
		{
			_typeCommandRepository = typeCommandRepository;
			_typeQueryRepository = typeQueryRepository;
		}

		public async Task Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await _typeQueryRepository.GetByIdAsync(request.Type.Id);
			type.TypeName = request.Type.TypeName;

			if (type is null)
			{
				_logger.LogError($"Invalid type model");

				throw new NotFoundException($"Invalid type model");
			}

			_typeCommandRepository.Update(type);
			await _typeCommandRepository.SaveAsync();

			_logger.LogInformation($"Type {type.TypeName} was successfully updated.");
		}
	}
}
