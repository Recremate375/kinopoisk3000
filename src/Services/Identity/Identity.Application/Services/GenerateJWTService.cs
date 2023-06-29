using Identity.Application.IServices;
using Identity.Application.Repositories;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features
{
    public class GenerateJWTService : IGenerateJWTService
	{
		private readonly AuthOptions options;

		public GenerateJWTService(IOptions<AuthOptions> authOptions) 
		{
			options = authOptions.Value;
		}

		public string GenerateJWT(User user)
		{
			var securityKey = options.GetSymmetricSecurityKey();
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
