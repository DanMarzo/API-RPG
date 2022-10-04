using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PontosVida = table.Column<int>(type: "int", nullable: false),
                    Forca = table.Column<int>(type: "int", nullable: false),
                    Defesa = table.Column<int>(type: "int", nullable: false),
                    Inteligencia = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false),
                    FotoPersonagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personagens_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 48, "Cajado Assis" },
                    { 2, 58, "Espada Z" },
                    { 3, 55, "Machado Leviatã" },
                    { 4, 30, "Glimorio Tinhoso" },
                    { 5, 20, "Espada Comum" },
                    { 6, 10, "Varinha Azkan" },
                    { 7, 25, "Livro de invocação" }
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "FotoPersonagem", "Inteligencia", "Nome", "PontosVida", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, null, 33, "Frodo", 100, null },
                    { 2, 1, 25, 15, null, 30, "Sam", 100, null },
                    { 3, 3, 21, 18, null, 35, "Galadriel", 100, null },
                    { 4, 2, 18, 18, null, 37, "Gandalf", 100, null },
                    { 5, 1, 17, 20, null, 31, "Hobbit", 100, null },
                    { 6, 3, 13, 21, null, 34, "Celeborn", 100, null },
                    { 7, 2, 11, 25, null, 35, "Radagast", 100, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, null, null, null, null, new byte[] { 65, 139, 14, 254, 99, 98, 52, 250, 80, 55, 200, 162, 66, 203, 102, 114, 189, 60, 10, 84, 35, 44, 65, 151, 156, 9, 58, 230, 238, 176, 72, 244, 234, 157, 56, 242, 26, 88, 74, 154, 122, 133, 142, 63, 252, 183, 99, 204, 6, 70, 2, 232, 159, 108, 248, 64, 82, 5, 228, 181, 83, 166, 63, 56 }, new byte[] { 184, 132, 105, 65, 183, 202, 171, 79, 234, 241, 193, 235, 97, 80, 46, 69, 107, 92, 104, 141, 53, 49, 91, 171, 132, 80, 84, 155, 147, 233, 245, 4, 83, 70, 65, 245, 177, 162, 172, 33, 98, 245, 127, 232, 80, 80, 76, 244, 104, 27, 39, 229, 184, 114, 238, 253, 48, 242, 68, 217, 255, 219, 87, 109, 76, 156, 156, 31, 203, 58, 109, 85, 112, 237, 174, 65, 14, 27, 189, 179, 188, 230, 86, 33, 75, 59, 178, 206, 86, 177, 252, 60, 45, 187, 245, 54, 230, 231, 76, 100, 50, 183, 203, 177, 243, 91, 60, 180, 219, 128, 48, 31, 182, 75, 43, 47, 2, 5, 137, 183, 212, 204, 67, 79, 188, 241, 98, 227 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
