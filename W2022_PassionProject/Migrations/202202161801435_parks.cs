namespace W2022_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parks",
                c => new
                    {
                        ParkID = c.Int(nullable: false, identity: true),
                        ParkName = c.String(),
                        ParkLocation = c.String(),
                        ParkSeparation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ParkID);
            
            AddColumn("dbo.Pets", "PetWeight", c => c.Int(nullable: false));
            DropColumn("dbo.Pets", "ParkID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "ParkID", c => c.Int(nullable: false));
            DropColumn("dbo.Pets", "PetWeight");
            DropTable("dbo.Parks");
        }
    }
}
