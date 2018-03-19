namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprovinceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProvinceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProvinceId");
        }
    }
}
