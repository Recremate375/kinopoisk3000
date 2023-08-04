using FluentValidation;

namespace Films.Application.Features.Types.Commands.UpdateType
{
	public class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
	{
		public UpdateTypeCommandValidator()
		{
			RuleFor(x => x.Type.TypeName).NotEmpty();
		}
	}
}
