using System.Data.Entity.Migrations;

namespace ScalabiltyHomework.Data.Migrations
{
    
    public partial class AddGenderToPeople : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Gender");
        }
    }
}
