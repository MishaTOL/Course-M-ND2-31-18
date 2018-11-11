namespace Lab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.IndexViewPosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IndexViewPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author = c.String(),
                        Created = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
