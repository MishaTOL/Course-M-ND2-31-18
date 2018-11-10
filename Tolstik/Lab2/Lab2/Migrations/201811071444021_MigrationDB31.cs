namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB31 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagPosts", newName: "PostTag");
            RenameColumn(table: "dbo.PostTag", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.PostTag", name: "Post_Id", newName: "PostId");
            RenameIndex(table: "dbo.PostTag", name: "IX_Post_Id", newName: "IX_PostId");
            RenameIndex(table: "dbo.PostTag", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.PostTag");
            AddPrimaryKey("dbo.PostTag", new[] { "PostId", "TagId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PostTag");
            AddPrimaryKey("dbo.PostTag", new[] { "Tag_Id", "Post_Id" });
            RenameIndex(table: "dbo.PostTag", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.PostTag", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.PostTag", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.PostTag", name: "TagId", newName: "Tag_Id");
            RenameTable(name: "dbo.PostTag", newName: "TagPosts");
        }
    }
}
