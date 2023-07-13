using Identity.Application.IServices;
using Identity.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Application.Features
{
    public class GenerateJWTService : IGenerateJWTService
	{
		private readonly AuthOptions options;

		public GenerateJWTService(IOptions<AuthOptions> authOptions) 
		{
			options = authOptions.Value;
		}

		private SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Secret));
		}

		public string GenerateJWT(User user)
		{
			var securityKey = GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Name, user.Login),
				new Claim(ClaimTypes.Role, user.UserRole.RoleName)
			};

			var token = new JwtSecurityToken(options.Issuer,
				options.Audience,
				claims,
				expires: DateTime.Now.AddSeconds(options.TokenLifetime),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
