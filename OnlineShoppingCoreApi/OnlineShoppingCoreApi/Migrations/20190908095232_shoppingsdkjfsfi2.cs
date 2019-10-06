using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingCoreApi.Migrations
{
    public partial class shoppingsdkjfsfi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shippments_OrderDetails_OrderDetailID",
                table: "Shippments");

            migrationBuilder.DropIndex(
                name: "IX_Shippments_OrderDetailID",
                table: "Shippments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shippments_OrderDetailID",
                table: "Shippments",
                column: "OrderDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shippments_OrderDetails_OrderDetailID",
                table: "Shippments",
                column: "OrderDetailID",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
