using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SiteGiderleri
    {
        [Key]
        public int SiteGiderleriID { get; set; }
        [StringLength(50)]
        public string  Gider { get; set; }
        public double  GiderUcreti { get; set; }
        [StringLength(100)]
        public string  Firma { get; set; }
        public DateTime?  Tarih { get; set; }
        public bool Status { get; set; }
        //site
        public ICollection<Site> Site { get; set; }
    }
}
