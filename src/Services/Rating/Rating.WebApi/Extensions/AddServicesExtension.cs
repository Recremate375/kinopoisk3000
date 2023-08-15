using Rating.Application.IServices;
using Rating.Application.Services;

namespace Rating.WebApi.Extensions
{
	public static class AddServicesExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IRatingService, RatingService>()
				.AddScoped<IRedisService<List<Domain.Models.Rating>>, RedisService<List<Domain.Models.Rating>>>();

			return services;
		}
	}
}
