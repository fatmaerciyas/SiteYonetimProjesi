namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_SiteGiderleri : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SiteGiderleris", "Site_SiteID", "dbo.Sites");
            DropIndex("dbo.SiteGiderleris", new[] { "Site_SiteID" });
            CreateTable(
                "dbo.SiteGiderleriSites",
                c => new
                    {
                        SiteGiderleri_SiteGiderleriID = c.Int(nullable: false),
                        Site_SiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteGiderleri_SiteGiderleriID, t.Site_SiteID })
                .ForeignKey("dbo.SiteGiderleris", t => t.SiteGiderleri_SiteGiderleriID, cascadeDelete: true)
                .ForeignKey("dbo.Sites", t => t.Site_SiteID, cascadeDelete: true)
                .Index(t => t.SiteGiderleri_SiteGiderleriID)
                .Index(t => t.Site_SiteID);
            
            DropColumn("dbo.SiteGiderleris", "Site_SiteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SiteGiderleris", "Site_SiteID", c => c.Int());
            DropForeignKey("dbo.SiteGiderleriSites", "Site_SiteID", "dbo.Sites");
            DropForeignKey("dbo.SiteGiderleriSites", "SiteGiderleri_SiteGiderleriID", "dbo.SiteGiderleris");
            DropIndex("dbo.SiteGiderleriSites", new[] { "Site_SiteID" });
            DropIndex("dbo.SiteGiderleriSites", new[] { "SiteGiderleri_SiteGiderleriID" });
            DropTable("dbo.SiteGiderleriSites");
            CreateIndex("dbo.SiteGiderleris", "Site_SiteID");
            AddForeignKey("dbo.SiteGiderleris", "Site_SiteID", "dbo.Sites", "SiteID");
        }
    }
}
