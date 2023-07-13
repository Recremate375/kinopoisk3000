using FluentValidation;
using FluentValidation.AspNetCore;
using Identity.Application.Pipelines;
using Identity.Domain.DTO;
using Identity.Domain.Validators;
using MediatR;

namespace Identity.Domain.ExtensionsMethods
{
	public static class FluentValidation
	{
		public static IServiceCollection AddMyFluentValidation(this IServiceCollection services)
		{
			services.AddTransient<IValidator<UserDTO>, UserValidator>()
				.AddTransient<IValidator<LoginUserDTO>, LoginUserValidator>()
				.AddTransient<IValidator<RoleDTO>, RoleValidator>()
				.AddTransient<IValidator<CreateUserDTO>, CreateUserValidator>();

			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

			return services;
		}
	}
}
