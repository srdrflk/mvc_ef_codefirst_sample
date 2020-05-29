using mvc_ef_codefirst_sample.Models;
using mvc_ef_codefirst_sample.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_ef_codefirst_sample.Controllers
{
    public class AdresController : Controller
    {
       
        // GET: Adres
        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();
            List<SelectListItem> kisilerList = (from kisi in db.Kisiler.ToList()
                                                select new SelectListItem()
                                                {
                                                    Text = kisi.Ad + " " + kisi.Soyad,
                                                    Value = kisi.ID.ToString()
                                                }).ToList();
            TempData["li"] = kisilerList;
            ViewBag.kisiler = kisilerList;

            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Adresler p)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == p.Kisi.ID).FirstOrDefault();

            if (kisi != null)
            {
                p.Kisi = kisi;
                db.Adresler.Add(p);
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
            }
            ViewBag.kisiler = TempData["li"];

            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int? adresid)
        {
            DatabaseContext db = new DatabaseContext();
            Adresler adres = null;
            if (adresid != null)
            {
                List<SelectListItem> kisilerList = (from kisi in db.Kisiler.ToList()
                                                    select new SelectListItem()
                                                    {
                                                        Text = kisi.Ad + " " + kisi.Soyad,
                                                        Value = kisi.ID.ToString()
                                                    }).ToList();

                TempData["li"] = kisilerList;
                ViewBag.kisiler = kisilerList;

                adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            }

            return View(adres);
        }

        [HttpPost]
        public ActionResult Duzenle(Adresler p, int? adresid)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.ID == p.Kisi.ID).FirstOrDefault();
            Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();

            if (kisi != null)
            {
                adres.Kisi = kisi;
                adres.AdresTanim = p.AdresTanim;
                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    ViewBag.result = "Güncelleme başarili";
                    ViewBag.status = "success";
                }
                else
                {
                    ViewBag.result = "Güncelleme gerceklesmedi!!!";
                    ViewBag.status = "danger";
                }
            }
            ViewBag.kisiler = TempData["li"];

            return View();
        }

        [HttpGet]
        public ActionResult Sil(int? adresid)
        {
            Adresler adres = null;
            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
            }

            return View(adres);
        }

        [HttpPost, ActionName("Sil")]
        public ActionResult SilOk(int? adresid)
        {
            if (adresid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Adresler adres = db.Adresler.Where(x => x.ID == adresid).FirstOrDefault();
                db.Adresler.Remove(adres);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}