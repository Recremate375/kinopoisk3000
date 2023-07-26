﻿// <auto-generated />
using System;
using Films.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Films.Infrastructure.Migrations
{
    [DbContext(typeof(FilmsDbContext))]
    [Migration("20230706152444_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Films.Domain.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductionYear")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("TypeFilmTypeId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("TypeFilmTypeId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("Films.Domain.Models.FilmType", b =>
                {
                    b.Property<int>("FilmTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmTypeId"));

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmTypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Films.Domain.Models.Film", b =>
                {
                    b.HasOne("Films.Domain.Models.FilmType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeFilmTypeId");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
