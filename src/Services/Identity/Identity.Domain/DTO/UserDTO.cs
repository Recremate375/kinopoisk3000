using Identity.Domain.Models;

namespace Identity.Domain.DTO
{
	public class UserDTO
	{
		public string Email { get; set; }
		public string? Login { get; set; }
		public string? Password { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public Role? UserRole { get; set; }
	}
}
