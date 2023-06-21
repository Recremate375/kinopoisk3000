using FluentValidation;
using Identity.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
