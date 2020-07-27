namespace ScheduleBotWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeZone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TimeZone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TimeZone");
        }
    }
}
