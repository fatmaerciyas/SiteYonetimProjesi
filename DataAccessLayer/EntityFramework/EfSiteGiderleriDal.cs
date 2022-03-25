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
    public class EfSiteGiderleriDal : GenericRepository<SiteGiderleri>, ISiteGiderleriDal
    {
        public List<SiteGiderleri> FilterBySearch(List<SiteGiderleri> siteGiderleri ,string p)
        {
            using (var c = new Context())
            {
                List<SiteGiderleri> emptyList = new List<SiteGiderleri>();

                foreach (var item in siteGiderleri)
                {
                    if(item.Firma == null )
                    {
                        item.Firma = "NULL";
                      
                    }

                    if(item.Gider.Contains(p) || item.GiderUcreti.ToString().Contains(p) || item.Firma.Contains(p) || item.Tarih.ToString().Contains(p))
                    {
                        emptyList.Add(item);
                    }
                }
                return emptyList;
            }
        }

        public List<SiteGiderleri> GetSiteGiderleriBySiteID(int id)
        {
            using (var c = new Context())
            {
                return c.SitelerSiteGiderleri.Where(x => x.SiteID == id).Select(y => y.SiteGiderleri).ToList();
            }
        }
    }
}
