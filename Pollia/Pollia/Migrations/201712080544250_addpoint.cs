namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Points");
        }
    }
}
