namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_yonetici_site : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sites", "YoneticiID", c => c.Int());
            CreateIndex("dbo.Sites", "YoneticiID");
            AddForeignKey("dbo.Sites", "YoneticiID", "dbo.Yoneticis", "YoneticiID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "YoneticiID", "dbo.Yoneticis");
            DropIndex("dbo.Sites", new[] { "YoneticiID" });
            DropColumn("dbo.Sites", "YoneticiID");
        }
    }
}
