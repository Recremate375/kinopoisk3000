using FluentValidation;
using Identity.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
