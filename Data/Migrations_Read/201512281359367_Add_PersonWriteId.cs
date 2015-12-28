namespace ScalabiltyHomework.Data.Migrations_Read
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PersonWriteId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HeroReads", "PersonWriteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HeroReads", "PersonWriteId");
        }
    }
}
