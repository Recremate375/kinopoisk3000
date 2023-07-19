using FluentValidation;
using Rating.Domain.DTOs;
using Rating.Domain.Validators;

namespace Rating.WebApi.Extensions
{
	public static class AddFluentValidationExtension
	{
		public static IServiceCollection ConfigreFluentValidation(this IServiceCollection services)
		{
			services.AddScoped<IValidator<RatingDTO>, RatingValidator>()
				.AddScoped<IValidator<CreateRatingDTO>, CreateRatingValidator>();

			return services;
		}
	}
}
