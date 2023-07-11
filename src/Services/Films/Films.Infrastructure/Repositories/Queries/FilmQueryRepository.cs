﻿using Films.Application.Repositories.Queryes;
using Films.Domain.Models;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Repositories.Queries
{
	public class FilmQueryRepository : BaseQueryRepository<Film>, IFilmQueryRepository
	{
		private readonly FilmsDbContext _context;

		public FilmQueryRepository(FilmsDbContext context) : base(context)
		{
			_context = context;
		}

		public new async Task<List<Film>> GetAllAsync()
		{
			return await _context.Films.Include(x => x.Type).AsNoTracking().ToListAsync();
		}

		public async Task<Film> GetFilmByNameAsync(string filmName)
		{
			return await _context.Films.FirstOrDefaultAsync(x => x.FilmName == filmName);
		}

		public async Task<List<Film>> GetFilmsByProductionYear(DateTime filmDate)
		{
			return await _context.Films.AsNoTracking().Where(x => x.ProductionYear == filmDate).ToListAsync();
		}

		public async Task<List<Film>> GetFilmsByTypeAsync(FilmType filmtype)
		{
			return await _context.Films.AsNoTracking().Where(x => x.Type == filmtype).ToListAsync();
		}
	}
}
