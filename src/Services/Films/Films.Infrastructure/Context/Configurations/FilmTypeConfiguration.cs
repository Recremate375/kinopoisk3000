using Films.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.Infrastructure.Context.Configurations
{
	public class FilmTypeConfiguration : IEntityTypeConfiguration<FilmType>
	{
		public void Configure(EntityTypeBuilder<FilmType> builder)
		{
			builder.HasIndex(type => type.TypeName).IsUnique();
			builder.HasMany(type => type.Films).WithOne(film => film.Type)
				.HasForeignKey(film => film.FilmTypeId).IsRequired();
		}
	}
}
