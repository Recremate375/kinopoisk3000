using Films.Domain.Models;

namespace Films.Application.Repositories.Queryes
{
	public interface IFilmQueryRepository : IBaseQueryRepository<Film>
	{
		Task<Film> GetFilmByNameAsync(string filmName);
		
		Task<List<Film>> GetFilmsByTypeAsync(Domain.Models.FilmType filmtype);
		
		Task<List<Film>> GetFilmsByProductionYear(DateTime filmDate);
	}
}
