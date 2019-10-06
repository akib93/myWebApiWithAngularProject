namespace OnlineShoppingMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shopping11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shippments", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shippments", "Status");
        }
    }
}
