using MediatR;

namespace Films.Application.Features.Types.Commands.DeleteType
{
	public class DeleteTypeCommand : IRequest
	{
		public int Id { get; set; }
	}
}
