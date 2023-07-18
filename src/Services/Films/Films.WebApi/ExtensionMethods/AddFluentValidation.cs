using Films.Application.Features.Films.Commands.CreateFilm;
using Films.Application.Features.Films.Commands.UpdateFilm;
using Films.Application.Features.Types.Commands.CreateType;
using Films.Application.Features.Types.Commands.UpdateType;
using FluentValidation;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddFluentValidation
	{
		public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
		{
			services.AddTransient<IValidator<CreateFilmCommand>, CreateFilmCommandValidator>()
				.AddTransient<IValidator<UpdateFilmCommand>, UpdateFilmCommandValidator>()
				.AddTransient<IValidator<CreateTypeCommand>, CreateTypeCommandValidator>()
				.AddTransient<IValidator<UpdateTypeCommand>, UpdateTypeCommandValidator>();

			return services;
		}
	}
}
