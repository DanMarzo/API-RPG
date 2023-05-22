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
                values: new object[] { new byte[] { 161, 136, 76, 174, 145, 155, 223, 101, 14, 192, 247, 60, 192, 103, 235, 180, 124, 216, 247, 232, 134, 3, 178, 221, 65, 181, 28, 220, 254, 87, 153, 24, 107, 246, 255, 176, 103, 189, 122, 27, 40, 89, 68, 148, 152, 90, 28, 92, 31, 46, 87, 51, 188, 185, 57, 126, 70, 65, 220, 68, 214, 95, 171, 231 }, new byte[] { 218, 140, 77, 226, 240, 211, 9, 71, 19, 176, 31, 227, 145, 246, 138, 48, 75, 71, 51, 86, 117, 12, 205, 122, 161, 4, 100, 40, 89, 99, 0, 137, 145, 88, 20, 85, 168, 194, 139, 188, 6, 116, 124, 128, 208, 213, 78, 39, 81, 226, 154, 53, 71, 189, 132, 121, 93, 55, 91, 59, 101, 32, 55, 122, 64, 160, 142, 80, 229, 42, 122, 130, 102, 216, 129, 233, 53, 169, 54, 167, 158, 218, 120, 233, 191, 66, 152, 22, 30, 204, 238, 46, 213, 134, 213, 243, 55, 77, 99, 141, 79, 167, 34, 103, 95, 116, 81, 64, 125, 157, 115, 109, 219, 247, 73, 113, 108, 244, 78, 88, 184, 152, 9, 83, 110, 227, 161, 26 } });

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
                values: new object[] { new byte[] { 122, 121, 48, 123, 149, 160, 45, 235, 12, 60, 235, 116, 138, 172, 81, 127, 112, 237, 199, 26, 205, 73, 137, 220, 203, 60, 89, 160, 154, 141, 196, 194, 119, 190, 90, 123, 83, 191, 20, 24, 172, 83, 5, 215, 61, 33, 156, 2, 195, 150, 91, 9, 133, 109, 102, 228, 122, 238, 99, 124, 232, 170, 51, 110 }, new byte[] { 146, 135, 4, 221, 73, 108, 85, 247, 63, 68, 205, 106, 246, 75, 48, 44, 31, 40, 207, 3, 6, 114, 44, 97, 189, 193, 43, 183, 211, 254, 12, 144, 171, 195, 91, 89, 140, 96, 215, 15, 51, 241, 125, 49, 181, 230, 13, 205, 32, 117, 122, 152, 18, 240, 184, 233, 204, 161, 4, 21, 170, 73, 93, 168, 83, 240, 62, 119, 202, 51, 248, 32, 196, 136, 244, 13, 211, 163, 46, 41, 131, 165, 174, 167, 248, 62, 224, 71, 6, 233, 178, 86, 207, 27, 144, 219, 216, 107, 104, 176, 1, 98, 92, 47, 70, 215, 212, 153, 247, 252, 153, 121, 161, 145, 38, 57, 208, 177, 138, 22, 179, 108, 142, 56, 4, 4, 70, 99 } });
        }
    }
}
