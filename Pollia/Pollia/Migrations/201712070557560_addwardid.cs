namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwardid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "WardId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "WardId");
        }
    }
}
