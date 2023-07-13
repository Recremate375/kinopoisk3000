using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Identity.Domain.Models
{
	public class AuthOptions
	{
		public string Issuer { get; set; }

		public string Audience { get; set; } 

		public string Secret { get; set; }
		
		public int TokenLifetime { get; set; }
	}
}
