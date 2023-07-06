using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.DeleteType
{
	public class DeleteTypeCommand : IRequest
	{
		public int Id { get; set; }
	}
}
