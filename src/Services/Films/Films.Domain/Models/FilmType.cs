namespace Films.Domain.Models
{
	public class FilmType : BaseEntity
	{
		public string? TypeName { get; set; }
		public ICollection<Film>? Films { get; } = new List<Film>();
	}
}
