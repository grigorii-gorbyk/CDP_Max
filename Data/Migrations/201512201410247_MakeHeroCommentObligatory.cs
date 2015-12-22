namespace ScalabiltyHomework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeHeroCommentObligatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Heroes", "Comment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Heroes", "Comment", c => c.String());
        }
    }
}
