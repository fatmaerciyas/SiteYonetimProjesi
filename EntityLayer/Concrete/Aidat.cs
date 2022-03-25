using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Aidat
    {
        [Key]
        public int AidatID { get; set; }
        public DateTime AidatTarih { get; set; }
        public int? Odenecek_Tutar { get; set; }
        public int? Odenmis_Tutar { get; set; }
        public DateTime? Odeme_Tarihi { get; set; }
        
        //daire
        public int DaireID { get; set; }
        public virtual Daire Daire { get; set; }
    }
}
    

   

