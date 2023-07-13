using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Types.Queries.GetTypeByName
{
    public class GetTypeByNameQuery : IRequest<FilmTypeDTO>
    {
        public string TypeName { get; set; }
    }
}
