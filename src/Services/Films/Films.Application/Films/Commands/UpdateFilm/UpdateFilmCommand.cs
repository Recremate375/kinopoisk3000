using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Commands.UpdateFilm
{
	public class UpdateFilmCommand : IRequest
	{
		public int FilmId { get; set; }
		public UpdateFilmDTO UpdateFilm { get; set; }
	}
}
