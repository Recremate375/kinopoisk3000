using Films.Domain.DTO;
using Films.Domain.Models;

namespace Films.Application.Repositories.Queryes
{
	public interface IBaseQueryRepository<T> where T : BaseEntity
	{
		Task<List<TDto>> GetAllAsync<TDto>() where TDto : BaseDTOEntity;

		Task<T?> GetByIdAsync(int id);
	}
}
