using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursusOverzichtApi.Migrations
{
    public partial class Cursusinstantieinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Startdatum",
                table: "cursussen");

            migrationBuilder.CreateTable(
                name: "cursusinstanties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cursusId = table.Column<int>(nullable: true),
                    Startdatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursusinstanties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cursusinstanties_cursussen_cursusId",
                        column: x => x.cursusId,
                        principalTable: "cursussen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cursusinstanties_cursusId",
                table: "cursusinstanties",
                column: "cursusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cursusinstanties");

            migrationBuilder.AddColumn<DateTime>(
                name: "Startdatum",
                table: "cursussen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
