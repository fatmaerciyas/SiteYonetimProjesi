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
    public class SiteGiderleriManager : ISiteGiderleriService
    {
        ISiteGiderleriDal siteGiderleriDal;

        public SiteGiderleriManager(ISiteGiderleriDal siteGiderleriDal)
        {
            this.siteGiderleriDal = siteGiderleriDal;
        }

        public Site GetByID(int id)
        {
            throw new NotImplementedException(); // getbyid komutu lazim
        }

        public List<SiteGiderleri> GetFilterByGider(List<SiteGiderleri> sitegiderleri, string p)
        {
           return siteGiderleriDal.FilterBySearch(sitegiderleri,p);
         
        }

        public List<SiteGiderleri> GetList()
        {
            return siteGiderleriDal.List();
        }

        public List<SiteGiderleri> GetListbySiteIDD(int id)
        {
            return siteGiderleriDal.GetSiteGiderleriBySiteID(id);
        }

        public List<SiteGiderleri> GetListBySiteID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(SiteGiderleri sitegider)
        {
            sitegider.Status = true;
            sitegider.Tarih = DateTime.Now;
            siteGiderleriDal.Insert(sitegider);      
        }

        public void TDelete(SiteGiderleri sitegider)
        {
            siteGiderleriDal.Delete(sitegider);
        }

        public void TUpdate(SiteGiderleri sitegider)
        {
            siteGiderleriDal.Update(sitegider);
        }

        SiteGiderleri IGenericService<SiteGiderleri>.GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<SiteGiderleri> GetFilter(int id, string p)
        {
            throw new NotImplementedException();
        }

        public List<SiteGiderleri> GetFilter(List<SiteGiderleri> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
