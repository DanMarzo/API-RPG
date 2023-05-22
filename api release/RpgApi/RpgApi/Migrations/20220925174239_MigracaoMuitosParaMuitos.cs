using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Jogador",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 209, 83, 66, 58, 125, 32, 99, 2, 56, 168, 253, 55, 83, 85, 153, 56, 79, 50, 84, 91, 188, 50, 23, 85, 155, 202, 162, 17, 65, 103, 173, 26, 62, 53, 105, 183, 68, 38, 136, 228, 124, 73, 95, 169, 102, 182, 30, 70, 77, 238, 93, 9, 38, 14, 122, 27, 57, 58, 152, 176, 95, 59, 88 }, new byte[] { 82, 28, 198, 215, 191, 138, 155, 3, 115, 38, 250, 145, 22, 123, 69, 84, 98, 74, 191, 90, 215, 30, 195, 255, 91, 194, 167, 33, 104, 78, 222, 85, 90, 231, 131, 121, 207, 108, 168, 123, 34, 119, 196, 243, 204, 17, 137, 27, 185, 26, 71, 189, 211, 137, 208, 160, 127, 246, 251, 0, 140, 71, 249, 89, 152, 141, 71, 65, 171, 145, 79, 150, 255, 254, 214, 188, 170, 120, 144, 85, 114, 249, 219, 54, 141, 228, 158, 83, 155, 130, 122, 182, 224, 180, 39, 188, 227, 208, 255, 136, 14, 209, 94, 82, 17, 153, 56, 229, 135, 196, 154, 127, 71, 66, 116, 89, 122, 15, 252, 246, 32, 29, 158, 246, 215, 28, 48, 148 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Jogador");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 161, 136, 76, 174, 145, 155, 223, 101, 14, 192, 247, 60, 192, 103, 235, 180, 124, 216, 247, 232, 134, 3, 178, 221, 65, 181, 28, 220, 254, 87, 153, 24, 107, 246, 255, 176, 103, 189, 122, 27, 40, 89, 68, 148, 152, 90, 28, 92, 31, 46, 87, 51, 188, 185, 57, 126, 70, 65, 220, 68, 214, 95, 171, 231 }, new byte[] { 218, 140, 77, 226, 240, 211, 9, 71, 19, 176, 31, 227, 145, 246, 138, 48, 75, 71, 51, 86, 117, 12, 205, 122, 161, 4, 100, 40, 89, 99, 0, 137, 145, 88, 20, 85, 168, 194, 139, 188, 6, 116, 124, 128, 208, 213, 78, 39, 81, 226, 154, 53, 71, 189, 132, 121, 93, 55, 91, 59, 101, 32, 55, 122, 64, 160, 142, 80, 229, 42, 122, 130, 102, 216, 129, 233, 53, 169, 54, 167, 158, 218, 120, 233, 191, 66, 152, 22, 30, 204, 238, 46, 213, 134, 213, 243, 55, 77, 99, 141, 79, 167, 34, 103, 95, 116, 81, 64, 125, 157, 115, 109, 219, 247, 73, 113, 108, 244, 78, 88, 184, 152, 9, 83, 110, 227, 161, 26 } });
        }
    }
}
