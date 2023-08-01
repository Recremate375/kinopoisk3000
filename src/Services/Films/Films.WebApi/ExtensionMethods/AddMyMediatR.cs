using Films.Application.Features.Films.Commands.CreateFilm;
using Films.Application.Features.Types.Queries.GetAllTypes;

namespace Films.WebApi.ExtensionMethods
{
	public static class AddMyMediatR
	{
		public static IServiceCollection AddMyMediatr(this IServiceCollection services)
		{
			services.AddMediatR(x => x.RegisterServicesFromAssemblies(
				typeof(Program).Assembly,
				typeof(GetAllTypesQueryHandler).Assembly
				));

			return services;
		}
	}
}
