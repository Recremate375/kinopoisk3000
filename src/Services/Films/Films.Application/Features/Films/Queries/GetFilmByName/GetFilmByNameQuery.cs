using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetFilmByName
{
	public class GetFilmByNameQuery : IRequest<FilmDTO>
	{
		public string FilmName { get; set; }
	}
}
