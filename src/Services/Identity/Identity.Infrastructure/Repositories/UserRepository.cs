using Identity.Application.Repositories;
using Identity.Domain.DTO;
using Identity.Domain.Models;
using Identity.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Identity.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IdentityDbContext _context;
		private readonly IRoleRepository roleRepository;
		public UserRepository(IdentityDbContext context, IRoleRepository roleRepository)
		{
			_context = context;
			this.roleRepository = roleRepository;
		}

		public async Task<User> GetUserByEmail(string email)
		{
			var user = await _context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Email == email);
			return user;
		}

		public async Task Create(CreateUserDTO entity)
		{
			User user = new User
			{
				Email = entity.Email,
				Password = entity.Password,
				Login = entity.Login,
				Name = entity.Name,
				Surname = entity.Surname,
				UserRole = await roleRepository.GetRoleByName("admin")
			};

			await _context.Users.AddAsync(user);
		}

		public async void Delete(int id)
		{
			User? user = await GetById(id);
			if (user != null)
			{
				_context.Users.Remove(user);
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

		public async Task<List<User>> GetAll()
		{
			return await _context.Users.Include(x => x.UserRole).ToListAsync();
		}

		public async Task<User> GetById(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		public void Update(User entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}
