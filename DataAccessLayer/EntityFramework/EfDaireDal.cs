using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDaireDal : GenericRepository<Daire>, IDaireDal
    {
        public List<Daire> GetSiteByID(int id)
        {
            List<Daire> daires = new List<Daire>(); // bos liste
            Context c = new Context();

            foreach (var item in c.Daireler)
            {
                if (item.SiteID == id && item.DaireStatus == true)
                {
                    daires.Add(item);
                }
            }

            return daires;

        }

      
    }
}
