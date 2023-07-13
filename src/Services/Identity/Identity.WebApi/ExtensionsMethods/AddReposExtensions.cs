using Identity.Application.Repositories;
using Identity.Infrastructure.Repositories;

namespace Identity.Domain.ExtensionsMethods
{
	public static class AddReposExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}
	}
}
