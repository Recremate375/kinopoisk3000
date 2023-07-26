using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Infrastructure.Repositories.Commands;
using Films.Infrastructure.Repositories.Queries;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddRepositoriesExtension
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IFilmCommandRepository, FilmCommandRepository>();
			services.AddScoped<IFilmQueryRepository, FilmQueryRepository>();
			services.AddScoped<ITypeCommandRepository, TypeCommandRepository>();
			services.AddScoped<ITypeQueryRepository, TypeQueryRepository>();

			return services;
		}
	}
}
