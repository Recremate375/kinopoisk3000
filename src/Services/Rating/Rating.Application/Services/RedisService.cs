using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Rating.Application.IRepositories;
using Rating.Application.IServices;
using System.Text;

namespace Rating.Application.Services
{
	public class RedisService<T> : IRedisService<T> where T : class
	{
		private const string cacheKey = "Ratings";
		private readonly IDistributedCache _cache;

		public RedisService(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<string> GetAsync()
		{
			var Entity = await _cache.GetAsync(cacheKey);
			var serializedEntity = Encoding.UTF8.GetString(Entity);

			return serializedEntity;
		}

		public async Task SetAsync(T? value)
		{
			var serializedEntity = JsonConvert.SerializeObject(value);
			var serializedEntityToBytes = Encoding.UTF8.GetBytes(serializedEntity);
			var options = new DistributedCacheEntryOptions()
				.SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
				.SetSlidingExpiration(TimeSpan.FromMinutes(2));

			await _cache.SetAsync(cacheKey, serializedEntityToBytes, options);
		}
	}
}
