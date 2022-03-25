using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiteYonetimProjesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        YoneticiManager ym = new YoneticiManager(new EfYoneticiDal());
        KiraciMalSahibiLoginManager km = new KiraciMalSahibiLoginManager(new EfKiraciMalSahibiDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Yonetici p)
        {
            Context c = new Context();
            var yoneticiInfo = c.Yoneticiler.FirstOrDefault(x => x.YoneticiMail == p.YoneticiMail && x.YoneticiSifre == p.YoneticiSifre);

            if (yoneticiInfo != null)
            {
                FormsAuthentication.SetAuthCookie(yoneticiInfo.YoneticiMail, false);
                Session["YoneticiMail"] = yoneticiInfo.YoneticiMail;
                return RedirectToAction("Index", "SiteYonetim");
            }

            else
            {
                ModelState.AddModelError("", "geçersiz kullanıcı adı veya şifre");
                return View();
            }

        }
        [HttpGet]
        public ActionResult KiraciMalSahibiLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KiraciMalSahibiLogin(KiraciMalSahibi p)
        {

            var kiracimalsahibi = km.GetKiraciMalSahibi(p.Mail, p.Sifre);
            if (kiracimalsahibi != null)
            {
                FormsAuthentication.SetAuthCookie(kiracimalsahibi.Mail, false);
                Session["Mail"] = kiracimalsahibi.Mail;
                return RedirectToAction("Index", "KiraciMalSahibiPanel"); 
            }

            else
            {
                @ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre";
                return RedirectToAction("KiraciMalSahibiLogin"); 
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
