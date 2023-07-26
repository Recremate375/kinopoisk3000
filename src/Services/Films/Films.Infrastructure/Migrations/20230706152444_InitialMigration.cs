using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    FilmTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.FilmTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFilmTypeId = table.Column<int>(type: "int", nullable: true),
                    TotalMinutes = table.Column<int>(type: "int", nullable: false),
                    ProductionYear = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Films_Types_TypeFilmTypeId",
                        column: x => x.TypeFilmTypeId,
                        principalTable: "Types",
                        principalColumn: "FilmTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_TypeFilmTypeId",
                table: "Films",
                column: "TypeFilmTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
