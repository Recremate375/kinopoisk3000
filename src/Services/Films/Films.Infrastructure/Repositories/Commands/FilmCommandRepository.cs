using Films.Application.Repositories.Commands;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Commands
{
	public class FilmCommandRepository : BaseCommandRepository<Film>, IFilmCommandRepository
	{
		public FilmCommandRepository(FilmsDbContext context) : base(context)
		{
		}

	}
}
