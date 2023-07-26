using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetFilmById
{
    public class GetFilmByIdQuery : IRequest<FilmDTO>
    {
        public int FilmId { get; set; }
    }
}
