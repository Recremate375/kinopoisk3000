using Films.Infrastructure.Context;
using Films.Application.Repositories.Commands;

namespace Films.Infrastructure.Repositories.Commands
{
	public class TypeCommandRepository : BaseCommandRepository<Domain.Models.FilmType>, ITypeCommandRepository
	{
		public TypeCommandRepository(FilmsDbContext context) : base(context)
		{
		}

	}
}
