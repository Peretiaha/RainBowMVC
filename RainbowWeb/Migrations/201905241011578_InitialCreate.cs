namespace RainbowWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Img = c.Binary(),
                    })
                .PrimaryKey(t => t.CommandId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.LoginUsers",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        LoginDate = c.DateTime(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        Status = c.Boolean(nullable: false),
                        PromoCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoginUsers", "User_UserId", "dbo.Users");
            DropIndex("dbo.LoginUsers", new[] { "User_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.LoginUsers");
            DropTable("dbo.Contacts");
            DropTable("dbo.Commands");
        }
    }
}
