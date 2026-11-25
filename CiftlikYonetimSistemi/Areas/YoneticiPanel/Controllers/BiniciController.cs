using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class BiniciController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Biniciler gelenVeri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Biniciler.Add(gelenVeri);
                    db.SaveChanges();
                    ViewBag.durum = true;
                }
                catch
                {
                    ViewBag.durum = false;
                }
            }
            return View();
        }

        public ActionResult Listele()
        {
            List<Biniciler> BiniciListesi = db.Biniciler.ToList();
            return View(BiniciListesi);

        }

        public ActionResult Sil(int id)
        {
            Biniciler silinecekBinici = db.Biniciler.Find(id);
            db.Biniciler.Remove(silinecekBinici);
            db.SaveChanges();

            return RedirectToAction("Listele", "Binici");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Biniciler DuzenlenecekBinici = db.Biniciler.Find(id);
            return View(DuzenlenecekBinici);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Biniciler gelenVeri)
        {
            Biniciler DuzenlenecekBinici = db.Biniciler.Find(id);
            DuzenlenecekBinici.Isim = gelenVeri.Isim;
            DuzenlenecekBinici.Soyisim = gelenVeri.Soyisim;
            DuzenlenecekBinici.Telefon = gelenVeri.Telefon;
            DuzenlenecekBinici.Email = gelenVeri.Email;
            DuzenlenecekBinici.DeneyimSeviyesi = gelenVeri.DeneyimSeviyesi;
            try
            {
                db.SaveChanges();
                ViewBag.durum = true;
            }
            catch
            {
                ViewBag.durum = false;
            }
            return View(gelenVeri);
        }
    }
}