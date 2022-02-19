namespace W2022_PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        PetBreed = c.String(),
                        PetAge = c.String(),
                        PetCharacter = c.String(),
                        ParkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pets");
        }
    }
}
