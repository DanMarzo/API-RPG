using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 102, 44, 114, 228, 231, 163, 159, 152, 120, 27, 4, 42, 96, 52, 2, 247, 225, 248, 185, 176, 178, 246, 156, 44, 167, 68, 116, 220, 247, 176, 48, 153, 125, 182, 253, 216, 70, 153, 75, 167, 43, 35, 182, 249, 17, 148, 51, 133, 137, 45, 118, 127, 242, 235, 64, 139, 2, 214, 184, 224, 28, 97, 74, 22 }, new byte[] { 24, 149, 113, 157, 15, 162, 72, 87, 114, 236, 85, 210, 185, 135, 12, 45, 112, 53, 71, 144, 156, 216, 226, 169, 237, 192, 221, 94, 98, 9, 229, 241, 95, 36, 114, 226, 41, 92, 211, 32, 218, 179, 125, 5, 41, 251, 22, 77, 246, 86, 23, 57, 25, 66, 118, 252, 39, 227, 144, 251, 205, 144, 37, 12, 26, 124, 94, 109, 2, 52, 230, 242, 61, 87, 229, 76, 217, 133, 195, 234, 162, 234, 113, 94, 237, 50, 4, 38, 214, 68, 180, 18, 166, 243, 157, 245, 28, 10, 232, 162, 156, 130, 151, 211, 188, 214, 13, 189, 49, 33, 88, 56, 31, 110, 8, 38, 225, 94, 171, 123, 34, 33, 67, 44, 7, 6, 10, 143 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 65, 139, 14, 254, 99, 98, 52, 250, 80, 55, 200, 162, 66, 203, 102, 114, 189, 60, 10, 84, 35, 44, 65, 151, 156, 9, 58, 230, 238, 176, 72, 244, 234, 157, 56, 242, 26, 88, 74, 154, 122, 133, 142, 63, 252, 183, 99, 204, 6, 70, 2, 232, 159, 108, 248, 64, 82, 5, 228, 181, 83, 166, 63, 56 }, new byte[] { 184, 132, 105, 65, 183, 202, 171, 79, 234, 241, 193, 235, 97, 80, 46, 69, 107, 92, 104, 141, 53, 49, 91, 171, 132, 80, 84, 155, 147, 233, 245, 4, 83, 70, 65, 245, 177, 162, 172, 33, 98, 245, 127, 232, 80, 80, 76, 244, 104, 27, 39, 229, 184, 114, 238, 253, 48, 242, 68, 217, 255, 219, 87, 109, 76, 156, 156, 31, 203, 58, 109, 85, 112, 237, 174, 65, 14, 27, 189, 179, 188, 230, 86, 33, 75, 59, 178, 206, 86, 177, 252, 60, 45, 187, 245, 54, 230, 231, 76, 100, 50, 183, 203, 177, 243, 91, 60, 180, 219, 128, 48, 31, 182, 75, 43, 47, 2, 5, 137, 183, 212, 204, 67, 79, 188, 241, 98, 227 } });
        }
    }
}
