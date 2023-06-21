using FluentValidation;
using Identity.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Validators
{
	public class CreateUserValidator : AbstractValidator<CreateUserDTO>
	{
		public CreateUserValidator()
		{
			RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("");
			RuleFor(user => user.Name).NotEmpty().WithMessage("");
			RuleFor(user => user.Surname).NotEmpty().WithMessage("");
			RuleFor(user => user.Login).NotEmpty().WithMessage("");
		}
	}
}
