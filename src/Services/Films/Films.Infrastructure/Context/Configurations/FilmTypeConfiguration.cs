using Films.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Films.Infrastructure.Context.Configurations
{
	public class FilmTypeConfiguration : IEntityTypeConfiguration<FilmType>
	{
		public void Configure(EntityTypeBuilder<FilmType> builder)
		{
			builder.HasIndex(type => type.TypeName).IsUnique();
		}
	}
}
