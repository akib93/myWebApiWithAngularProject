using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingCoreApi.Migrations
{
    public partial class AllModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_OrderDetails_OrderDetailID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderDetailID",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "Shippments",
                newName: "UniqueID");

            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "Payments",
                newName: "UniqueID");

            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "CompletedOrders",
                newName: "UniqueID");

            migrationBuilder.RenameColumn(
                name: "OrderDetailID",
                table: "CancelOrders",
                newName: "UniqueID");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Shippments",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BillBeforeTax",
                table: "Payments",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UniqueID",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shippments");

            migrationBuilder.DropColumn(
                name: "BillBeforeTax",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UniqueID",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UniqueID",
                table: "Shippments",
                newName: "OrderDetailID");

            migrationBuilder.RenameColumn(
                name: "UniqueID",
                table: "Payments",
                newName: "OrderDetailID");

            migrationBuilder.RenameColumn(
                name: "UniqueID",
                table: "CompletedOrders",
                newName: "OrderDetailID");

            migrationBuilder.RenameColumn(
                name: "UniqueID",
                table: "CancelOrders",
                newName: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderDetailID",
                table: "Payments",
                column: "OrderDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_OrderDetails_OrderDetailID",
                table: "Payments",
                column: "OrderDetailID",
                principalTable: "OrderDetails",
                principalColumn: "OrderDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
