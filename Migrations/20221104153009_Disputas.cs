using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class Disputas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "UserName");

            migrationBuilder.CreateTable(
                name: "TB_Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Disputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    TX_Narracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 214, 12, 72, 48, 27, 2, 226, 31, 66, 110, 33, 176, 173, 229, 118, 243, 22, 2, 246, 196, 51, 134, 218, 137, 123, 98, 174, 221, 252, 226, 62, 141, 4, 250, 169, 143, 229, 69, 4, 195, 73, 165, 45, 189, 76, 168, 165, 140, 78, 116, 30, 74, 130, 133, 242, 201, 251, 88, 1, 69, 23, 253, 224, 50 }, new byte[] { 207, 61, 122, 47, 153, 22, 237, 170, 122, 174, 61, 188, 118, 16, 110, 145, 64, 254, 226, 201, 221, 22, 232, 143, 184, 221, 237, 179, 199, 190, 163, 8, 182, 63, 121, 228, 172, 214, 116, 216, 46, 93, 26, 198, 40, 91, 67, 191, 157, 238, 51, 81, 246, 92, 32, 24, 137, 169, 211, 66, 167, 193, 85, 87, 221, 233, 34, 85, 108, 42, 10, 221, 1, 90, 224, 136, 253, 158, 170, 20, 76, 120, 3, 161, 60, 167, 21, 12, 104, 39, 24, 4, 16, 3, 108, 114, 252, 41, 24, 225, 236, 224, 114, 214, 50, 74, 224, 213, 131, 48, 96, 189, 142, 24, 136, 204, 109, 64, 171, 152, 135, 130, 244, 13, 230, 0, 55, 211 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Disputas");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 29, 144, 101, 144, 30, 202, 2, 91, 169, 26, 230, 94, 61, 154, 48, 143, 40, 222, 145, 15, 54, 191, 102, 218, 91, 86, 125, 78, 242, 90, 234, 72, 194, 136, 164, 56, 31, 83, 187, 156, 137, 203, 160, 111, 180, 61, 10, 118, 50, 123, 230, 53, 213, 219, 238, 235, 57, 204, 84, 238, 238, 30, 184, 150 }, new byte[] { 59, 196, 221, 157, 6, 55, 194, 251, 16, 168, 165, 145, 216, 193, 54, 35, 228, 58, 189, 194, 253, 64, 17, 107, 235, 83, 43, 165, 176, 4, 151, 45, 255, 233, 124, 172, 53, 40, 253, 62, 0, 41, 175, 70, 19, 79, 85, 71, 155, 41, 232, 134, 192, 28, 218, 108, 179, 187, 86, 143, 196, 254, 65, 247, 244, 173, 14, 151, 102, 21, 132, 219, 214, 66, 77, 171, 186, 146, 106, 189, 98, 15, 211, 113, 112, 212, 74, 219, 56, 50, 119, 73, 23, 251, 139, 253, 199, 64, 0, 88, 183, 205, 4, 97, 28, 198, 107, 138, 144, 248, 104, 239, 75, 161, 18, 64, 28, 24, 238, 247, 67, 143, 19, 150, 92, 89, 36, 201 } });
        }
    }
}
