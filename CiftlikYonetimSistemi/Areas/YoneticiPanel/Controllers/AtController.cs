using CiftlikYonetimSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiftlikYonetimSistemi.Areas.YoneticiPanel.Controllers
{
    public class AtController : Controller
    {
        CiftlikYonetimiDBEntities db = new CiftlikYonetimiDBEntities();

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Atlar gelenVeri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Atlar.Add(gelenVeri);
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
            List<Atlar> AtListesi = db.Atlar.ToList();
            return View(AtListesi);

        }

        public ActionResult Sil(int id)
        {
            Atlar silinecekAt = db.Atlar.Find(id);
            db.Atlar.Remove(silinecekAt);
            db.SaveChanges();
            
            return RedirectToAction("Listele", "At");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Atlar DuzenlenecekAt = db.Atlar.Find(id);
            return View(DuzenlenecekAt);
        }

        [HttpPost]
        public ActionResult Duzenle(int id, Atlar gelenVeri)
        {
            Atlar DuzenlenecekAt = db.Atlar.Find(id);
            DuzenlenecekAt.AtAdi = gelenVeri.AtAdi;
            DuzenlenecekAt.Yas = gelenVeri.Yas;
            DuzenlenecekAt.Cinsiyet = gelenVeri.Cinsiyet;
            DuzenlenecekAt.Irk = gelenVeri.Irk;
            DuzenlenecekAt.Renk = gelenVeri.Renk;
            DuzenlenecekAt.SaglikDurumu = gelenVeri.SaglikDurumu;
            DuzenlenecekAt.Pansiyonerler_ID = gelenVeri.Pansiyonerler_ID;
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