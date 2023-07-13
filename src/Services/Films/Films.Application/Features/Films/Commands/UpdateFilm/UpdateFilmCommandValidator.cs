using FluentValidation;

namespace Films.Application.Features.Films.Commands.UpdateFilm
{
    public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmCommandValidator()
        {
            RuleFor(c => c.UpdateFilm.FilmName).NotEmpty();
            RuleFor(c => c.UpdateFilm.TotalMinutes).NotEmpty();
            RuleFor(c => c.UpdateFilm.Description).NotEmpty();
            RuleFor(c => c.UpdateFilm.ProductionYear).NotEmpty();
        }
    }
}
