using Rating.Domain.Models;

namespace Rating.Domain.DTOs
{
	public class RatingDTO
	{
		public int Id { get; set; }
		public int FilmRating { get; set; }
		public User RatingUser { get; set; }
		public Film RatingFilm { get; set; }
	}
}
