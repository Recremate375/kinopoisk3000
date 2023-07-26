using Rating.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rating.Domain.DTOs
{
	public class CreateRatingDTO
	{
		public int FilmRating { get; set; }
		public string UserLogin { get; set; }
		public string FilmName { get; set; }
	}
}
