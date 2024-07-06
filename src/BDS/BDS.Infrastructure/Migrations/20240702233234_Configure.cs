using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDS.Infrastructure.Migrations
{
    public partial class Configure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoadorId1",
                table: "Doacoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doacoes_DoadorId1",
                table: "Doacoes",
                column: "DoadorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId1",
                table: "Doacoes",
                column: "DoadorId1",
                principalTable: "Doadores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId1",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_DoadorId1",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "DoadorId1",
                table: "Doacoes");
        }
    }
}
