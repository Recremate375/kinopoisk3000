namespace Identity.Domain.Models
{
	public class Role : BaseEntity
	{
		public string RoleName { get; set; }
		public ICollection<User> Users { get; } = new List<User>();
	}
}
