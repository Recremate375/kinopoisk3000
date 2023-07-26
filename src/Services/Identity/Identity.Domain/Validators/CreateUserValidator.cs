using FluentValidation;
using Identity.Domain.DTO;

namespace Identity.Domain.Validators
{
	public class CreateUserValidator : AbstractValidator<CreateUserDTO>
	{
		public CreateUserValidator()
		{
			RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Enter a valid email address");
			RuleFor(user => user.Name).NotEmpty().WithMessage("Enter your name");
			RuleFor(user => user.Surname).NotEmpty().WithMessage("Enter your surname");
			RuleFor(user => user.Login).NotEmpty().WithMessage("Enter your login");
		}
	}
}
