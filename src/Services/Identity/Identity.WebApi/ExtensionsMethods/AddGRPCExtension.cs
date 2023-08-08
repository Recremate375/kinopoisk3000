using Identity.WebApi.Protos;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class AddGRPCExtension
	{
		public static IServiceCollection ConfigureGRPC(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(options =>
			{
				options.Address = new Uri(configuration["GrpcConnection"]);
			});
			services.AddScoped<UserProtoService.UserProtoServiceClient>();

			return services;
		}
	}
}
