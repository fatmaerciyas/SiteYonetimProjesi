using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Yonetici
    {
        [Key]
        public int YoneticiID { get; set; }
        [StringLength(50)]
        public string YoneticiMail { get; set; }
        [StringLength(50)]
        public string YoneticiSifre { get; set; }
        //site 
        public ICollection<Site> Site { get; set; }

    }
}
