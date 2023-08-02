using Rating.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rating.Domain.DTOs
{
	public class FilmToBrokerDTO
	{
		public string FilmName { get; set; }
		public BrokerOpertaionsEnum? StateOfOperation { get; set; }
	}
}
