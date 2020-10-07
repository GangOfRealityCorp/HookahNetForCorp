using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HookahNet.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalogTable");

            migrationBuilder.DropTable(
                name: "guestUserTable");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "organizationTable");

            migrationBuilder.DropTable(
                name: "productTable");
        }
    }
}
