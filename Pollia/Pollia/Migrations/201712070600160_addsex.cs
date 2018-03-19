namespace Pollia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Sex");
        }
    }
}
