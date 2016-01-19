namespace ScalabiltyHomework.Data.Migrations_Read
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRead : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeroReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PersonWriteId = c.Int(nullable: false),
                        Comment = c.String(nullable: false),
                        PromotionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonReads", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WriteId = c.Int(nullable: false),
                        Name = c.String(),
                        Picture = c.String(),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LatestHeroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PersonName = c.String(),
                        PersonPicture = c.String(),
                        PersonGender = c.Int(nullable: false),
                        Comment = c.String(),
                        PromotionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonPromotionsCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        PersonName = c.String(),
                        PersonPicture = c.String(),
                        PersonGender = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeroReads", "PersonId", "dbo.PersonReads");
            DropIndex("dbo.HeroReads", new[] { "PersonId" });
            DropTable("dbo.PersonPromotionsCounts");
            DropTable("dbo.LatestHeroes");
            DropTable("dbo.PersonReads");
            DropTable("dbo.HeroReads");
        }
    }
}
