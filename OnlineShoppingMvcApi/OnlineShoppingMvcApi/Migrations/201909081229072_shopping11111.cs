namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping11111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CancelOrders", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.CompletedOrders", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.Payments", "OrderDetailID", "dbo.OrderDetails");
            DropIndex("dbo.CancelOrders", new[] { "OrderDetailID" });
            DropIndex("dbo.CompletedOrders", new[] { "OrderDetailID" });
            DropIndex("dbo.Payments", new[] { "OrderDetailID" });
            AddColumn("dbo.CancelOrders", "UniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.CompletedOrders", "UniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "UniqueID", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "BillBeforeTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CancelOrders", "OrderDetailID");
            DropColumn("dbo.CompletedOrders", "OrderDetailID");
            DropColumn("dbo.Payments", "OrderDetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "OrderDetailID", c => c.Int(nullable: false));
            AddColumn("dbo.CompletedOrders", "OrderDetailID", c => c.Int(nullable: false));
            AddColumn("dbo.CancelOrders", "OrderDetailID", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "BillBeforeTax");
            DropColumn("dbo.Payments", "UniqueID");
            DropColumn("dbo.CompletedOrders", "UniqueID");
            DropColumn("dbo.CancelOrders", "UniqueID");
            CreateIndex("dbo.Payments", "OrderDetailID");
            CreateIndex("dbo.CompletedOrders", "OrderDetailID");
            CreateIndex("dbo.CancelOrders", "OrderDetailID");
            AddForeignKey("dbo.Payments", "OrderDetailID", "dbo.OrderDetails", "OrderDetailID", cascadeDelete: true);
            AddForeignKey("dbo.CompletedOrders", "OrderDetailID", "dbo.OrderDetails", "OrderDetailID", cascadeDelete: true);
            AddForeignKey("dbo.CancelOrders", "OrderDetailID", "dbo.OrderDetails", "OrderDetailID", cascadeDelete: true);
        }
    }
}
