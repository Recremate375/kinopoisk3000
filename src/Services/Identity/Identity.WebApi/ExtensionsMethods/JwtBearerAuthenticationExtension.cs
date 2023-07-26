using Identity.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.Domain.ExtensionsMethods
{
	public static class JwtBearerAuthenticationExtension
	{
		public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
		{
			services.Configure<AuthOptions>(config.GetSection("Auth"));

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

					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authOptions.Secret)),
					ValidateIssuerSigningKey = true
				};
			});

			return services;
		}
	}
}
