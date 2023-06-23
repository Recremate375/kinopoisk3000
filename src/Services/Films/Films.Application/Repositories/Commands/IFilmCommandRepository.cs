using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Repositories.Commands
{
	public interface IFilmCommandRepository : IBaseCommandRepository<Film>
	{
		Task<Film> GetFilmByNameAsync(string filmName);
		Task<IReadOnlyList<Film>> GetFilmsByTypeAsync(Domain.Models.Type filmtype);
		Task<IReadOnlyList<Film>> GetFilmsByProductinoYear(DateTime filmDate);
	}
}
