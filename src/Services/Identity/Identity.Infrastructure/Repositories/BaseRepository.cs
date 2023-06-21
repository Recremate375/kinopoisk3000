using Identity.Application.Repositories;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T: class
	{
		private readonly IdentityDbContext context;
		private readonly DbSet<T> dbSet;

		public BaseRepository(IdentityDbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		public async void DeleteAsync(int id)
		{
			T? entity = await GetByIdAsync(id);

			if (entity != null)
			{
				dbSet.Remove(entity);
			}
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await dbSet.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await dbSet.FindAsync(id);
		}

		public async Task SaveAsync()
		{
			await context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			dbSet.Attach(entity);
			dbSet.Entry(entity).State = EntityState.Modified;
		}
	}
}
