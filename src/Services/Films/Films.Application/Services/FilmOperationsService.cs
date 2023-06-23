using Films.Application.Repositories.Commands;
using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Application.Services
{
	public class FilmOperationsService
	{
		private readonly IFilmCommandRepository filmCommandRepository;
		private readonly IFilmQueryRepository filmQueryRepository;
		public FilmOperationsService(IFilmCommandRepository filmCommandRepository, IFilmQueryRepository filmQueryRepository)
		{
			this.filmQueryRepository = filmQueryRepository;
			this.filmCommandRepository = filmCommandRepository;
		}

		public async Task<List<Film>> GetAllFilmsAsync()
		{
			return await filmQueryRepository.GetAllAsync();
		}
	}
}
