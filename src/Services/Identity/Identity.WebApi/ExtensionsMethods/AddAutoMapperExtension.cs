using Identity.Domain.Common;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class AddAutoMapperExtension
	{
		public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
