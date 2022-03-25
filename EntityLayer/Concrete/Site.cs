using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Site
    {
        [Key]
        public int SiteID { get; set; }
        [StringLength(50)]
        public string SiteAd { get; set; }
        [StringLength(50)]
        public string SiteIl { get; set; }
        public string SiteAdres { get; set; }
        [StringLength(50)]
        public string SiteIsinmaTuru { get; set; }
        public bool SiteStatus { get; set; }

        //Daire
        public ICollection<Daire> Daire { get; set; }
        //Kiraci
        public ICollection<KiraciMalSahibi> KiraciMalSahibi { get; set; }
        //blok
        public ICollection<Blok> Blok { get; set; }
        //yonetici
        public int? YoneticiID { get; set; }
        public virtual Yonetici Yonetici { get; set; }
        //site giderleri
        public ICollection<SiteGiderleri> SiteGiderleri { get; set; }
    }
}
