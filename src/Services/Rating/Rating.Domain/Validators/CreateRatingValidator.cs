using FluentValidation;
using Rating.Domain.DTOs;

namespace Rating.Domain.Validators
{
	public class CreateRatingValidator : AbstractValidator<CreateRatingDTO>
	{
		public CreateRatingValidator()
		{
			RuleFor(rule => rule.FilmRating).LessThanOrEqualTo(0).GreaterThan(10);
		}
	}
}
