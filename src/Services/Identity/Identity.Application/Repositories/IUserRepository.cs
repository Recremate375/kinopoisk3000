using Identity.Domain.Models;

namespace Identity.Application.Repositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetUserByEmailAsync(string email);
	}
}
