using Microsoft.EntityFrameworkCore.Migrations;

namespace CursusOverzichtApi.Migrations
{
    public partial class Cursusinstantieprimarykeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cursusinstanties_cursussen_cursusId",
                table: "cursusinstanties");

            migrationBuilder.AlterColumn<int>(
                name: "cursusId",
                table: "cursusinstanties",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cursusinstanties_cursussen_cursusId",
                table: "cursusinstanties",
                column: "cursusId",
                principalTable: "cursussen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cursusinstanties_cursussen_cursusId",
                table: "cursusinstanties");

            migrationBuilder.AlterColumn<int>(
                name: "cursusId",
                table: "cursusinstanties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_cursusinstanties_cursussen_cursusId",
                table: "cursusinstanties",
                column: "cursusId",
                principalTable: "cursussen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
