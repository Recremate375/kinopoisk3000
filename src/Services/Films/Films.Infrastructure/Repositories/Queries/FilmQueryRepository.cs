using AutoMapper;
using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.Repositories.Queries
{
	public class FilmQueryRepository : BaseQueryRepository<Film?>, IFilmQueryRepository
	{
		public FilmQueryRepository(FilmsDbContext context, IMapper mapper) : base(context, mapper)
		{

		}

		public new async Task<List<Film?>> GetAllAsync()
		{
			return await _context.Films.Include(film => film.Type).AsNoTracking().ToListAsync();
		}

		public async Task<Film?> GetFilmByNameAsync(string filmName)
		{
			return await _context.Films.AsNoTracking().FirstOrDefaultAsync(film => film.FilmName == filmName);
		}

		public async Task<List<Film?>> GetFilmsByProductionYear(DateTime filmDate)
		{
			return await _context.Films.AsNoTracking().Where(film => film.ProductionYear == filmDate).ToListAsync();
		}

		public async Task<List<Film?>> GetFilmsByTypeIdAsync(int filmTypeId)
		{
			return await _context.Films.AsNoTracking().Where(film => film.Type.Id == filmTypeId).ToListAsync();
		}
	}
}
