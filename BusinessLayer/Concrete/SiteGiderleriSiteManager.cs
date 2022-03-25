using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SiteGiderleriSiteManager : ISiteGiderleriSiteService
    {
        ISiteGiderleriSiteDal siteGiderleriSiteDal;

        public SiteGiderleriSiteManager(ISiteGiderleriSiteDal siteGiderleriSiteDal)
        {
            this.siteGiderleriSiteDal = siteGiderleriSiteDal;
        }

        public void TDelete(SiteGiderleriSite site)
        {
            siteGiderleriSiteDal.Delete(site);
        }

        public SiteGiderleriSite GetByID(int id)
        {
            return siteGiderleriSiteDal.GetByID(id);
        }

    

        public List<SiteGiderleriSite> GetList()
        {
            return siteGiderleriSiteDal.List();
        }

        public List<SiteGiderleriSite> GetListbySiteID(int id)
        {    
            return siteGiderleriSiteDal.List(x => x.SiteID == id);
        }

        public void TUpdate(SiteGiderleriSite site)
        {
            siteGiderleriSiteDal.Update(site);
        }

        public List<SiteGiderleriSite> GetListBySiteID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SiteGiderleriSite> GetFilter(int id, string p)
        {
            throw new NotImplementedException();
        }

        SiteGiderleriSite IGenericService<SiteGiderleriSite>.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(SiteGiderleriSite t)
        {
            siteGiderleriSiteDal.Insert(t);
        }
        public void TAdd(int siteID, int siteGiderleri)
        {
            SiteGiderleriSite site = new SiteGiderleriSite();
            site.SiteGiderleriID = siteGiderleri;
            site.SiteID = siteID;
            siteGiderleriSiteDal.Insert(site);
        }

        public List<SiteGiderleriSite> GetFilter(List<SiteGiderleriSite> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
