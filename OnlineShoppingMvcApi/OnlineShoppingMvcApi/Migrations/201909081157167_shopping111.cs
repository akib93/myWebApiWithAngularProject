namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippments", "UniqueID", c => c.Int(nullable: false));
            DropColumn("dbo.Shippments", "OrderDetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shippments", "OrderDetailID", c => c.Int(nullable: false));
            DropColumn("dbo.Shippments", "UniqueID");
        }
    }
}
