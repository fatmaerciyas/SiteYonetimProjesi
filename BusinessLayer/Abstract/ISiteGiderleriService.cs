using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISiteGiderleriService : IGenericService<SiteGiderleri>
    {
        List<SiteGiderleri> GetFilterByGider(List<SiteGiderleri> sitegiderleri, string p);
    }
}
