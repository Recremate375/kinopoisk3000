using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
	{
		protected readonly IdentityDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BaseRepository(IdentityDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public async Task<T?> CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);

			return entity;
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			_dbSet.Attach(entity);
			_dbSet.Entry(entity).State = EntityState.Modified;
		}
	}
}
