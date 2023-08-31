using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Domain.Models
{
	public class FilmToMongo
	{
		public int Id { get; set; }
		public string? FilmName { get; set; }
		public byte[]? PosterImage { get; set; }
	}
}
