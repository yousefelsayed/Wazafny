namespace job_offer_website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyForJobs : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ApplyForJobs", new[] { "User_Id" });
            DropColumn("dbo.ApplyForJobs", "UserId");
            RenameColumn(table: "dbo.ApplyForJobs", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ApplyForJobs", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            AlterColumn("dbo.ApplyForJobs", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ApplyForJobs", name: "UserId", newName: "User_Id");
            AddColumn("dbo.ApplyForJobs", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ApplyForJobs", "User_Id");
        }
    }
}
