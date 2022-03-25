namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_Siteler_SiteGiderleri : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SiteGiderleriSites", newName: "SiteGiderleriSite1");
            DropForeignKey("dbo.Sites", "SiteGiderleriSiteler_ID", "dbo.SiteGiderleriSitelers");
            DropForeignKey("dbo.SiteGiderleris", "SiteGiderleriSiteler_ID", "dbo.SiteGiderleriSitelers");
            DropIndex("dbo.Sites", new[] { "SiteGiderleriSiteler_ID" });
            DropIndex("dbo.SiteGiderleris", new[] { "SiteGiderleriSiteler_ID" });
            CreateTable(
                "dbo.SiteGiderleriSites",
                c => new
                    {
                        SiteGiderleriID = c.Int(nullable: false),
                        SiteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiteGiderleriID, t.SiteID })
                .ForeignKey("dbo.Sites", t => t.SiteID, cascadeDelete: true)
                .ForeignKey("dbo.SiteGiderleris", t => t.SiteGiderleriID, cascadeDelete: true)
                .Index(t => t.SiteGiderleriID)
                .Index(t => t.SiteID);
            
            DropColumn("dbo.Sites", "SiteGiderleriSiteler_ID");
            DropColumn("dbo.SiteGiderleris", "SiteGiderleriSiteler_ID");
            DropTable("dbo.SiteGiderleriSitelers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SiteGiderleriSitelers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SiteGiderleris", "SiteGiderleriSiteler_ID", c => c.Int());
            AddColumn("dbo.Sites", "SiteGiderleriSiteler_ID", c => c.Int());
            DropForeignKey("dbo.SiteGiderleriSites", "SiteGiderleriID", "dbo.SiteGiderleris");
            DropForeignKey("dbo.SiteGiderleriSites", "SiteID", "dbo.Sites");
            DropIndex("dbo.SiteGiderleriSites", new[] { "SiteID" });
            DropIndex("dbo.SiteGiderleriSites", new[] { "SiteGiderleriID" });
            DropTable("dbo.SiteGiderleriSites");
            CreateIndex("dbo.SiteGiderleris", "SiteGiderleriSiteler_ID");
            CreateIndex("dbo.Sites", "SiteGiderleriSiteler_ID");
            AddForeignKey("dbo.SiteGiderleris", "SiteGiderleriSiteler_ID", "dbo.SiteGiderleriSitelers", "ID");
            AddForeignKey("dbo.Sites", "SiteGiderleriSiteler_ID", "dbo.SiteGiderleriSitelers", "ID");
            RenameTable(name: "dbo.SiteGiderleriSite1", newName: "SiteGiderleriSites");
        }
    }
}
