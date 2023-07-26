using FluentValidation;
using Identity.Domain.DTO;

namespace Identity.Domain.Validators
{
	public class UserValidator : AbstractValidator<UserDTO>
	{
		public UserValidator()
		{
			RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Enter a valid email address");
			RuleFor(user => user.Name).NotEmpty().WithMessage("Enter your name");
			RuleFor(user => user.Surname).NotEmpty().WithMessage("Enter your surname");
		}
	}
}
