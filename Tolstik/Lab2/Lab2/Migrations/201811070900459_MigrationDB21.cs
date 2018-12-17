namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "CurrentStudent_Id", c => c.Int());
            CreateIndex("dbo.Posts", "CurrentStudent_Id");
            AddForeignKey("dbo.Posts", "CurrentStudent_Id", "dbo.CurrentStudents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CurrentStudent_Id", "dbo.CurrentStudents");
            DropIndex("dbo.Posts", new[] { "CurrentStudent_Id" });
            DropColumn("dbo.Posts", "CurrentStudent_Id");
            DropTable("dbo.CurrentStudents");
        }
    }
}
