using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Types.Commands.CreateType
{
	public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
	{
		public CreateTypeCommandValidator()
		{
			RuleFor(x => x.Type.TypeName).NotEmpty();
		}
	}
}
