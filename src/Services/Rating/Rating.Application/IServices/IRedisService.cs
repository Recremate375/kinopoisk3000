namespace Rating.Application.IServices
{
	public interface IRedisService<T> where T : class
	{
		public Task<string> GetAsync();
		public Task SetAsync(T? value);
	}
}
