namespace Films.Application.Repositories.Queryes
{
	public interface ITypeQueryRepository : IBaseQueryRepository<Domain.Models.FilmType>
	{
		Task<Domain.Models.FilmType?> GetTypeByNameAsync(string typeName);
	}
}
