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
    public class SiteManager : ISiteService
    {
        ISiteDal _siteDal;

        public SiteManager(ISiteDal siteDal)
        {
            _siteDal = siteDal;
        }

        public Site GetByID(int id)
        {
            return _siteDal.Get(x => x.SiteID == id);
        }

        public List<Site> GetList()
        {
            return _siteDal.List();
        }

        public void TDelete(Site site)
        {
            _siteDal.Update(site); // buraya bak
        }

        public List<Site> GetList(string p)
        {
            return _siteDal.List(x => x.SiteAd.Contains(p) || x.SiteAdres.Contains(p) || x.SiteIsinmaTuru.Contains(p) || x.SiteIl.Contains(p));
        }

        public Site GetSiteByYonetici(int id)
        {
            return _siteDal.Get(x => x.YoneticiID == id && x.SiteStatus == true);   
        }


        public List<Site> GetListbyYonetici(int id)
        {
            return _siteDal.List(x => x.YoneticiID == id && x.SiteStatus == true);
        }

        public List<Site> GetListBySiteID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Site> GetFilter(int id, string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Site t)
        {
            t.SiteStatus = true;
            _siteDal.Insert(t);
        }

        public void TUpdate(Site t)
        {
            t.SiteStatus = true;
            _siteDal.Update(t);
        }

        public List<Site> GetFilter(List<Site> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
