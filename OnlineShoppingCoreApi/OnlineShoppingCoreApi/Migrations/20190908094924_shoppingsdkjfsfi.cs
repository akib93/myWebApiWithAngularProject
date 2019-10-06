using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingCoreApi.Migrations
{
    public partial class shoppingsdkjfsfi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancelOrders_OrderDetails_OrderDetailID",
                table: "CancelOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedOrders_OrderDetails_OrderDetailID",
                table: "CompletedOrders");

            migrationBuilder.DropIndex(
                name: "IX_CompletedOrders_OrderDetailID",
                table: "CompletedOrders");

            migrationBuilder.DropIndex(
                name: "IX_CancelOrders_OrderDetailID",
                table: "CancelOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CompletedOrders_OrderDetailID",
                table: "CompletedOrders",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_CancelOrders_OrderDetailID",
                table: "CancelOrders",
                column: "OrderDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_CancelOrders_OrderDetails_OrderDetailID",
                table: "CancelOrders",
                column: "OrderDetailID",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedOrders_OrderDetails_OrderDetailID",
                table: "CompletedOrders",
                column: "OrderDetailID",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
