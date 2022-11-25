using Microsoft.EntityFrameworkCore.Migrations;

namespace Mascotas.Api.Infrastructure.Migrations
{
    public partial class ActualizeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CatRaces",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DogRaces",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CatRaces",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DogRaces",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Owners_OwnerId",
                table: "Pets",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
