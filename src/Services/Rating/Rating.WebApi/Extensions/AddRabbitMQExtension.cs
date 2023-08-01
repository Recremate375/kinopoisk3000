using MassTransit;
using Rating.WebApi.MessageBroker;

namespace Rating.WebApi.Extensions
{
	public static class AddRabbitMQExtension
	{
		public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMassTransit(config =>
			{
				config.AddConsumers(typeof(FilmConsumer).Assembly);

				var host = configuration["RabbitMQ:Host"];
				var virtualHost = configuration["RabbitMQ:VirtualHost"];
				var username = configuration["RabbitMQ:Username"];
				var password = configuration["RabbitMQ:Password"];

				config.UsingRabbitMq((context, config) =>
				{
					config.Host(host, virtualHost, h =>
					{
						h.Username(username);
						h.Password(password);
					});
					config.ConfigureEndpoints(context);
				});
			});

			return services;
		}
	}
}
