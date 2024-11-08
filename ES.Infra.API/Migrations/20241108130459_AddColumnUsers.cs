using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ES.Infra.API.Migrations
{
    public partial class AddColumnUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_UserRoles_UserRoleId",
                schema: "estoque",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "estoque");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UserRoleId",
                schema: "estoque",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                schema: "estoque",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "estoque",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "estoque",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                schema: "estoque",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "estoque",
                table: "UserRoles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                schema: "estoque",
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserRoleId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UserRoleId",
                schema: "estoque",
                table: "Usuarios",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_UserRoles_UserRoleId",
                schema: "estoque",
                table: "Usuarios",
                column: "UserRoleId",
                principalSchema: "estoque",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
