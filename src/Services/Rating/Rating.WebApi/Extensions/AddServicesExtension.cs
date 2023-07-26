using Rating.Application.IServices;
using Rating.Application.Services;

namespace Rating.WebApi.Extensions
{
	public static class AddServicesExtension
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IRatingService, RatingService>();

			return services;
		}
	}
}
