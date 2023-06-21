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
	public class GenerateJWTClass
	{
		private IRoleRepository roleRepository;
		private AuthOptions options = new();

		public GenerateJWTClass(IRoleRepository roleRepository, IOptions<AuthOptions> authOptions) 
		{
			this.roleRepository = roleRepository;
		}

		private SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Secret));
		}

		public string GenerateJWT(User user)
		{
			
			var roles = roleRepository.GetAllAsync();
			var securityKey = GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Name, user.Login),
				new Claim("role", user.UserRole.RoleName)
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
