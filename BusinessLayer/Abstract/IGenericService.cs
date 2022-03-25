using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        List<T> GetListBySiteID(int id);
        List<T> GetFilter(List<T> t, string p); // id ve kullanicinin girdigi arama kelimesi
        T GetByID(int id);
        void TDelete(T t);
        void TAdd(T t);
        void TUpdate(T t);
    }
}
