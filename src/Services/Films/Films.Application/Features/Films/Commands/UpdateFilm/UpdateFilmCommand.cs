using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommand : IRequest
    {
        public int FilmId { get; set; }
        public UpdateFilmDTO UpdateFilm { get; set; }
    }
}
