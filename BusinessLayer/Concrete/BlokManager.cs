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
    public class BlokManager : IBlokService
    {
        IBlokDal blokDal;

        public BlokManager(IBlokDal blokDal)
        {
            this.blokDal = blokDal;
        }

        public Blok GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blok> GetFilter(int id, string p)
        {
            throw new NotImplementedException();
        }

        public List<Blok> GetFilter(List<Blok> t, string p)
        {
            throw new NotImplementedException();
        }

        public List<Blok> GetList()
        {
            return blokDal.List();
        }

        public List<Blok> GetListBySiteID(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Blok t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Blok t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blok t)
        {
            throw new NotImplementedException();
        }
    }
}
