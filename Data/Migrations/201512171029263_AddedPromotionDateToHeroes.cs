using System.Data.Entity.Migrations;

namespace ScalabiltyHomework.Data.Migrations
{
    public partial class AddedPromotionDateToHeroes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "PromotionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "PromotionDate");
        }
    }
}
