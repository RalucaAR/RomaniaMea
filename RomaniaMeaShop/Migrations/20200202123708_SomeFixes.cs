using Microsoft.EntityFrameworkCore.Migrations;

namespace RomaniaMeaShop.Migrations
{
    public partial class SomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CakeName",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderDetails",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "CakeName",
                table: "OrderDetails",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
