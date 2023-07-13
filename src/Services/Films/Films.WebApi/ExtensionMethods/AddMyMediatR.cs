using Films.Application.Features.Films.Commands.CreateFilm;
using Films.Application.Features.Films.Commands.DeleteFilm;
using Films.Application.Features.Films.Commands.UpdateFilm;
using Films.Application.Features.Films.Queries.GetAllFilms;
using Films.Application.Features.Films.Queries.GetFilmById;
using Films.Application.Features.Films.Queries.GetFilmByName;
using Films.Application.Features.Films.Queries.GetFilmsByProductionYear;
using Films.Application.Features.Films.Queries.GetFilmsByType;
using Films.Application.Features.Types.Commands.CreateType;
using Films.Application.Features.Types.Commands.DeleteType;
using Films.Application.Features.Types.Commands.UpdateType;
using Films.Application.Features.Types.Queries.GetAllTypes;
using Films.Application.Features.Types.Queries.GetTypeById;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Films.WebApi.ExtensionMethods
{
    public static class AddMyMediatR
	{
		public static IServiceCollection AddMyMediatr(this IServiceCollection services)
		{
			services.AddMediatR(x => x.RegisterServicesFromAssemblies(
				typeof(Program).Assembly,
				typeof(GetAllTypesQueryHandler).Assembly,
				typeof(GetFilmsQueryHandler).Assembly,
				typeof(CreateFilmCommandHandler).Assembly,
				typeof(CreateTypeCommandHandler).Assembly,
				typeof(DeleteFilmCommandHandler).Assembly,
				typeof(DeleteTypeCommandHandler).Assembly,
				typeof(UpdateFilmCommandHandler).Assembly,
				typeof(UpdateTypeCommandHandler).Assembly,
				typeof(GetFilmByIdQueryHandler).Assembly,
				typeof(GetTypeByIdQueryHandler).Assembly,
				typeof(GetFilmByNameQueryHandler).Assembly,
				typeof(GetFilmsByProductionYearQueryHandler).Assembly,
				typeof(GetFilmsByTypeQueryHandler).Assembly
				));

			return services;
		}
	}
}
