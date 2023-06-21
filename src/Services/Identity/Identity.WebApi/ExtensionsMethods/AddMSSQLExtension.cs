using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class AddMSSQLExtension
	{
		public static IServiceCollection AddMSSQLDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdentityDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MSSQLConnection")));

			return services;
		}
	}
}
