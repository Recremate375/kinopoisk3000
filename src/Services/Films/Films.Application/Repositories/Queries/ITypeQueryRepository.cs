using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Repositories.Queryes
{
	public interface ITypeQueryRepository : IBaseQueryRepository<Domain.Models.FilmType>
	{
		Task<Domain.Models.FilmType> GetTypeByNameAsync(string typeName);
	}
}
