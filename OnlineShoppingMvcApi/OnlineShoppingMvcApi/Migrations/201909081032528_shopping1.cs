namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.CancelOrders",
                c => new
                    {
                        CancelOrderID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        DateOfCompliletion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CancelOrderID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailID, cascadeDelete: true)
                .Index(t => t.OrderDetailID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        StockID = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                        PricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UniqueID = c.Int(nullable: false),
                        Status = c.String(),
                        CustomerID = c.String(),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Stocks", t => t.StockID, cascadeDelete: true)
                .Index(t => t.StockID);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        ItemID = c.Int(),
                        BrandID = c.Int(),
                        AvailableQuantity = c.Single(nullable: false),
                        CostPricePerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellingPricePertUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID)
                .Index(t => t.ItemID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        QuantityType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(),
                        BrandID = c.Int(),
                        SupplierID = c.Int(),
                        Size = c.String(),
                        Quantity = c.Single(nullable: false),
                        Description = c.String(),
                        CostPerUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        DateOfPurchase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Brands", t => t.BrandID)
                .ForeignKey("dbo.Items", t => t.ItemID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .Index(t => t.ItemID)
                .Index(t => t.BrandID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        SupplierCellPhone = c.String(),
                        SupplierEmail = c.String(),
                        SupplierAddress = c.String(),
                        SupplierBusinessAddress = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.CompletedOrders",
                c => new
                    {
                        CompletedOrderID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        DateOfCompliletion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompletedOrderID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailID, cascadeDelete: true)
                .Index(t => t.OrderDetailID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        UniqueOrderID = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerCellPhone = c.String(),
                        CustomerEmail = c.String(),
                        CustomerAddress = c.String(),
                        DateOfRegistration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomShippingAddresses",
                c => new
                    {
                        CustomShippingAddressID = c.Int(nullable: false, identity: true),
                        UniqueOrderID = c.Int(nullable: false),
                        CellPhone = c.String(),
                        ShippingAddress = c.String(),
                    })
                .PrimaryKey(t => t.CustomShippingAddressID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalBill = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateOfPayment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailID, cascadeDelete: true)
                .Index(t => t.OrderDetailID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Shippments",
                c => new
                    {
                        ShippmentID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        DateOfCompliletion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShippmentID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Payments", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.CompletedOrders", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.CancelOrders", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "StockID", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Purchases", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Purchases", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.Stocks", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Stocks", "BrandID", "dbo.Brands");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Payments", new[] { "OrderDetailID" });
            DropIndex("dbo.CompletedOrders", new[] { "OrderDetailID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropIndex("dbo.Purchases", new[] { "BrandID" });
            DropIndex("dbo.Purchases", new[] { "ItemID" });
            DropIndex("dbo.Items", new[] { "CategoryID" });
            DropIndex("dbo.Stocks", new[] { "BrandID" });
            DropIndex("dbo.Stocks", new[] { "ItemID" });
            DropIndex("dbo.Stocks", new[] { "PurchaseID" });
            DropIndex("dbo.OrderDetails", new[] { "StockID" });
            DropIndex("dbo.CancelOrders", new[] { "OrderDetailID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Shippments");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.CustomShippingAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.CompletedOrders");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Stocks");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.CancelOrders");
            DropTable("dbo.Brands");
        }
    }
}
