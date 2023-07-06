using Films.Domain.DTO;
using Films.Domain.Models;
using MediatR;
using System;

namespace Films.Application.Films.Commands.CreateFilm
{
	public class CreateFilmCommand : IRequest<Film>
	{
		public CreateFilmDTO CreateFilmDTO { get; set; }
	}
}
