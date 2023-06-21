using Identity.Domain.Models;

namespace Identity.WebApi.ExtensionsMethods
{
	public static class JwtBearerAuthenticationExtension
	{

		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
		{
			var authOptions = config.GetSection("Auth").Get<AuthOptions>();

			services.AddAuthentication().AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = true;
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = authOptions.Issuer,

					ValidateAudience = true,
					ValidAudience = authOptions.Audience,

					ValidateLifetime = true,

					IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
					ValidateIssuerSigningKey = true
				};
			});

			return services;
		}
	}
}
