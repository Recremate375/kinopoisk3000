using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Types.Commands.UpdateType
{
    public class UpdateTypeCommand : IRequest
    {
        public FilmTypeDTO Type { get; set; }
    }
}
