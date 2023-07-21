using FluentValidation;
using MediatR;
using Rating.Application.Pipelines;
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

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			return services;
		}
	}
}
