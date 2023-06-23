using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class TypeCommandRepository : BaseQueryRepository<Domain.Models.Type>, ITypeQueryRepository
	{
		private readonly FilmsDbContext context;

		public TypeCommandRepository(FilmsDbContext context) : base(context)
		{
			this.context = context;
		}

	}
}
