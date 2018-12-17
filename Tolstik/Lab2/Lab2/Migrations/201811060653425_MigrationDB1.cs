namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Author_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.Students", "Id");
            DropColumn("dbo.Comments", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Author", c => c.String());
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Students");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropColumn("dbo.Comments", "Author_Id");
        }
    }
}
