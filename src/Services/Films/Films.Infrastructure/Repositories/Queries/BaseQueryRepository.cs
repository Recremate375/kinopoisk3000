using Films.Application.Repositories.Queryes;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : class
	{
		private readonly FilmsDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BaseQueryRepository(FilmsDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}
	}
}
