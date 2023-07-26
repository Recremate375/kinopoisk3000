using Rating.Domain.DTOs;
using Rating.Domain.Models;

namespace Rating.Application.IServices
{
	public interface IRatingService
	{
		Task<List<RatingDTO>> GetAllRatingsAsync();

		Task<Domain.Models.Rating> CreateRatingAsync(CreateRatingDTO ratingDTO);

		Task<float> GetRatingByFilmNameAsync(string filmName);

		Task UpdateRating(RatingDTO ratingDTO);

		Task DeleteRating(int id);

	}
}
