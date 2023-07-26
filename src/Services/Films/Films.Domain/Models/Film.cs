namespace Films.Domain.Models
{
	public class Film : BaseEntity
	{
		public string? FilmName { get; set; }
		public string? Description { get; set; }
		public int FilmTypeId { get; set; }
		public FilmType? Type { get; set; }
		public int TotalMinutes { get; set; }
		public DateTime ProductionYear { get; set; }
	}
}
