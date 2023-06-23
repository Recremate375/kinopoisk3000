using Films.Application.Repositories.Commands;
using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Commands
{
	public class FilmCommandRepository : BaseCommandRepository<Film>, IFilmCommandRepository
	{
		public Task<Film> GetFilmByNameAsync(string filmName)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Film>> GetFilmsByProductinoYear(DateTime filmDate)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Film>> GetFilmsByTypeAsync(Domain.Models.Type filmtype)
		{
			throw new NotImplementedException();
		}
	}
}
