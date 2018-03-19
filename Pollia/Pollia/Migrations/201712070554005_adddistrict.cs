namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddistrict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DistrictId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DistrictId");
        }
    }
}
