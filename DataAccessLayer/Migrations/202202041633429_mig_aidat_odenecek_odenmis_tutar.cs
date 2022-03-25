namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aidat_odenecek_odenmis_tutar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aidats", "Odenecek_Tutar", c => c.Int(nullable: false));
            AddColumn("dbo.Aidats", "Odenmis_Tutar", c => c.Int(nullable: false));
            DropColumn("dbo.Aidats", "Borc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aidats", "Borc", c => c.Int(nullable: false));
            DropColumn("dbo.Aidats", "Odenmis_Tutar");
            DropColumn("dbo.Aidats", "Odenecek_Tutar");
        }
    }
}
