namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DoB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DoB");
        }
    }
}
