namespace Rating.Domain.Models
{
	public class User : BaseEntity
	{
		public string Login { get; set; }
		public List<Rating> ratings { get; } = new List<Rating>();
	}
}
