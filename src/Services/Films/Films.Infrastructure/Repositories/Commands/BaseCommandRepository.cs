using Films.Application.Repositories.Commands;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Commands
{
	public class BaseCommandRepository<T> : IBaseCommandRepository<T> where T : class
	{
		private readonly FilmsDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BaseCommandRepository(FilmsDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Attach(entity);
			_dbSet.Entry(entity).State = EntityState.Modified;
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
