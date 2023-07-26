using Films.Domain.Models;

namespace Films.Application.Repositories.Queryes
{
	public interface IFilmQueryRepository : IBaseQueryRepository<Film>
	{
		Task<Film?> GetFilmByNameAsync(string filmName);
		
		Task<List<Film?>> GetFilmsByTypeIdAsync(int filmTypeId);
		
		Task<List<Film?>> GetFilmsByProductionYear(DateTime filmDate);
	}
}
