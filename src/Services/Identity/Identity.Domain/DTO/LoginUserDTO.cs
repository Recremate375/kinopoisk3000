using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.DTO
{
	public class LoginUserDTO
	{
		[EmailAddress]
		public string? Email { get; set; }
		public string? Password { get; set; }
	}
}
