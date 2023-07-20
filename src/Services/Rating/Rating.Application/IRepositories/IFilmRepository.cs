using Rating.Domain.Models;

namespace Rating.Application.IRepositories
{
	public interface IFilmRepository : IBaseRepository<Film>
	{
		Task<Film?> GetFilmByNameAsync(string filmName);
	}
}
