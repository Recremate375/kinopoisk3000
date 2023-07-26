using Identity.Domain.Common;

namespace Identity.Domain.ExtensionsMethods
{
	public static class AddAutoMapperExtension
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
