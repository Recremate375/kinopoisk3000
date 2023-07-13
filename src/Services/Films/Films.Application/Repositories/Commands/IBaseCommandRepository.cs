namespace Films.Application.Repositories.Commands
{
	public interface IBaseCommandRepository<T> where T : class
	{
		Task CreateAsync(T entity);

		void Update(T entity);
		
		void Delete(T entity);
		
		Task SaveAsync();
	}
}
