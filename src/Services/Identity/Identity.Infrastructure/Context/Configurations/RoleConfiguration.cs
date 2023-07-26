using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Context.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasIndex(u => u.RoleName).IsUnique();
			builder.HasMany(role => role.Users).WithOne(user => user.UserRole)
				.HasForeignKey(user => user.RoleId).IsRequired();
		}
	}
}
