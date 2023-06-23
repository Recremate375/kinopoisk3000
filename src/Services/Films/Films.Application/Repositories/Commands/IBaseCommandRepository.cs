using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Repositories.Commands
{
	public interface IBaseCommandRepository<T> where T : class
	{
		Task CreateAsync(T entity);
		void Update(T entity);
		void DeleteAsync(T entity);
		Task SaveAsync();
	}
}
