using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Repositories.Commands
{
	public interface IFilmCommandRepository : IBaseCommandRepository<Film>
	{

	}
}
