namespace Rating.Domain.DTOs
{
	public class CreateRatingDTO
	{
		public int FilmRating { get; set; }
		public string UserLogin { get; set; }
		public string FilmName { get; set; }
	}
}
