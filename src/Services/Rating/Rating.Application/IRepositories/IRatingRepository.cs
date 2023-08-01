namespace Rating.Application.IRepositories
{
	public interface IRatingRepository : IBaseRepository<Domain.Models.Rating>
	{
		Task<int> GetSumRatingForFilmNameAsync(string filmName);

		Task<int> GetCountOfRatedUsers(string filmName);
	}
}
