using Films.Application.Repositories.Queryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : class
	{
		public Task<IReadOnlyList<T>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
