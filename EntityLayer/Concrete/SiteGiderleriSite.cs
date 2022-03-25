using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SiteGiderleriSite
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("SiteGiderleri")]
        public int SiteGiderleriID { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Site")]
        public int SiteID { get; set; }

        public SiteGiderleri SiteGiderleri { get; set; }
        public Site Site { get; set; }
    }
}
