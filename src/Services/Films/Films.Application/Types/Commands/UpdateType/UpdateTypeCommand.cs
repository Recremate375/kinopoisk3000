using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.UpdateType
{
	public class UpdateTypeCommand : IRequest
	{
		public FilmTypeDTO Type { get; set; }
	}
}
