using Films.Application.Repositories.Commands;
using Films.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Commands
{
	public class TypeCommandRepository : BaseCommandRepository<Domain.Models.FilmType>, ITypeCommandRepository
	{
		private readonly FilmsDbContext context;

		public TypeCommandRepository(FilmsDbContext context) : base(context)
		{
			this.context = context;
		}

	}
}
