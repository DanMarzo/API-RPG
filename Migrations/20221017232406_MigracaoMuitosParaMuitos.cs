using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Habilidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidade", x => x.Id);
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
                        name: "FK_PersonagemHabilidades_Habilidade_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidade",
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
                table: "Habilidade",
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
                columns: new[] { "Email", "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { "seuEmail@gmail.com", -23.520024100000001, -46.596497999999997, new byte[] { 29, 144, 101, 144, 30, 202, 2, 91, 169, 26, 230, 94, 61, 154, 48, 143, 40, 222, 145, 15, 54, 191, 102, 218, 91, 86, 125, 78, 242, 90, 234, 72, 194, 136, 164, 56, 31, 83, 187, 156, 137, 203, 160, 111, 180, 61, 10, 118, 50, 123, 230, 53, 213, 219, 238, 235, 57, 204, 84, 238, 238, 30, 184, 150 }, new byte[] { 59, 196, 221, 157, 6, 55, 194, 251, 16, 168, 165, 145, 216, 193, 54, 35, 228, 58, 189, 194, 253, 64, 17, 107, 235, 83, 43, 165, 176, 4, 151, 45, 255, 233, 124, 172, 53, 40, 253, 62, 0, 41, 175, 70, 19, 79, 85, 71, 155, 41, 232, 134, 192, 28, 218, 108, 179, 187, 86, 143, 196, 254, 65, 247, 244, 173, 14, 151, 102, 21, 132, 219, 214, 66, 77, 171, 186, 146, 106, 189, 98, 15, 211, 113, 112, 212, 74, 219, 56, 50, 119, 73, 23, 251, 139, 253, 199, 64, 0, 88, 183, 205, 4, 97, 28, 198, 107, 138, 144, 248, 104, 239, 75, 161, 18, 64, 28, 24, 238, 247, 67, 143, 19, 150, 92, 89, 36, 201 } });

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
                name: "Habilidade");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Latitude", "Longitude", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null, null, new byte[] { 102, 44, 114, 228, 231, 163, 159, 152, 120, 27, 4, 42, 96, 52, 2, 247, 225, 248, 185, 176, 178, 246, 156, 44, 167, 68, 116, 220, 247, 176, 48, 153, 125, 182, 253, 216, 70, 153, 75, 167, 43, 35, 182, 249, 17, 148, 51, 133, 137, 45, 118, 127, 242, 235, 64, 139, 2, 214, 184, 224, 28, 97, 74, 22 }, new byte[] { 24, 149, 113, 157, 15, 162, 72, 87, 114, 236, 85, 210, 185, 135, 12, 45, 112, 53, 71, 144, 156, 216, 226, 169, 237, 192, 221, 94, 98, 9, 229, 241, 95, 36, 114, 226, 41, 92, 211, 32, 218, 179, 125, 5, 41, 251, 22, 77, 246, 86, 23, 57, 25, 66, 118, 252, 39, 227, 144, 251, 205, 144, 37, 12, 26, 124, 94, 109, 2, 52, 230, 242, 61, 87, 229, 76, 217, 133, 195, 234, 162, 234, 113, 94, 237, 50, 4, 38, 214, 68, 180, 18, 166, 243, 157, 245, 28, 10, 232, 162, 156, 130, 151, 211, 188, 214, 13, 189, 49, 33, 88, 56, 31, 110, 8, 38, 225, 94, 171, 123, 34, 33, 67, 44, 7, 6, 10, 143 } });
        }
    }
}
