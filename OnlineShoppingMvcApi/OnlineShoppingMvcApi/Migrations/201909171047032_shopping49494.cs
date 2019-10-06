namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping49494 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Brands", "BrandName", c => c.String(nullable: false));
        }
    }
}
