using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
	public class AuthOptions
	{
		public string Issuer { get; set; } = "IdentityServer";
		public string Audience { get; set; } = "ResourseServer";
		public string Secret { get; set; } = "MySuperMegaReallyGoodSecretKey";
		public int TokenLifetime { get; set; } = 3600;
		public SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
		}
	}
}
