using Rating.Domain.Mapper;

namespace Rating.WebApi.Extensions
{
	public static class AddAutoMapper
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfile));

			return services;
		}
	}
}
