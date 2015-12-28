namespace ScalabiltyHomework.Data.Migrations_Read
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_WriteID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonReads", "WriteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonReads", "WriteId");
        }
    }
}
