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
	}
}
