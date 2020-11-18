using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class AddedPropertiesToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Price",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Price",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Price");
        }
    }
}
