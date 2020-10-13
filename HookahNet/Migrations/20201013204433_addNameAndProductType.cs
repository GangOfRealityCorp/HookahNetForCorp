using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class addNameAndProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "productTable",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                table: "productTable",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "productTable");

            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "productTable");
        }
    }
}
