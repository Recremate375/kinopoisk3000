using Films.Domain.Mapper;

namespace Films.WebApi.ExtensionMethods
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
