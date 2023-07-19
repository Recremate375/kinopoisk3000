using Microsoft.EntityFrameworkCore;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.Infrastructure.Context;

namespace Rating.Infrastructure.Repositories
{
	public class FilmRepository : BaseRepository<Film>, IFilmRepository
	{
		public FilmRepository(RatingDbContext context) : base(context)
		{

		}

		public Task<Film> GetFilmByNameAsync(string filmName)
		{
			return _context.Films.AsNoTracking().FirstOrDefaultAsync(x => x.FilmName == filmName);
		}
	}
}
