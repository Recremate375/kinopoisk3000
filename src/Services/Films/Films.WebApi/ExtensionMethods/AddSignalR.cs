using Films.Application.Hubs;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddSignalR
	{
		public static IServiceCollection ConfigureSignalR(this IServiceCollection services)
		{
			services.AddSignalR();

			return services;
		}

		public static IApplicationBuilder AddSignalRMap(this IApplicationBuilder app)
		{
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<NotificationHub>("/NotificationHub");
			});

			return app;
		}
	}
}
