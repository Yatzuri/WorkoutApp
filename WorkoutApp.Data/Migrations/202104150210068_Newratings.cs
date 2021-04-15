namespace WorkoutApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "UserId");
        }
    }
}
