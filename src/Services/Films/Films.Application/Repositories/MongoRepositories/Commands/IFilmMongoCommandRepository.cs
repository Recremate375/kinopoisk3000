using Films.Domain.Models;

namespace Films.Application.Repositories.MongoRepositories.Commands
{
	public interface IFilmMongoCommandRepository : IBaseMongoCommandRepository<FilmToMongo>
	{
	}
}
