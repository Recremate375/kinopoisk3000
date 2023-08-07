using Grpc.Core;
using Rating.WebApi.GRPc;

namespace Rating.WebApi.Extensions
{
	public static class AddgRPCExtension
	{
		public static IServiceCollection ConfigureGRPC(this IServiceCollection services)
		{
			services.AddGrpc();

			return services;
		}

		public static IApplicationBuilder UseGRPC(this IApplicationBuilder app)
		{
			app.UseRouting();
			app.UseGrpcWeb();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<UserService>().EnableGrpcWeb();
			});

			return app;
		}
	}
}
