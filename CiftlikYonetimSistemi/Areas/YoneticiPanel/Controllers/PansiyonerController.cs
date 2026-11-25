using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class PansiyonerController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Pansiyonerler gelenVeri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Pansiyonerler.Add(gelenVeri);
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
            List<Pansiyonerler> PansiyonerListesi = db.Pansiyonerler.ToList();
            return View(PansiyonerListesi);

        }

        public ActionResult Sil(int id)
        {
            Pansiyonerler silinecekPansiyoner = db.Pansiyonerler.Find(id);
            db.Pansiyonerler.Remove(silinecekPansiyoner);
            db.SaveChanges();

            return RedirectToAction("Listele", "Pansiyoner");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Pansiyonerler DuzenlenecekPansiyoner = db.Pansiyonerler.Find(id);
            return View(DuzenlenecekPansiyoner);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Pansiyonerler gelenVeri)
        {
            Pansiyonerler DuzenlenecekPansiyoner = db.Pansiyonerler.Find(id);
            DuzenlenecekPansiyoner.Isim = gelenVeri.Isim;
            DuzenlenecekPansiyoner.Soyisim = gelenVeri.Soyisim;
            DuzenlenecekPansiyoner.Telefon = gelenVeri.Telefon;
            DuzenlenecekPansiyoner.Email = gelenVeri.Email;
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