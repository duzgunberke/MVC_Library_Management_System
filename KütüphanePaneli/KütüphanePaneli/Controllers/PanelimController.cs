using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KütüphanePaneli.Models.Entity;


namespace KütüphanePaneli.Controllers
{

    public class PanelimController : Controller
    {
        // GET: Panelim
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        [HttpGet]

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            //var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBL_DUYURU.ToList();
            var d1 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;
            var d7 = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;
            var uyeid = db.TBL_UYELER.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.TBL_HAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d8 = d8;
            var d9 = db.TBL_MESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d9 = d9;
            var d10 = db.TBL_DUYURU.Count();
            ViewBag.d10 = d10;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER u)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = u.SIFRE;
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.FOTOGRAF = u.FOTOGRAF;
            uye.OKUL = u.OKUL;
            uye.KULLANICIADI = u.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyurulistesi = db.TBL_DUYURU.ToList();
            return View(duyurulistesi);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul=db.TBL_UYELER.Find(id);
            return PartialView("Partial2",uyebul);
        }
    }
}