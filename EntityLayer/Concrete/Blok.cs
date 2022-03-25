using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blok
    {
        [Key]
        public int BlokID { get; set; }
        [StringLength(1)]
        public string BlokAd { get; set; }
        //daire
        public ICollection<Daire> Daire { get; set; }
        //kiracimalsahibi
        public ICollection<KiraciMalSahibi> KiraciMalSahibi { get; set; }
    }
}
