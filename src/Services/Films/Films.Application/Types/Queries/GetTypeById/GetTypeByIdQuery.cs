using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Queries.GetTypeById
{
	public class GetTypeByIdQuery : IRequest<FilmTypeDTO>
	{
		public int Id { get; set; }
	}
}
