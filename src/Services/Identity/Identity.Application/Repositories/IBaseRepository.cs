namespace Identity.Application.Repositories
{
	public interface IBaseRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();

		Task<T> GetByIdAsync(int id);
		
		Task CreateAsync(T entity);
		
		void Update(T entity);
		
		void Delete(T entity);
		
		Task SaveAsync();
	}
}
