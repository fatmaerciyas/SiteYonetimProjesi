using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKiraciMalSahibiDal : IRepository<KiraciMalSahibi>
    {
        List<KiraciMalSahibi> FilterBySearch(List<KiraciMalSahibi> km, string p);
    }
}
