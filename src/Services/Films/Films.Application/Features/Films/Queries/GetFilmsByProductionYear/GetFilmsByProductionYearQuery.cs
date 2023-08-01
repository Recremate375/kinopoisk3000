using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Films.Queries.GetFilmsByProductionYear
{
	public class GetFilmsByProductionYearQuery : IRequest<List<FilmDTO>>
	{
		public DateTime ProductionYear { get; set; }
	}
}
