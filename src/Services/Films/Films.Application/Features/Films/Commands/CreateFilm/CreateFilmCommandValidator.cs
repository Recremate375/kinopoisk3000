using FluentValidation;

namespace Films.Application.Features.Films.Commands.CreateFilm
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
