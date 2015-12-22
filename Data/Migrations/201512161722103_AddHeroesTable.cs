namespace ScalabiltyHomework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeroesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "PersonId", "dbo.People");
            DropIndex("dbo.Heroes", new[] { "PersonId" });
            DropTable("dbo.Heroes");
        }
    }
}
