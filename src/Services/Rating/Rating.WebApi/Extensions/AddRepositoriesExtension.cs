using Rating.Application.IRepositories;
using Rating.Infrastructure.Repositories;

namespace Rating.WebApi.Extensions
{
	public static class AddRepositoriesExtension
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRatingRepository, RatingRepository>()
				.AddScoped<IFilmRepository, FilmRepository>()
				.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}
