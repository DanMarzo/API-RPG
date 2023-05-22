using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

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
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, null, null, null, new byte[] { 122, 121, 48, 123, 149, 160, 45, 235, 12, 60, 235, 116, 138, 172, 81, 127, 112, 237, 199, 26, 205, 73, 137, 220, 203, 60, 89, 160, 154, 141, 196, 194, 119, 190, 90, 123, 83, 191, 20, 24, 172, 83, 5, 215, 61, 33, 156, 2, 195, 150, 91, 9, 133, 109, 102, 228, 122, 238, 99, 124, 232, 170, 51, 110 }, new byte[] { 146, 135, 4, 221, 73, 108, 85, 247, 63, 68, 205, 106, 246, 75, 48, 44, 31, 40, 207, 3, 6, 114, 44, 97, 189, 193, 43, 183, 211, 254, 12, 144, 171, 195, 91, 89, 140, 96, 215, 15, 51, 241, 125, 49, 181, 230, 13, 205, 32, 117, 122, 152, 18, 240, 184, 233, 204, 161, 4, 21, 170, 73, 93, 168, 83, 240, 62, 119, 202, 51, 248, 32, 196, 136, 244, 13, 211, 163, 46, 41, 131, 165, 174, 167, 248, 62, 224, 71, 6, 233, 178, 86, 207, 27, 144, 219, 216, 107, 104, 176, 1, 98, 92, 47, 70, 215, 212, 153, 247, 252, 153, 121, 161, 145, 38, 57, 208, 177, 138, 22, 179, 108, 142, 56, 4, 4, 70, 99 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");
        }
    }
}
