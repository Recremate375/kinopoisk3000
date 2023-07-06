using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class TypeQueryRepository : BaseQueryRepository<Domain.Models.FilmType>, ITypeQueryRepository
	{
		private readonly FilmsDbContext context;

		public TypeQueryRepository(FilmsDbContext context) : base(context)
		{
			this.context = context;
		}

		public async Task<Domain.Models.FilmType> GetTypeByNameAsync(string typeName)
		{
			return await context.Types.FirstOrDefaultAsync(x => x.TypeName == typeName);
		}
	}
}
