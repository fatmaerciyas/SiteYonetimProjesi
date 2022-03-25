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
    public class KiraciMalSahibiPanelController : Controller
    {
        KiraciMalSahibiManager kmm = new KiraciMalSahibiManager(new EfKiraciMalSahibiDal());
        AidatManager adm = new AidatManager(new EfAidatDal());
        Context c = new Context();

        // GET: KiraciMalSahibiPanel
        public ActionResult Index()
        {
            var p = (String)Session["Mail"];
            var kiracimalsahibiID = c.KiraciMalSahibi.Where(x => x.Mail == p).Select(y =>
            y.ID).FirstOrDefault(); //  maili p olan id yi getirir

            var kiracimalsahibi = kmm.GetByID(kiracimalsahibiID);
            return View(kiracimalsahibi);
        }
 
        public ActionResult AidatBorcuSorgula()
        {
            var p = (String)Session["Mail"];
            var kiracimalsahibiID = c.KiraciMalSahibi.Where(x => x.Mail == p).Select(y =>
            y.ID).FirstOrDefault(); //  maili p olan id yi getirir
            var kiracimalsahibi = kmm.GetByID(kiracimalsahibiID);

            var aidat = adm.GetByMalSahibi(kiracimalsahibi, kiracimalsahibiID);
            return View(aidat);
        }

        public ActionResult Ode()
        {
            var p = (String)Session["Mail"];
            var kiracimalsahibiID = c.KiraciMalSahibi.Where(x => x.Mail == p).Select(y =>
            y.ID).FirstOrDefault(); //  maili p olan id yi getirir
            var kiracimalsahibi = kmm.GetByID(kiracimalsahibiID);

            var aidat = adm.GetByMalSahibi(kiracimalsahibi, kiracimalsahibiID);

            if (aidat.Odenmis_Tutar == null)
            {
                aidat.Odenmis_Tutar = 0;
            }

            if(aidat.Odenecek_Tutar - aidat.Odenmis_Tutar <= 0)
            {
                return RedirectToAction("AidatBorcuSorgula");
            }
            else
            {
                if (aidat.Odenecek_Tutar != 0)
                {

                    aidat.Odenmis_Tutar += 100;
                    aidat.Odeme_Tarihi = DateTime.Now;
                }
                adm.TUpdate(aidat); //Burası AidatAddUpdate idi
            }

            return RedirectToAction("AidatBorcuSorgula");
        }

    }
}