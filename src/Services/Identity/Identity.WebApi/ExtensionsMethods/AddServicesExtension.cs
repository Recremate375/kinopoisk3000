using Identity.Application.Features;
using Identity.Application.IServices;

namespace Identity.Domain.ExtensionsMethods
{
	public static class AddServicesExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IGenerateJWTService, GenerateJWTService>();
			services.AddScoped<IRoleService, RolesService>();
			services.AddScoped<IUsersService, UsersService>();

			return services;
		}
	}
}
