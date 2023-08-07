using Grpc.Core;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class AddGRPCExtension
	{
		public static IServiceCollection ConfigureGRPC(this IServiceCollection services)
		{
			services.AddGrpc();

			return services;
		}

		public static IApplicationBuilder UseGrpc(this IApplicationBuilder app)
		{
			app.UseGrpcWeb();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapGrpcService<UserService>().EnableGrpcWeb();
			//});

			return app;
		}

	}
}
