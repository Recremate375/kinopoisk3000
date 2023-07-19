using Rating.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rating.Domain.DTOs
{
	public class RatingDTO
	{
		public int Id { get; set; }
		public int FilmRating { get; set; }
		public User RatingUser { get; set; }
		public Film RatingFilm { get; set; }
	}
}
