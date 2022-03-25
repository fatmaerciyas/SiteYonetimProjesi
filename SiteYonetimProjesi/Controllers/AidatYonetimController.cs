using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimProjesi.Controllers
{
    public class AidatYonetimController : Controller
    {
        AidatManager adm = new AidatManager(new EfAidatDal());
        SiteManager sm = new SiteManager(new EfSiteDal());

        Context c = new Context();
        // GET: AidatYonetim
        public ActionResult Index()
        {
            int id = SiteID();  
            var aidatlar = adm.GetListBySiteID(id);
            return View(aidatlar);
        }

        public ActionResult TopluAidatEkle()
        {
            int id = SiteID();
            var aidatlar = adm.GetList();
            var tarih =  DateTime.Now;// veritabanindaki tarih de degismeli

            ViewBag.tarih = tarih;
            foreach (var item in aidatlar)
            {
                if (id == item.Daire.SiteID)
                {
                    Convert.ToInt32(item.Odenecek_Tutar);
                    item.Odenecek_Tutar += 100;
                    item.AidatTarih = tarih;
                }

            }
            adm.AidatsUpdate(aidatlar); // degisiklik yaptim AidatUpdate komutunu degistirdim
            return RedirectToAction("Index");
        }

        public ActionResult Filtrele(string p)
        {
            if (p == null)
            {
                int id = SiteID();
                var aidatlar = adm.GetListBySiteID(id);
                return View(aidatlar);
            }
            else
            {
                var id = SiteID();
                var aidatlar = adm.GetFilter(id, p);
                return View(aidatlar);
            }
        }

        public int SiteID()
        {
            var p = (String)Session["YoneticiMail"];
            var yoneticiID = c.Yoneticiler.Where(x => x.YoneticiMail == p).Select(y =>
            y.YoneticiID).FirstOrDefault(); // yonetici maili p olan yonetici id yi getirir
            var site = sm.GetSiteByYonetici(yoneticiID); // id ye gore siteyi cekeriz
            int id = site.SiteID;
            ViewBag.siteID = id;
            return id;
        }
    }
}