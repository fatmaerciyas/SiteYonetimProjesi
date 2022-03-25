using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Aidat> Aidatlar { get; set; }
        public DbSet<Blok> Bloklar { get; set; }
        public DbSet<Daire> Daireler { get; set; }
        public DbSet<KiraciMalSahibi> KiraciMalSahibi { get; set; }
        public DbSet<Site> Siteler { get; set; }
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<SiteGiderleri> SiteGiderleri { get; set; }
        public DbSet<SiteGiderleriSite> SitelerSiteGiderleri { get; set; }
    }

}
