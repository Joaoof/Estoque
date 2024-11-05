using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ES.Infra.API.Migrations
{
    public partial class ProductCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoque_CategoryId",
                schema: "estoque",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estoque",
                schema: "estoque",
                table: "Estoque");

            migrationBuilder.RenameTable(
                name: "Estoque",
                schema: "estoque",
                newName: "Categorias",
                newSchema: "estoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                schema: "estoque",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                schema: "estoque",
                table: "Produtos",
                column: "CategoryId",
                principalSchema: "estoque",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoryId",
                schema: "estoque",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                schema: "estoque",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                schema: "estoque",
                newName: "Estoque",
                newSchema: "estoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estoque",
                schema: "estoque",
                table: "Estoque",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoque_CategoryId",
                schema: "estoque",
                table: "Produtos",
                column: "CategoryId",
                principalSchema: "estoque",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
