﻿using Films.Domain.Models;

namespace Films.Domain.DTO
{
	public class FilmDTO : BaseDTOEntity
	{
		public string? FilmName { get; set; }
		public string? Description { get; set; }
		public int FilmTypeId { get; set; }
		public FilmType? Type { get; set; }
		public int TotalMinutes { get; set; }
		public DateTime ProductionYear { get; set; }
	}
}
