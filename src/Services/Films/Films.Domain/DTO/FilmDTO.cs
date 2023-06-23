using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Domain.DTO
{
	public class FilmDTO
	{
		public int FilmId { get; set; }
		public string? FilmName { get; set; }
		public string? Description { get; set; }
		public Type? FilmType { get; set; }
		public int TotalMinutes { get; set; }
		public DateTime ProductionYear { get; set; }
	}
}
