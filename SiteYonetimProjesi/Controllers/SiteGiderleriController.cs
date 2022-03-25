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
    public class SiteGiderleriController : Controller
    {
        SiteGiderleriManager sgm = new SiteGiderleriManager(new EfSiteGiderleriDal());
        SiteGiderleriSiteManager ssm = new SiteGiderleriSiteManager(new EfSiteGiderleriSiteDal());
        SiteManager sm = new SiteManager(new EfSiteDal());

        Context c = new Context();
        // GET: SiteGiderleri
        public ActionResult Index()
        {
            var id = SiteID();       
            var siteGiderleri = sgm.GetListbySiteIDD(id);
            return View(siteGiderleri);       
        }

        [HttpGet]
        public ActionResult AddGider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGider(SiteGiderleri p)
        {
            sgm.TAdd(p);
            var siteID = SiteID();
            var siteGiderID = p.SiteGiderleriID; 
            ssm.TAdd(siteID, siteGiderID);
            return RedirectToAction("Index");
        }

        public ActionResult Filtrele(string p)
        {
            if (p == null)
            {
                var id = SiteID();
                var siteGiderleri = sgm.GetListbySiteIDD(id);
                return View(siteGiderleri);
            }
            else
            {
                var id = SiteID();
                var siteGiderleri = sgm.GetListbySiteIDD(id);
                var sitegiderlerifiltrele = sgm.GetFilterByGider(siteGiderleri, p); // ilgili site giderini dondurur
                return View(sitegiderlerifiltrele);
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
            ViewBag.SiteAd = site.SiteAd;
            return id;
        }
    }
}