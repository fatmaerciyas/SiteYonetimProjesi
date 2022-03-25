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
    public class KiraciMalSahibiManager : IKiraciMalSahibiService
    {
        IKiraciMalSahibiDal kiraciMalSahibiDal;

        public KiraciMalSahibiManager(IKiraciMalSahibiDal kiraciMalSahibiDal)
        {
            this.kiraciMalSahibiDal = kiraciMalSahibiDal;
        }

        public KiraciMalSahibi GetByID(int id)
        {
            return kiraciMalSahibiDal.Get(x => x.ID == id);
        }

        public List<KiraciMalSahibi> GetList()
        {
            return kiraciMalSahibiDal.List();
        }

        public void KiraciMalSahibiAdd(int siteID, KiraciMalSahibi kiracimalsahibi)
        {
            kiracimalsahibi.SiteID = siteID;
            kiraciMalSahibiDal.Insert(kiracimalsahibi);
        }

        public void TDelete(KiraciMalSahibi kiracimalsahibi)
        {
            kiraciMalSahibiDal.Delete(kiracimalsahibi);
        }

        public void TUpdate(KiraciMalSahibi kiracimalsahibi)
        {
            kiraciMalSahibiDal.Update(kiracimalsahibi);
        }
        public List<KiraciMalSahibi> GetList(string p)
        {
            return kiraciMalSahibiDal.List(x => x.AdSoyad.Contains(p) || x.Telefon.Contains(p) || x.Mail.Contains(p) || x.Durumu.Contains(p) || x.Not.Contains(p));
        }

        public List<KiraciMalSahibi> GetListBySiteID(int id)
        {
            return kiraciMalSahibiDal.List(x => x.SiteID == id);
        }

        //public List<KiraciMalSahibi> GetFilter(int id, string p)
        //{
        //    return kiraciMalSahibiDal.FilterBySearch().Select(x => x.SiteID ==id);

        //}

        public void TAdd(KiraciMalSahibi t)
        {
            throw new NotImplementedException();
        }

        public List<KiraciMalSahibi> GetFilter(List<KiraciMalSahibi> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
