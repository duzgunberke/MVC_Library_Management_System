using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;

namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A")]
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();

        public ActionResult Index2()
        {
            var kullanicilar = db.TBL_ADMIN.ToList();
            return View(kullanicilar);
        }
        [HttpGet]
        public ActionResult YenıAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YenıAdmin(TBL_ADMIN t)
        {
            db.TBL_ADMIN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBL_ADMIN.Find(id);
            db.TBL_ADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");


        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBL_ADMIN.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBL_ADMIN a)
        {
            var admin = db.TBL_ADMIN.Find(a);
            admin.KULLANICI = a.KULLANICI;
            admin.SIFRE = a.SIFRE;
            admin.YETKI = a.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

    }
}