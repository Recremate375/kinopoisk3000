using Films.Application.Repositories.Commands;
using Films.Domain.Models;
using Films.Infrastructure.Context;

namespace Films.Infrastructure.Repositories.Commands
{
	public class FilmCommandRepository : BaseCommandRepository<Film>, IFilmCommandRepository
	{
		public FilmCommandRepository(FilmsDbContext context) : base(context)
		{
		}

	}
}
