using Films.Domain.Models;
using Films.Infrastructure.Context;
using Films.Application.Repositories.Commands;

namespace Films.Infrastructure.Repositories.Commands
{
	public class FilmCommandRepository : BaseCommandRepository<Film>, IFilmCommandRepository
	{
		public FilmCommandRepository(FilmsDbContext context) : base(context)
		{
		}

	}
}
