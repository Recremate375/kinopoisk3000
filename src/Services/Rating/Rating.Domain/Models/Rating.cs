namespace Rating.Domain.Models
{
	public class Rating : BaseEntity
	{
		public int FilmRating { get; set; }
		public int UserId { get; set; }
		public User RatingUser { get; set; }
		public int FilmId { get; set; }
		public Film RatingFilm { get; set; }
	}
}
