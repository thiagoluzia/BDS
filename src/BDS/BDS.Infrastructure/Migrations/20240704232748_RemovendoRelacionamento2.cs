using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDS.Infrastructure.Migrations
{
    public partial class RemovendoRelacionamento2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes",
                column: "DoadorId",
                principalTable: "Doadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Doadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes",
                column: "DoadorId",
                principalTable: "Doadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
