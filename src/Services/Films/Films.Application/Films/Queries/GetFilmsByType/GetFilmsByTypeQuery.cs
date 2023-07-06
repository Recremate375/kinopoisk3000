using Films.Domain.DTO;
using Films.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Queries.GetFilmsByType
{
	public class GetFilmsByTypeQuery : IRequest<List<FilmDTO>>
	{
		public FilmTypeDTO FilmTypeDTO { get; set; }
	}
}
