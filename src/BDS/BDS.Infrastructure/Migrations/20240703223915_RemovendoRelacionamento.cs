using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDS.Infrastructure.Migrations
{
    public partial class RemovendoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId1",
                table: "Doacoes");

            migrationBuilder.DropIndex(
                name: "IX_Doacoes_DoadorId1",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "DoadorId1",
                table: "Doacoes");

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
                name: "FK_Doacoes_Doadores_DoadorId",
                table: "Doacoes",
                column: "DoadorId",
                principalTable: "Doadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doacoes_Doadores_DoadorId1",
                table: "Doacoes",
                column: "DoadorId1",
                principalTable: "Doadores",
                principalColumn: "Id");
        }
    }
}
