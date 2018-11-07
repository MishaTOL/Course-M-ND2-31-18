namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeOnDeleteAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 200),
                        AuthorId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentEntities", t => t.AuthorId)
                .ForeignKey("dbo.PostEntities", t => t.PostId)
                .Index(t => t.AuthorId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.StudentEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 1000),
                        AuthorId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentEntities", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.TagPostMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostEntities", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.TagEntities", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.TagEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPostMaps", "TagId", "dbo.TagEntities");
            DropForeignKey("dbo.TagPostMaps", "PostId", "dbo.PostEntities");
            DropForeignKey("dbo.CommentEntities", "PostId", "dbo.PostEntities");
            DropForeignKey("dbo.PostEntities", "AuthorId", "dbo.StudentEntities");
            DropForeignKey("dbo.CommentEntities", "AuthorId", "dbo.StudentEntities");
            DropIndex("dbo.TagPostMaps", new[] { "TagId" });
            DropIndex("dbo.TagPostMaps", new[] { "PostId" });
            DropIndex("dbo.PostEntities", new[] { "AuthorId" });
            DropIndex("dbo.CommentEntities", new[] { "PostId" });
            DropIndex("dbo.CommentEntities", new[] { "AuthorId" });
            DropTable("dbo.TagEntities");
            DropTable("dbo.TagPostMaps");
            DropTable("dbo.PostEntities");
            DropTable("dbo.StudentEntities");
            DropTable("dbo.CommentEntities");
        }
    }
}
