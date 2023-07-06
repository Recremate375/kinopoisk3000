using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Queries.GetFilmsByProductionYear
{
	public class GetFilmsByProductionYearQuery : IRequest<List<FilmDTO>>
	{
		public DateTime ProductionYear { get; set; }
	}
}
