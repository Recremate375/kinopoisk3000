using Films.Application.Repositories.Commands;
using Films.Infrastructure.Context;

namespace Films.Infrastructure.Repositories.Commands
{
	public class TypeCommandRepository : BaseCommandRepository<Domain.Models.FilmType>, ITypeCommandRepository
	{
		public TypeCommandRepository(FilmsDbContext context) : base(context)
		{
		}

	}
}
