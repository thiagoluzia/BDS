using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDS.Infrastructure.Migrations
{
    public partial class NovoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes",
                column: "DoadorId",
                principalTable: "Doadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes",
                column: "DoadorId",
                principalTable: "Doadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
