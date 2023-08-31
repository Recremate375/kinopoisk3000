using Serilog.Sinks.Elasticsearch;
using Serilog;

namespace Rating.WebApi.Extensions
{
	public static class AddElasticSearchExtension
	{
		public static IServiceCollection ConfigureElastic(this IServiceCollection services, IConfiguration configuration)
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var configure = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile(
					$"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
					optional: true)
				.Build();

			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.Enrich.WithMachineName()
				.WriteTo.Debug()
				.WriteTo.Console()
				.WriteTo.Elasticsearch(ConfigureElasticSink(configure, environment!))
				.Enrich.WithProperty("Environment", environment!)
				.ReadFrom.Configuration(configure)
				.CreateLogger();

			return services;
		}

		private static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration, string environment)
		{
			return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]!))
			{
				AutoRegisterTemplate = true,
				IndexFormat = $"kinopoisk3000App-{DateTime.UtcNow:dd-MM-yyyy}"
			};
		}
	}
}
