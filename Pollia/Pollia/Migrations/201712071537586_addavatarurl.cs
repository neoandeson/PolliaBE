namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addavatarurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AvatarUrl", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AvatarUrl");
        }
    }
}
