using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteYonetimProjesi.Controllers
{
    public class KiraciMalSahibiController : Controller
    {
        KiraciMalSahibiManager kmsm = new KiraciMalSahibiManager(new EfKiraciMalSahibiDal());
        BlokManager bm = new BlokManager(new EfBlokDal());
        DaireManager dm = new DaireManager(new EfDaireDal());
        SiteManager sm = new SiteManager(new EfSiteDal());

        Context c = new Context();
        // GET: KiraciMalSahibi
        public ActionResult Index()
        {
            var id = SiteID();

            var kisiler = kmsm.GetListBySiteID(id);

            return View(kisiler);

        }

        [HttpGet]
        public ActionResult AddKiraciMalSahibi()
        {
            List<SelectListItem> valueblok = (from x in bm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.BlokAd,
                                                  Value = x.BlokID.ToString()
                                              }).ToList();
            List<SelectListItem> valuedaire = (from x in dm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DaireNo.ToString(),
                                                   Value = x.DaireID.ToString()
                                               }).ToList();


            ViewBag.vld = valuedaire;
            ViewBag.vlb = valueblok;
            return View();
        }

        [HttpPost]
        public ActionResult AddKiraciMalSahibi(KiraciMalSahibi p)
        {
            var id = SiteID();
            kmsm.KiraciMalSahibiAdd(id, p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKiraciMalSahibi(int id)
        {
            var kisi = kmsm.GetByID(id);

            kmsm.TDelete(kisi);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditKiraciMalSahibi(int id)
        {

            var site = kmsm.GetByID(id);
            return View(site);
        }

        [HttpPost]
        public ActionResult EditKiraciMalSahibi(KiraciMalSahibi p)
        {
            kmsm.TUpdate(p);
            return RedirectToAction("Index");
        }

        public int SiteID() //giris yapan kullanicinin mailini alir session ile siteid'yi dondurur
        {
            var p = (String)Session["YoneticiMail"];
            var yoneticiID = c.Yoneticiler.Where(x => x.YoneticiMail == p).Select(y =>
            y.YoneticiID).FirstOrDefault(); // yonetici maili p olan yonetici id yi getirir
            var site = sm.GetSiteByYonetici(yoneticiID); // id ye gore siteyi cekeriz
            int id = site.SiteID;
            ViewBag.sitead = site.SiteAd;

            return id;
        }
    }
}
