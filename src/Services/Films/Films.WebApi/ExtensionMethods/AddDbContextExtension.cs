using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddDbContextExtension
	{
		public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<FilmsDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MSSQLConnection")));

			return services;
		}
	}
}
