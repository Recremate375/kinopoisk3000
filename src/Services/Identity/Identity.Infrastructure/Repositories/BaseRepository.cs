using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
	{
		private readonly IdentityDbContext context;
		private readonly DbSet<T> dbSet;

		public BaseRepository(IdentityDbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		public async Task CreateAsync(T entity)
		{
			await dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await dbSet.AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
