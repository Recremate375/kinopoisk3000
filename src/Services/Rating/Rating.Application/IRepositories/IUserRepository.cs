using Rating.Domain.Models;

namespace Rating.Application.IRepositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetUserByLoginAsync(string login);
	}
}
