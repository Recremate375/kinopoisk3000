using Films.Domain.DTO;
using MediatR;

namespace Films.Application.Features.Types.Commands.CreateType
{
	public class CreateTypeCommand : IRequest<int>
	{
		public CreateTypeDTO Type { get; set; }
	}
}
