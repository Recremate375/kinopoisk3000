using AutoMapper;
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
		private readonly DbSet<T> _dbSet;
		private readonly IMapper _mapper;

		public BaseQueryRepository(FilmsDbContext context, IMapper mapper)
		{
			_context = context;
			_dbSet = context.Set<T?>();
			_mapper = mapper;
		}

		public async Task<List<TDto>> GetAllAsync<TDto>() where TDto : BaseDTOEntity
		{
			return await _dbSet.AsNoTracking().ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
		}

		public async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
