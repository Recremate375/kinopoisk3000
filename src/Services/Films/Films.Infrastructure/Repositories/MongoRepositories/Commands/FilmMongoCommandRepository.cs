using Films.Application.Repositories.MongoRepositories.Commands;
using Films.Domain.Models;
using Films.Infrastructure.Context;

namespace Films.Infrastructure.Repositories.MongoRepositories.Commands
{
	public class FilmMongoCommandRepository : IFilmMongoCommandRepository
	{
		private readonly MongoDbContext _dbContext;

		public FilmMongoCommandRepository(MongoDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAsync(FilmToMongo entity)
		{
			await _dbContext.mongoCollection.InsertOneAsync(entity);

			return;
		}
	}
}
