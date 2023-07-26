namespace Identity.Domain.DTO
{
	public class CreateUserDTO
	{
		public string Email { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}
