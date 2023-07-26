using Microsoft.EntityFrameworkCore;
using Rating.Application.IRepositories;
using Rating.Infrastructure.Context;

namespace Rating.Infrastructure.Repositories
{
	public class RatingRepository : BaseRepository<Domain.Models.Rating>, IRatingRepository
	{
		public RatingRepository(RatingDbContext context) : base(context)
		{
		}

		public async Task<int> GetCountOfRatedUsers(string filmName)
		{
			return await _context.Ratings.Where(x => x.RatingFilm.FilmName == filmName)
				.CountAsync(x => x.RatingUser != null && x.FilmRating != 0);
		}

		public async Task<int> GetSumRatingForFilmNameAsync(string filmName)
		{
			return await _context.Ratings.Include(x => x.FilmRating).
				Where(x => x.RatingFilm.FilmName == filmName).SumAsync(x => x.FilmRating);
		}
	}
}
