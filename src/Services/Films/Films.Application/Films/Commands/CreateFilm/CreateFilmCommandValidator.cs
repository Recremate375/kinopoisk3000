using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Films.Commands.CreateFilm
{
	public class CreateFilmCommandValidator : AbstractValidator<CreateFilmCommand>
	{
        public CreateFilmCommandValidator()
        {
            RuleFor(c => c.CreateFilmDTO.FilmName).NotEmpty();
			RuleFor(c => c.CreateFilmDTO.TotalMinutes).NotEmpty();
			RuleFor(c => c.CreateFilmDTO.ProductionYear).NotEmpty();
			RuleFor(c => c.CreateFilmDTO.Description).NotEmpty();
		}
    }
}
