using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ES.Infra.API.Migrations
{
    public partial class RelacionamentoProdutoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SKUCode",
                schema: "estoque",
                table: "Produtos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "estoque",
                table: "Produtos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "estoque",
                table: "Produtos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "estoque",
                table: "Produtos",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "estoque",
                table: "Produtos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estoque",
                schema: "estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoryId",
                schema: "estoque",
                table: "Produtos",
                column: "CategoryId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoque_CategoryId",
                schema: "estoque",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Estoque",
                schema: "estoque");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoryId",
                schema: "estoque",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "estoque",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "SKUCode",
                schema: "estoque",
                table: "Produtos",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "estoque",
                table: "Produtos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                schema: "estoque",
                table: "Produtos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "estoque",
                table: "Produtos",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
