using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class AnasayfaController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();
        public ActionResult Index()
        {
            ViewBag.atSayi = db.Atlar.Count();
            ViewBag.pansiyonerSayi = db.Pansiyonerler.Count();
            ViewBag.biniciSayi = db.Biniciler.Count();
            ViewBag.egitmenSayi = db.Egitmenler.Count();

            DateTime bugun = DateTime.Today;
            DateTime yarin = bugun.AddDays(1);

            ViewBag.dersSayi = db.Dersler
                .Count(x => x.DersTarihi >= bugun && x.DersTarihi < yarin);

            return View();
        }
    }
}