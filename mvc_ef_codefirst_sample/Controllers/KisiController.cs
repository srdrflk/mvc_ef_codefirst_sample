using mvc_ef_codefirst_sample.Models;
using mvc_ef_codefirst_sample.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ef_codefirst_sample.Controllers
{
    public class KisiController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kisiler p)
        {
            db.Kisiler.Add(p);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                ViewBag.result = "Kayıt başarili";
                ViewBag.status = "success";
            }
            else
            {
                ViewBag.result = "Kayıt gerceklesmedi!!!";
                ViewBag.status = "danger";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int? kisiid)
        {
            Kisiler kisi = null;
            if (kisiid != null)
            {
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }

            return View(kisi);
        }

        [HttpPost]
        public ActionResult Duzenle(Kisiler p, int? kisiid)
        {
            Kisiler kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();

            if (kisi != null)
            {
                kisi.Ad = p.Ad;
                kisi.Soyad = p.Soyad;
                kisi.Yas = p.Yas;
                int sonuc = db.SaveChanges();


                if (sonuc > 0)
                {
                    ViewBag.result = "Güncelleme işlemi başarili";
                    ViewBag.status = "success";
                }
                else
                {
                    ViewBag.result = "Güncelleme işlemi gerceklesmedi!!!";
                    ViewBag.status = "danger";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Sil(int? kisiid)
        {
            Kisiler kisi = null;
            if (kisiid != null)
            {
                kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
            }

            return View(kisi);
        }

        [HttpPost,ActionName("Sil")]
        public ActionResult SilOk(int? kisiid)
        {
            if (kisiid != null)
            {
               Kisiler kisi = db.Kisiler.Where(x => x.ID == kisiid).FirstOrDefault();
                db.Kisiler.Remove(kisi);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}