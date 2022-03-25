using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKiraciMalSahibiService : IGenericService<KiraciMalSahibi>
    {
        void KiraciMalSahibiAdd(int siteID, KiraciMalSahibi kiracimalsahibi);
    }
}
