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
    public class KiraciMalSahibiLoginManager : IKiraciMalSahibiLoginService
    {
        IKiraciMalSahibiDal kiraciMalSahibiDal;

        public KiraciMalSahibiLoginManager(IKiraciMalSahibiDal kiraciMalSahibiDal)
        {
            this.kiraciMalSahibiDal = kiraciMalSahibiDal;
        }

        public KiraciMalSahibi GetKiraciMalSahibi(string mail, string password)
        {
            return kiraciMalSahibiDal.Get(x => x.Mail == mail && x.Sifre == password);
        }
    }
}
