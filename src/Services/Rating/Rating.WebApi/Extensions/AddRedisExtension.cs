namespace Rating.WebApi.Extensions
{
	public static class AddRedisExtension
	{
		public static IServiceCollection ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddStackExchangeRedisCache(options =>
			{
				options.Configuration = configuration["ConnectionStrings:Redis"];
				options.InstanceName = "RatingServiceApp";
			});

			return services;
		}
	}
}
