namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping4444 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Categories", "QuantityType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "QuantityType", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
    }
}
