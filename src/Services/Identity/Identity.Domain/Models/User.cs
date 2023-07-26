namespace Identity.Domain.Models
{
	public class User : BaseEntity
	{
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public int RoleId { get; set; }
		public Role UserRole { get; set; }
	}
}
