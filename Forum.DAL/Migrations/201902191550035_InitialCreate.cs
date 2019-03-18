namespace Forum.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        SubjectID_ID = c.Int(),
                        UserID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID_ID)
                .ForeignKey("dbo.Users", t => t.UserID_ID)
                .Index(t => t.SubjectID_ID)
                .Index(t => t.UserID_ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        CategoryID_ID = c.Int(),
                        UserID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID_ID)
                .ForeignKey("dbo.Users", t => t.UserID_ID)
                .Index(t => t.CategoryID_ID)
                .Index(t => t.UserID_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ParentID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ParentID_ID)
                .Index(t => t.ParentID_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                        Password = c.String(),
                        Messages = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "UserID_ID", "dbo.Users");
            DropForeignKey("dbo.Messages", "SubjectID_ID", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "UserID_ID", "dbo.Users");
            DropForeignKey("dbo.Subjects", "CategoryID_ID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentID_ID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentID_ID" });
            DropIndex("dbo.Subjects", new[] { "UserID_ID" });
            DropIndex("dbo.Subjects", new[] { "CategoryID_ID" });
            DropIndex("dbo.Messages", new[] { "UserID_ID" });
            DropIndex("dbo.Messages", new[] { "SubjectID_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Subjects");
            DropTable("dbo.Messages");
        }
    }
}
