namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_database : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yoneticis", "SiteID", "dbo.Sites");
            DropIndex("dbo.Yoneticis", new[] { "SiteID" });
            DropColumn("dbo.Yoneticis", "SiteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Yoneticis", "SiteID", c => c.Int());
            CreateIndex("dbo.Yoneticis", "SiteID");
            AddForeignKey("dbo.Yoneticis", "SiteID", "dbo.Sites", "SiteID");
        }
    }
}
