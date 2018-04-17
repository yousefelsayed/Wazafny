namespace job_offer_website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGendreColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserGendre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserGendre");
        }
    }
}
