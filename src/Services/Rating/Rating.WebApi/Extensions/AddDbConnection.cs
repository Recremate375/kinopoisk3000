using Microsoft.EntityFrameworkCore;
using Rating.Infrastructure.Context;

namespace Rating.WebApi.Extensions
{
	public static class AddDbConnection
	{
		public static IServiceCollection AddMSSqlDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RatingDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("MSSQLConnection")));

			return services;
		}
	}
}
