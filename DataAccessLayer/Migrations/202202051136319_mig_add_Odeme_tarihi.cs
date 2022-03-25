namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_Odeme_tarihi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aidats", "Odeme_Tarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aidats", "Odeme_Tarihi", c => c.DateTime(nullable: false));
        }
    }
}
