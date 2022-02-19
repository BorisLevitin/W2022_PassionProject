namespace W2022_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petsparks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "ParkID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "ParkID");
            AddForeignKey("dbo.Pets", "ParkID", "dbo.Parks", "ParkID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "ParkID", "dbo.Parks");
            DropIndex("dbo.Pets", new[] { "ParkID" });
            DropColumn("dbo.Pets", "ParkID");
        }
    }
}
