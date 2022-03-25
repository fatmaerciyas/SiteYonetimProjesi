using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ISiteGiderleriDal : IRepository<SiteGiderleri>
    {
        List<SiteGiderleri> GetSiteGiderleriBySiteID(int id);
        List<SiteGiderleri> FilterBySearch(List<SiteGiderleri> sitegiGiderleri ,string p);
    }
}
