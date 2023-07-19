namespace Rating.Domain.Models
{
	public class Rating : BaseEntity
	{
		public int FilmRating { get; set; }
		public User RatingUser { get; set; }
		public Film RatingFilm { get; set; }

	}
}
