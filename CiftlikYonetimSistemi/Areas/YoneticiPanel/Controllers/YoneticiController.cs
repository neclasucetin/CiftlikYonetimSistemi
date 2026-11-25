using CiftlikYonetimSistemi.Areas.YoneticiPanel.Data;
using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class YoneticiController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(YoneticiGirisVeriTasiyicisi girisBilgileri)
        {
            if (ModelState.IsValid)
            {
                Yoneticiler yonetici = db.Yoneticiler.FirstOrDefault(x => x.Email == girisBilgileri.
                Mail && x.Sifre == girisBilgileri.Sifre);
                if (yonetici != null)
                {
                    Session["yonetici"] = yonetici;
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    ViewBag.mesaj = "Yönetici bilgileri hatalı";
                }

            }
            return View();
        }

        public ActionResult CikisYap()
        {
            Session["yonetici"] = null;
            return RedirectToAction("GirisYap", "Yonetici");
        }
    }
}
