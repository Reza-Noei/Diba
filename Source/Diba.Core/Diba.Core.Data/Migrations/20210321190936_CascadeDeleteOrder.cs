using Microsoft.EntityFrameworkCore.Migrations;

namespace Diba.Core.Data.Migrations
{
    public partial class CascadeDeleteOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItem_Order_OrderId",
                table: "RequestItem");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItem_Order_OrderId",
                table: "RequestItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestItem_Order_OrderId",
                table: "RequestItem");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItem_Order_OrderId",
                table: "RequestItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
