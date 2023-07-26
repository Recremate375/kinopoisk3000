using Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Context.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasIndex(u => u.Email).IsUnique();
			builder.HasOne(user => user.UserRole).WithMany(user => user.Users)
				.HasForeignKey(user => user.RoleId).IsRequired();
		}
	}
}
