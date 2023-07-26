using FluentValidation;
using Identity.Domain.DTO;

namespace Identity.Domain.Validators
{
	public class RoleValidator : AbstractValidator<RoleDTO>
	{
		public RoleValidator()
		{
			RuleFor(role => role.RoleName).NotEmpty().WithMessage("The role must have a name");
		}
	}
}
