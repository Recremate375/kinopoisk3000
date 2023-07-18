using AutoMapper.QueryableExtensions;
using Films.Application.Repositories.Queryes;
using Films.Domain.DTO;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.Repositories.Queries
{
	public class BaseQueryRepository<T> : IBaseQueryRepository<T> where T : BaseEntity
	{
		protected readonly FilmsDbContext _context;
		private readonly DbSet<T?> _dbSet;

		public BaseQueryRepository(FilmsDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T?>();
		}

		public async Task<List<T?>> GetAllAsync<TDto>() where TDto : class
		{
			return await _dbSet.AsNoTracking().ToListAsync(); //ProjectTo()
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
