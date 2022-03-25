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
    public class AidatManager : IAidatService
    {
        
        IAidatDal _aidatDal;

        public AidatManager(IAidatDal aidatDal)
        {
            _aidatDal = aidatDal;
        }

     

        public void AidatsUpdate(List<Aidat> aidatlar)
        {
            foreach (var item in aidatlar)
            {
                _aidatDal.Update(item);
            }
            
        }

        public Aidat GetByID(int id)
        {
            return _aidatDal.Get(x => x.AidatID == id);
        }

        public List<Aidat> GetList()
        {
            return _aidatDal.List();
        }

        
        public List<Aidat> GetListByDaireID(int id)
        {
            return _aidatDal.List(x => x.DaireID == id);
        }

        public List<Aidat> GetFilter(int id, string p)
        {
            return _aidatDal.List(x => x.Daire.SiteID == id && (x.AidatTarih.ToString()).Contains(p) || (x.Daire.DaireNo.ToString()).Contains(p) || x.Daire.Site.SiteAd.Contains(p) || x.Daire.Blok.BlokAd.Contains(p));
        }

        public List<Aidat> GetListBySiteID(int id)
        {
            return _aidatDal.List(x => x.Daire.SiteID == id);
        }

        public Aidat GetByMalSahibi(KiraciMalSahibi kiracimalsahibi, int id)
        {

            return _aidatDal.Get(x => x.DaireID == kiracimalsahibi.DaireID && kiracimalsahibi.ID == id); //kiraci ve mal sahibi icin 2 ayri sonuc verebilir
        }

       

        public void TDelete(Aidat t)
        {
            _aidatDal.Delete(t);
        }

        public void TAdd(Aidat t)
        {
            _aidatDal.Insert(t);
        }

        public void TUpdate(Aidat t)
        {
            _aidatDal.Update(t);
        }

        public List<Aidat> GetFilter(List<Aidat> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
