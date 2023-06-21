using Identity.Domain.DTO;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Repositories
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task CreateAsync(User entity);
		Task<User> GetUserByEmailAsync(string email);
	}
}
