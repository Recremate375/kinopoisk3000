using FluentValidation;
using Identity.Domain.DTO;

namespace Identity.Domain.Validators
{
	public class LoginUserValidator : AbstractValidator<LoginUserDTO>
	{
		public LoginUserValidator()
		{
			RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Enter a valid email address");
		}
	}
}
