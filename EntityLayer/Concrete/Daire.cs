using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Daire
    {
        [Key]
        public int DaireID { get; set; }
        public int DaireNo { get; set; }
        public int KatNo { get; set; }
        public int DaireAlan { get; set; }
        public bool DaireStatus { get; set; }
        [StringLength(200)]
        public string DaireAciklamasi { get; set; }
        //site
        public int SiteID { get; set; }
        public virtual Site Site { get; set; }
        
        //aidat
        public ICollection<Aidat> Aidat { get; set; }
        //blok
        public int BlokID { get; set; }
        public virtual Blok Blok { get; set; }
    }
}
