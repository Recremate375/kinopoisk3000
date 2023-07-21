using Microsoft.EntityFrameworkCore;
using Rating.Application.IRepositories;
using Rating.Domain.Models;
using Rating.Infrastructure.Context;

namespace Rating.Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
	{
		protected readonly RatingDbContext _context;
		private readonly DbSet<T> _dbSet;

        public BaseRepository(RatingDbContext context)
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
