using Identity.Application.Repositories;
using Identity.Infrastructure.Repositories;

namespace Identity.Domain.ExtensionsMethods
{
	public static class AddReposExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRoleRepository, RoleRepository>();
			services.AddTransient<IUserRepository, UserRepository>();

			return services;
		}
	}
}
