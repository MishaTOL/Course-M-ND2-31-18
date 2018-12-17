namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB211 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "StudentId");
            AlterColumn("dbo.Posts", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "StudentId");
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "StudentId" });
            AlterColumn("dbo.Posts", "StudentId", c => c.Int());
            RenameColumn(table: "dbo.Posts", name: "StudentId", newName: "Author_Id");
            CreateIndex("dbo.Posts", "Author_Id");
            AddForeignKey("dbo.Posts", "Author_Id", "dbo.Students", "Id");
        }
    }
}
