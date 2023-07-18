using Films.Application.Repositories.Queryes;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.Repositories.Queries
{
	public class TypeQueryRepository : BaseQueryRepository<Domain.Models.FilmType?>, ITypeQueryRepository
	{
		public TypeQueryRepository(FilmsDbContext context) : base(context)
		{

		}

		public async Task<Domain.Models.FilmType?> GetTypeByNameAsync(string typeName)
		{
			return await _context.Types.AsNoTracking().FirstOrDefaultAsync(x => x.TypeName == typeName);
		}
	}
}
