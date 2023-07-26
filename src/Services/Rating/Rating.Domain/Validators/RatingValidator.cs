using FluentValidation;
using Rating.Domain.DTOs;

namespace Rating.Domain.Validators
{
	public class RatingValidator : AbstractValidator<RatingDTO>
	{
		public RatingValidator()
		{
			RuleFor(role => role.FilmRating).LessThanOrEqualTo(0).GreaterThan(10);
		}
	}
}
