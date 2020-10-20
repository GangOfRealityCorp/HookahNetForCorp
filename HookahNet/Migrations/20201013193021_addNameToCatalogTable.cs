using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class addNameToCatalogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "productTable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "catalogTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "productTable");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "catalogTable");
        }
    }
}
