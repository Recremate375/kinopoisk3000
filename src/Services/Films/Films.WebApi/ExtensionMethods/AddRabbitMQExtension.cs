using MassTransit;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddRabbitMQExtension
	{
		public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
		{
			services.AddMassTransit(config =>
			{
				config.UsingRabbitMq();
			});

			return services;
		}
	}
}
