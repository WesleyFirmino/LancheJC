using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesJC.Migrations
{
    public partial class PopularCategoriaMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Normal', 'Lanches feito com ingredientes normais.')");
            migrationBuilder.Sql("INSERT INTO Categorias (Nome, Descricao) VALUES ('Natural', 'Lanches feito com ingredientes naturais.')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
