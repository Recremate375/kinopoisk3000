using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Repositories.Queryes
{
	public interface IFilmQueryRepository : IBaseQueryRepository<Film>
	{
		Task<Film> GetFilmByNameAsync(string filmName);
		Task<List<Film>> GetFilmsByTypeAsync(Domain.Models.Type filmtype);
		Task<List<Film>> GetFilmsByProductinoYear(DateTime filmDate);
	}
}
