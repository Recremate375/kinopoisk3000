using Rating.Domain.DTOs;
using Rating.Domain.Models;

namespace Rating.Application.IServices
{
	public interface IRatingService
	{
		Task<List<RatingDTO>> GetAllRatingsAsync();

		Task CreateRatingAsync(CreateRatingDTO ratingDTO);

		Task<float> GetRatingByFilmName(string filmName);

		Task UpdateRating(RatingDTO ratingDTO);

		Task DeleteRating(int id);

	}
}
