using Films.Infrastructure.Context;
using Films.Application.Repositories.Commands;

namespace Films.Infrastructure.Repositories.Commands
{
	public class TypeCommandRepository : BaseCommandRepository<Domain.Models.FilmType>, ITypeCommandRepository
	{
		private readonly FilmsDbContext _context;

		public TypeCommandRepository(FilmsDbContext context) : base(context)
		{
			_context = context;
		}

	}
}
