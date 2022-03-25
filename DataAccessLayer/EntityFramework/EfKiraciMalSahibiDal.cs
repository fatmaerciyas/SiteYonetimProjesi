using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfKiraciMalSahibiDal : GenericRepository<KiraciMalSahibi>, IKiraciMalSahibiDal
    {
        public List<KiraciMalSahibi> FilterBySearch(List<KiraciMalSahibi> km, string p)
        {
            using (var c = new Context())
            {
                List<KiraciMalSahibi> emptyList = new List<KiraciMalSahibi>();

                foreach (var item in km)
                {
                    if (item.Not == null)
                    {
                        item.Not = "NULL";

                    }

                    if ( item.AdSoyad.Contains(p) || item.Telefon.Contains(p) || item.Mail.Contains(p) || item.Durumu.Contains(p) || item.Not.Contains(p))
                    {
                        emptyList.Add(item);
                    }
                }
                return emptyList;
            }
        }
    }
}
