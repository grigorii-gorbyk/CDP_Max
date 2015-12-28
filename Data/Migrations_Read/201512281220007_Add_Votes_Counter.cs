namespace ScalabiltyHomework.Data.Migrations_Read
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Votes_Counter : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.PersonPromotionsCounts");
        }
    }
}
