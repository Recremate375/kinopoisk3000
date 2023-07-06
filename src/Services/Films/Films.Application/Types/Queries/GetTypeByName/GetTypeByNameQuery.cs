using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Queries.GetTypeByName
{
	public class GetTypeByNameQuery : IRequest<FilmTypeDTO>
	{
		public string TypeName { get; set; }
	}
}
