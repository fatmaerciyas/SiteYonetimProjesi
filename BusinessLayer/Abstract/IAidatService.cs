using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAidatService : IGenericService<Aidat>
    {
       
        Aidat GetByMalSahibi(KiraciMalSahibi kiraciMalsahibi, int id);
        List<Aidat> GetListByDaireID(int id);
        void AidatsUpdate(List<Aidat> aidatlar);
    }
}
