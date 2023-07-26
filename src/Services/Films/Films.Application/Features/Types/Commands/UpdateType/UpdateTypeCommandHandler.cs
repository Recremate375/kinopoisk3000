using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Exceptions;
using MediatR;

namespace Films.Application.Features.Types.Commands.UpdateType
{
    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand>
    {
        private readonly ITypeCommandRepository _typeCommandRepository;
        private readonly ITypeQueryRepository _typeQueryRepository;

        public UpdateTypeCommandHandler(ITypeCommandRepository typeCommandRepository, ITypeQueryRepository typeQueryRepository)
        {
            _typeCommandRepository = typeCommandRepository;
            _typeQueryRepository = typeQueryRepository;
        }

        public async Task Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _typeQueryRepository.GetByIdAsync(request.Type.Id) ?? throw new NotFoundException($"Invalid type model");
            type.TypeName = request.Type.TypeName;

            _typeCommandRepository.Update(type);
            await _typeCommandRepository.SaveAsync();
        }
    }
}
