using Films.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.CreateType
{
	public class CreateTypeCommand : IRequest<int>
	{
		public CreateTypeDTO Type { get; set; }
	}
}
