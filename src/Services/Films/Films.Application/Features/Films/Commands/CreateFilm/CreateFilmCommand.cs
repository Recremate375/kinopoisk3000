using Films.Domain.DTO;
using Films.Domain.Models;
using MediatR;

namespace Films.Application.Features.Films.Commands.CreateFilm
{
	public class CreateFilmCommand : IRequest<Film>
	{
		public CreateFilmDTO CreateFilmDTO { get; set; }
	}
}
