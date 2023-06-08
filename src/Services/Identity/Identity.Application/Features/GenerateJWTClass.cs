using Identity.Application.Repositories;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
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
		private string Issuer = "IdentityServer";
		private string Audience = "IdentityServer";
		private string Secret = "MySuperMegaReallyGoodSecretKey";
		private int TokenLifeTime = 3600;
		private IRoleRepository roleRepository;

		public GenerateJWTClass(IRoleRepository roleRepository) 
		{
			this.roleRepository = roleRepository;
		}

		private SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
		}

		public string GenerateJWT(User user)
		{
			var roles = roleRepository.GetAll();
			var securityKey = GetSymmetricSecurityKey();
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.Name, user.Login)
			};

			claims.Add(new Claim("role", user.UserRole.RoleName));

			var token = new JwtSecurityToken(Issuer,
				Audience,
				claims,
				expires: DateTime.Now.AddSeconds(TokenLifeTime),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
