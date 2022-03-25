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
    public class DaireYonetimController : Controller
    {
        DaireManager dm = new DaireManager(new EfDaireDal());
        SiteManager sm = new SiteManager(new EfSiteDal());
        Context c = new Context();
        
        // GET: SiteYonetim
        public ActionResult Index()
        {
            var id = SiteID();
            var daireler = dm.GetListBySiteID(id);
            return View(daireler);
        }

        [HttpGet]
        public ActionResult AddDaire()
        {
            List<SelectListItem> valuesite = (from x in sm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.SiteAd,
                                                  Value = x.SiteID.ToString()
                                              }).ToList();

            
            ViewBag.vls = valuesite;
            return View();

        }

        [HttpPost]
        public ActionResult AddDaire(Daire p)
        {
            dm.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDaire(int id)
        {
            var daire = dm.GetByID(id);
            if (daire.DaireStatus == true)
            {
                daire.DaireStatus = false;
            }
            dm.TUpdate(daire);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDaire(int id)
        {
            var dairevalue = dm.GetByID(id);
            return View(dairevalue);
        }

        [HttpPost]
        public ActionResult EditDaire(Daire p)
        {
            dm.TUpdate(p);
            return RedirectToAction("Index");
        }

        public int SiteID() //yonetici mailini alir session ile siteid'yi dondurur
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