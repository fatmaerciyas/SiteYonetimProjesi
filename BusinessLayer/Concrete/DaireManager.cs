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
    public class DaireManager : IDaireService
    {
        IDaireDal _daireDal;

        public DaireManager(IDaireDal daireDal)
        {
            _daireDal = daireDal;
        }

        public void TAdd(Daire daire)
        {
            daire.DaireStatus = true;
            _daireDal.Insert(daire);
        }

        public void TDelete(Daire daire) //projede silme islemi yapilacak yaziyordu ama siteden daire silmek sacma olacagi icin aktif-pasif yapmak istedim
        {
            _daireDal.Update(daire);
        }

        public void TUpdate(Daire daire)
        {
            _daireDal.Update(daire);
        }

        public Daire GetByID(int id)
        {
            return _daireDal.Get(x => x.DaireID == id);
        }

        public List<Daire> GetList()
        {
            return _daireDal.List(x => x.DaireStatus == true);
        }


        public List<Daire> GetListBySiteID(int id) 
        {
            return _daireDal.GetSiteByID(id);
        }

        public List<Daire> GetFilter(List<Daire> t, string p)
        {
            throw new NotImplementedException();
        }
    }
}
