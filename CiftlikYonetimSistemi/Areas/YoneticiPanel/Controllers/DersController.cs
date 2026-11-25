using CiftlikYonetimSistemi.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class DersController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();

        public ActionResult Listele()
        {
            List<Dersler> DersListesi = db.Dersler.ToList();
            return View(DersListesi);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            ViewBag.Biniciler = new SelectList(db.Biniciler.ToList(), "ID", "Isim");
            ViewBag.Egitmenler = new SelectList(db.Egitmenler.ToList(), "ID", "Isim");
            ViewBag.Atlar = new SelectList(db.Atlar.ToList(), "ID", "AtAdi");

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Dersler gelenVeri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Dersler.Add(gelenVeri);
                    db.SaveChanges();

                    return RedirectToAction("Listele");
                }
                catch
                {
                    ViewBag.durum = false;
                }
            }

            ViewBag.Biniciler = new SelectList(db.Biniciler.ToList(), "ID", "Isim", gelenVeri.Biniciler_ID);
            ViewBag.Egitmenler = new SelectList(db.Egitmenler.ToList(), "ID", "Isim", gelenVeri.Egitmenler_ID);
            ViewBag.Atlar = new SelectList(db.Atlar.ToList(), "ID", "AtAdi", gelenVeri.Atlar_ID);

            return View(gelenVeri);
        }

        public ActionResult Sil(int id)
        {
            Dersler silinecekDers = db.Dersler.Find(id);
            db.Dersler.Remove(silinecekDers);
            db.SaveChanges();

            return RedirectToAction("Listele", "Ders");
        }

        public ActionResult Duzenle(int id)
        {
            Dersler DuzenlenecekDers = db.Dersler.Find(id);
            return View(DuzenlenecekDers);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Dersler gelenVeri)
        {
            Dersler DuzenlenecekDers = db.Dersler.Find(id);
            DuzenlenecekDers.DersTarihi = gelenVeri.DersTarihi;
            DuzenlenecekDers.Biniciler_ID = gelenVeri.Biniciler_ID;
            DuzenlenecekDers.Egitmenler_ID = gelenVeri.Egitmenler_ID;
            DuzenlenecekDers.Atlar_ID = gelenVeri.Atlar_ID;
            DuzenlenecekDers.DersDurumu = gelenVeri.DersDurumu;
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