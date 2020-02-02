using Microsoft.EntityFrameworkCore.Migrations;

namespace RomaniaMeaShop.Migrations
{
    public partial class OrderState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderState",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Order");
        }
    }
}
