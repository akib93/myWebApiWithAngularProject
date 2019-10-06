using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingCoreApi.Migrations
{
    public partial class DeleteArcfff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Customers_CustomerID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CustomerID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "OrderDetails",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "OrderDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerUnit",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBill",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UniqueID",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompletedOrders",
                columns: table => new
                {
                    CompletedOrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderDetailID = table.Column<int>(nullable: false),
                    DateOfCompliletion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedOrders", x => x.CompletedOrderID);
                    table.ForeignKey(
                        name: "FK_CompletedOrders_OrderDetails_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomShippingAddress",
                columns: table => new
                {
                    CustomShippingAddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniqueOrderID = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomShippingAddress", x => x.CustomShippingAddressID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedOrders_OrderDetailID",
                table: "CompletedOrders",
                column: "OrderDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedOrders");

            migrationBuilder.DropTable(
                name: "CustomShippingAddress");

            migrationBuilder.DropColumn(
                name: "PricePerUnit",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalBill",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UniqueID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderDetails",
                newName: "ShippingAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CustomerID",
                table: "OrderDetails",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Customers_CustomerID",
                table: "OrderDetails",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
