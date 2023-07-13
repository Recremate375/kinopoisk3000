using MediatR;

namespace Films.Application.Features.Films.Commands.DeleteFilm
{
    public class DeleteFilmCommand : IRequest
    {
        public int Id { get; set; }
    }
}
