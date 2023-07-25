using Films.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Films.Infrastructure.Context.Configurations
{
	public class FilmConfiguration : IEntityTypeConfiguration<Film>
	{
		public void Configure(EntityTypeBuilder<Film> builder)
		{
			builder.HasIndex(film => film.FilmName).IsUnique();
		}
	}
}
