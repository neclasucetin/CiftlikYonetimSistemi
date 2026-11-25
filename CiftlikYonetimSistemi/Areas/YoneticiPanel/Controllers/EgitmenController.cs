using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class EgitmenController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Egitmenler gelenVeri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Egitmenler.Add(gelenVeri);
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
            List<Egitmenler> EgitmenListesi = db.Egitmenler.ToList();
            return View(EgitmenListesi);

        }

        public ActionResult Sil(int id)
        {
            Egitmenler silinecekEgitmen = db.Egitmenler.Find(id);
            db.Egitmenler.Remove(silinecekEgitmen);
            db.SaveChanges();

            return RedirectToAction("Listele", "Egitmen");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Egitmenler DuzenlenecekEgitmen = db.Egitmenler.Find(id);
            return View(DuzenlenecekEgitmen);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Egitmenler gelenVeri)
        {
            Egitmenler DuzenlenecekEgitmen = db.Egitmenler.Find(id);
            DuzenlenecekEgitmen.Isim = gelenVeri.Isim;
            DuzenlenecekEgitmen.Soyisim = gelenVeri.Soyisim;
            DuzenlenecekEgitmen.Telefon = gelenVeri.Telefon;
            DuzenlenecekEgitmen.Email = gelenVeri.Email;
            DuzenlenecekEgitmen.UzmanlikAlani = gelenVeri.UzmanlikAlani;
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