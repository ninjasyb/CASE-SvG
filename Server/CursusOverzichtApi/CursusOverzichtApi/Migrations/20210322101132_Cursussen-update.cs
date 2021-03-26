using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursusOverzichtApi.Migrations
{
    public partial class Cursussenupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Startdatum",
                table: "cursussen",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CursusCode",
                table: "cursussen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CursusCode",
                table: "cursussen");

            migrationBuilder.AlterColumn<string>(
                name: "Startdatum",
                table: "cursussen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
