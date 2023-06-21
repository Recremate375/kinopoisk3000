using FluentValidation;
using FluentValidation.AspNetCore;
using Identity.Domain.DTO;
using Identity.Domain.Validators;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class FluentValidation
	{
		public static IServiceCollection AddMyFluentValidation(this IServiceCollection services)
		{
			services.AddTransient<IValidator<UserDTO>, UserValidator>();
			services.AddTransient<IValidator<LoginUserDTO>, LoginUserValidator>();
			services.AddTransient<IValidator<RoleDTO>, RoleValidator>();
			services.AddTransient<IValidator<CreateUserDTO>, CreateUserValidator>();

			return services;
		}
	}
}
