using MassTransit;
using Rating.WebApi.MessageBroker;

namespace Rating.WebApi.Extensions
{
	public static class AddRabbitMQExtension
	{
		public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
		{
			services.AddMassTransit(config =>
			{
				config.SetEndpointNameFormatter(
					new KebabCaseEndpointNameFormatter(prefix: "film", includeNamespace: false));

				config.AddConsumers(typeof(FilmConsumer).Assembly);

				config.UsingRabbitMq((context, config) =>
				{
					config.Host("rabbitmq", "/");
					config.ConfigureEndpoints(context);
				});
			});

			return services;
		}
	}
}
