namespace Films.Application.Repositories.Queryes
{
	public interface IBaseQueryRepository <T> where T : class
	{
		Task<List<T?>> GetAllAsync();
		
		Task<T?> GetByIdAsync(int id);
	}
}
