using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rating.Infrastructure.Context.Configurations
{
	public class RatingConfiguration : IEntityTypeConfiguration<Domain.Models.Rating>
	{
		public void Configure(EntityTypeBuilder<Domain.Models.Rating> builder)
		{
			builder.HasOne(rating => rating.RatingUser).WithMany(user => user.ratings)
				.HasForeignKey(rating => rating.UserId).IsRequired();
			builder.HasOne(rating => rating.RatingFilm).WithMany(film => film.ratings)
				.HasForeignKey(rating => rating.FilmId).IsRequired();
		}
	}
}
