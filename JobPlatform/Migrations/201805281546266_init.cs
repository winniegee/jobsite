namespace JobPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CareerField_Id", "dbo.Occupations");
            DropIndex("dbo.AspNetUsers", new[] { "CareerField_Id" });
            AddColumn("dbo.AspNetUsers", "CareerField", c => c.String());
            DropColumn("dbo.AspNetUsers", "CareerField_Id");
            DropTable("dbo.Occupations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "CareerField_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "CareerField");
            CreateIndex("dbo.AspNetUsers", "CareerField_Id");
            AddForeignKey("dbo.AspNetUsers", "CareerField_Id", "dbo.Occupations", "Id");
        }
    }
}
