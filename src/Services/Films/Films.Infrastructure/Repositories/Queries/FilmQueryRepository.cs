using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class FilmQueryRepository : BaseQueryRepository<Film>, IFilmQueryRepository
	{
		private readonly FilmsDbContext context;

		public FilmQueryRepository(FilmsDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<Film> GetFilmByNameAsync(string filmName)
		{
			return await context.Films.FirstOrDefaultAsync(x => x.FilmName == filmName);
		}

		public async Task<List<Film>> GetFilmsByProductinoYear(DateTime filmDate)
		{
			return await context.Films.AsNoTracking().Where(x => x.ProductionYear == filmDate).ToListAsync();
		}

		public async Task<List<Film>> GetFilmsByTypeAsync(Domain.Models.Type filmtype)
		{
			return await context.Films.AsNoTracking().Where(x => x.FilmType == filmtype).ToListAsync();
		}
	}
}
