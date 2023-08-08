namespace Rating.Domain.Models
{
	public class Film : BaseEntity
	{
		public string FilmName { get; set; }
		public List<Rating> ratings { get; } = new List<Rating>();
	}
}
