namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Students");
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            AddColumn("dbo.Comments", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Author_Id", c => c.Int());
            DropColumn("dbo.Comments", "AuthorId");
            CreateIndex("dbo.Comments", "Author_Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.Students", "Id");
        }
    }
}
