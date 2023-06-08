using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Repositories
{
	public interface IBaseRepository<T> : IDisposable where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		void Update(T entity);
		void Delete(int id);
		Task Save();
	}
}
