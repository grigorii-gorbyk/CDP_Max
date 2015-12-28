namespace ScalabiltyHomework.Data.Migrations_Read
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChageRelationToPersonRead : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.People");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.People",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(),
            //            Picture = c.String(),
            //            Gender = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
        }
    }
}
