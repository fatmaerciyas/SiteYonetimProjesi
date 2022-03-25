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
    public class YoneticiManager : IYoneticiService
    {
        IYoneticiDal _yoneticiDal;

        public YoneticiManager(IYoneticiDal yoneticiDal)
        {
            _yoneticiDal = yoneticiDal;
        }

        public Yonetici GetByID(int id)
        {
            return _yoneticiDal.Get(x => x.YoneticiID == id);
        }

        public List<Yonetici> GetFilter(int id, string p)
        {
            throw new NotImplementedException();
        }

        public List<Yonetici> GetFilter(List<Yonetici> t, string p)
        {
            throw new NotImplementedException();
        }

        public List<Yonetici> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Yonetici> GetListBySiteID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Yonetici t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Yonetici t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Yonetici t)
        {
            throw new NotImplementedException();
        }

        public void YoneticiUpdate(Yonetici yonetici)
        {
            _yoneticiDal.Update(yonetici);
        }
    }
}
