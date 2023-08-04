using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetFilmsByType
{
	public class GetFilmsByTypeQuery : IRequest<List<FilmDTO>>
	{
		public FilmTypeDTO FilmTypeDTO { get; set; }
	}
}
