using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoArma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_personagens",
                table: "personagens");

            migrationBuilder.RenameTable(
                name: "personagens",
                newName: "Personagens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personagens",
                table: "Personagens",
                column: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personagens",
                table: "Personagens");

            migrationBuilder.RenameTable(
                name: "Personagens",
                newName: "personagens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_personagens",
                table: "personagens",
                column: "Id");
        }
    }
}
