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
    public class SiteYonetimController : Controller
    {
        SiteManager sm = new SiteManager(new EfSiteDal());
        Context c = new Context();

        // GET: SiteYonetim
        public ActionResult Index()
        {    
            var yoneticiID = GetYonetici();
            var site = sm.GetListbyYonetici(yoneticiID); // id ye gore siteyi cekeriz
            return View(site);
        }

        [HttpGet]
        public ActionResult AddSite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSite(Site site)
        {
            var yoneticiID = GetYonetici();
            site.YoneticiID = yoneticiID;
            sm.TAdd(site);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSite(int id)
        {
            var site = sm.GetByID(id);
            if (site.SiteStatus == true)
            {
                site.SiteStatus = false;
            }
            sm.TDelete(site);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSite(int id)
        {
            var site = sm.GetByID(id);
            return View(site);
        }

        [HttpPost]
        public ActionResult EditSite(Site site)
        {
            var yoneticiID = GetYonetici();
            site.YoneticiID = yoneticiID;
            sm.TUpdate(site);
            return RedirectToAction("Index");
        }


        public ActionResult Filtrele(string p)
        {
            if (p == null)
            {
                var vls = sm.GetList().Where(x => x.SiteStatus == true);
                return View(vls.ToList());
            }
            else
            {
                var values = sm.GetList(p).Where(x => x.SiteStatus == true); ;
                return View(values.ToList());
            }
        }
        public int SiteID(String p)
        {
            var yoneticiID = GetYonetici();
            var site = sm.GetSiteByYonetici(yoneticiID); // id ye gore siteyi cekeriz
            int id = site.SiteID;
            ViewBag.siteID = id;
            return id;
        }

        public int GetYonetici()
        {
            var p = (String)Session["YoneticiMail"];
            var yoneticiID = c.Yoneticiler.Where(x => x.YoneticiMail == p).Select(y =>
            y.YoneticiID).FirstOrDefault(); // yonetici maili p olan yonetici id yi getirir
            return yoneticiID;
        }
    }
}
