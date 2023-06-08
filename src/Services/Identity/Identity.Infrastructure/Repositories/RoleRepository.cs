using Identity.Application.Repositories;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly IdentityDbContext _context;
		public RoleRepository(IdentityDbContext context)
		{
			_context = context;
		}

		public async Task Create(Role entity)
		{
			await _context.Roles.AddAsync(entity);
			await Save();
		}

		public async void Delete(int id)
		{
			Role? role = await GetById(id);
			if (role != null)
			{
				_context.Roles.Remove(role);
				await Save();
			}
		}

		private bool disposed = false;
		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}

			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<List<Role>> GetAll()
		{
			return await _context.Roles.ToListAsync();
		}

		public async Task<Role> GetById(int id)
		{
			return await _context.Roles.FindAsync(id);
		}

		public async Task<Role> GetRoleByName(string roleName)
		{
			return await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == roleName);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public void Update(Role entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
