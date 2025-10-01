namespace atakanozbancomtr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.myprojects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        title = c.String(),
                        description = c.String(),
                        admin_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.admins", t => t.admin_id)
                .Index(t => t.admin_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.myprojects", "admin_id", "dbo.admins");
            DropIndex("dbo.myprojects", new[] { "admin_id" });
            DropTable("dbo.myprojects");
            DropTable("dbo.admins");
        }
    }
}
