using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Queries.GetFilmByName
{
	public class GetFilmByNameQuery : IRequest<FilmDTO>
	{
		public string FilmName { get; set; }
	}
}
