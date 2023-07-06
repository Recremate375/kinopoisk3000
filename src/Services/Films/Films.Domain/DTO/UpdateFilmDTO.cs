using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Domain.DTO
{
	public class UpdateFilmDTO
	{
		public string? FilmName { get; set; }
		public string? Description { get; set; }
		public FilmType Type { get; set; }
		public int TotalMinutes { get; set; }
		public DateTime ProductionYear { get; set; }
	}
}
