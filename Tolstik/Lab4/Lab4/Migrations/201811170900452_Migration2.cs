namespace Lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tweets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Tweets", "ApplicationUserId");
            RenameColumn(table: "dbo.Tweets", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Tweets", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tweets", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tweets", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Tweets", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Tweets", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Tweets", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tweets", "ApplicationUser_Id");
        }
    }
}
