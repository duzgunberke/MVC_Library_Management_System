using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A")]
    public class UyeController : Controller
    {
        // GET: Uye
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();

        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            var uye = db.TBL_UYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBL_UYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}