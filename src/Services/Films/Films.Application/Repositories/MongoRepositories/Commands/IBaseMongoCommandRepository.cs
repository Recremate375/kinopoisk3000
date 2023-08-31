namespace Films.Application.Repositories.MongoRepositories.Commands
{
	public interface IBaseMongoCommandRepository<T> where T : class
	{
		Task CreateAsync(T entity);
	}
}
