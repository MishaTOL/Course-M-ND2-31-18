namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "StudentId" });
            AddColumn("dbo.Posts", "CommentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "StudentId");
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropIndex("dbo.Posts", new[] { "StudentId" });
            AlterColumn("dbo.Posts", "StudentId", c => c.Int());
            DropColumn("dbo.Students", "PostId");
            DropColumn("dbo.Posts", "CommentId");
            CreateIndex("dbo.Posts", "StudentId");
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "Id");
        }
    }
}
