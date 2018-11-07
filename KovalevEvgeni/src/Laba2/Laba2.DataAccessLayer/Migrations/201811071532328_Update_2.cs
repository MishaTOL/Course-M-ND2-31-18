namespace Laba2.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comments", "StudentId");
            AddForeignKey("dbo.Comments", "StudentId", "dbo.Students", "StudentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "StudentId", "dbo.Students");
            DropIndex("dbo.Comments", new[] { "StudentId" });
        }
    }
}
