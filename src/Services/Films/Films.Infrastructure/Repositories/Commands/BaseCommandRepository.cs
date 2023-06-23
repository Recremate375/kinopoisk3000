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
		private readonly FilmsDbContext context;
		private readonly DbSet<T> dbSet;

		public BaseCommandRepository(FilmsDbContext context)
		{
			this.context = context;
			this.dbSet = context.Set<T>();
		}

		public async Task CreateAsync(T entity)
		{
			await dbSet.AddAsync(entity);
		}

		public void DeleteAsync(T entity)
		{
			dbSet.Remove(entity);
		}

		public void Update(T entity)
		{
			dbSet.Attach(entity);
			dbSet.Entry(entity).State = EntityState.Modified;
		}
		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
