using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rating.Domain.Models;

namespace Rating.Infrastructure.Context.Configurations
{
	public class FilmConfiguration : IEntityTypeConfiguration<Film>
	{
		public void Configure(EntityTypeBuilder<Film> builder)
		{
			builder.HasIndex(film => film.FilmName).IsUnique();
			builder.HasMany(film => film.ratings).WithOne(rating => rating.RatingFilm)
				.HasForeignKey(rating => rating.FilmId).IsRequired();
		}
	}
}
