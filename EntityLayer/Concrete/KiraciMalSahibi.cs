using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class KiraciMalSahibi
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string AdSoyad { get; set; }
        [StringLength(11)]
        public string Telefon { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        public string Sifre { get; set; }

        [StringLength(150)]
        public string Not { get; set; }
        [StringLength(20)]
        public string Durumu { get; set; }
        //site
        public int SiteID { get; set; }
        public virtual Site Site { get; set; }
        //Blok
        public int BlokID { get; set; }
        public virtual Blok Blok { get; set; }
        //daire
        public int? DaireID { get; set; }
        public virtual Daire Daire { get; set; }
        


    }
}
