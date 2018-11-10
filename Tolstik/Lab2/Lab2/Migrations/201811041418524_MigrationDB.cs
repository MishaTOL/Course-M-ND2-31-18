namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Student_Id", newName: "Author_Id");
            RenameIndex(table: "dbo.Posts", name: "IX_Student_Id", newName: "IX_Author_Id");
            DropColumn("dbo.Posts", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Author", c => c.String());
            RenameIndex(table: "dbo.Posts", name: "IX_Author_Id", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.Posts", name: "Author_Id", newName: "Student_Id");
        }
    }
}
