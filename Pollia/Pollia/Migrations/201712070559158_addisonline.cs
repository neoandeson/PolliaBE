namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addisonline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsOnline", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsOnline");
        }
    }
}
