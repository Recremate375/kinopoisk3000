using Films.Domain.Models;

namespace Films.Domain.DTO
{
	public class FilmDTO
	{
		public int Id { get; set; }
		public string? FilmName { get; set; }
		public string? Description { get; set; }
		public FilmType? Type { get; set; }
		public int TotalMinutes { get; set; }
		public DateTime ProductionYear { get; set; }
	}
}
