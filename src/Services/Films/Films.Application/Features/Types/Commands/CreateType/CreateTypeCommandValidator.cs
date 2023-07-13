using FluentValidation;

namespace Films.Application.Features.Types.Commands.CreateType
{
    public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeCommandValidator()
        {
            RuleFor(x => x.Type.TypeName).NotEmpty();
        }
    }
}
