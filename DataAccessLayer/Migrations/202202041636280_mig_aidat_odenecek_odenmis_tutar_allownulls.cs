namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aidat_odenecek_odenmis_tutar_allownulls : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aidats", "Odenecek_Tutar", c => c.Int());
            AlterColumn("dbo.Aidats", "Odenmis_Tutar", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aidats", "Odenmis_Tutar", c => c.Int(nullable: false));
            AlterColumn("dbo.Aidats", "Odenecek_Tutar", c => c.Int(nullable: false));
        }
    }
}
