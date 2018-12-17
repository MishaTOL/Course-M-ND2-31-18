namespace Laba2.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TagPosts", name: "Tag_TagId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.TagPosts", name: "Post_PostId", newName: "Tag_TagId");
            RenameColumn(table: "dbo.TagPosts", name: "__mig_tmp__0", newName: "Post_PostId");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Post_PostId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Tag_TagId", newName: "IX_Post_PostId");
            RenameIndex(table: "dbo.TagPosts", name: "__mig_tmp__0", newName: "IX_Tag_TagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TagPosts", name: "IX_Tag_TagId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.TagPosts", name: "IX_Post_PostId", newName: "IX_Tag_TagId");
            RenameIndex(table: "dbo.TagPosts", name: "__mig_tmp__0", newName: "IX_Post_PostId");
            RenameColumn(table: "dbo.TagPosts", name: "Post_PostId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.TagPosts", name: "Tag_TagId", newName: "Post_PostId");
            RenameColumn(table: "dbo.TagPosts", name: "__mig_tmp__0", newName: "Tag_TagId");
        }
    }
}
