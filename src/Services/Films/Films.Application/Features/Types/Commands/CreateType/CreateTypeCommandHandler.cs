using AutoMapper;
using Films.Application.Repositories.Commands;
using Films.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Films.Application.Features.Types.Commands.CreateType
{
	public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, int>
	{
		private readonly ITypeCommandRepository _typeCommandRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<CreateTypeCommandHandler> _logger;

		public CreateTypeCommandHandler(ITypeCommandRepository typeCommandRepository,
			IMapper mapper,
			ILogger<CreateTypeCommandHandler> logger)
		{
			_typeCommandRepository = typeCommandRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
		{
			var type = _mapper.Map<FilmType>(request.Type);

			await _typeCommandRepository.CreateAsync(type);
			await _typeCommandRepository.SaveAsync();

			_logger.LogInformation($"FilmType was successfully created. Id: {type.Id}");

			return type.Id;
		}
	}
}
