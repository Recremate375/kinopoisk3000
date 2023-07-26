using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Types.Queries.GetTypeById
{
    public class GetTypeByIdQuery : IRequest<FilmTypeDTO>
    {
        public int Id { get; set; }
    }
}
