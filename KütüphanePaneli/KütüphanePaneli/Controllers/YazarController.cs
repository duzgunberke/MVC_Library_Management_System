using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;
namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A,B")]
    public class YazarController : Controller
    {
        // GET: Yazar
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_YAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
            public ActionResult YazarSil(int id)
        {
            var yazar = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBL_YAZAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBL_YAZAR p)
        {
            var yzr = db.TBL_YAZAR.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBL_KITAP.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.TBL_YAZAR.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(yazar);
        }

    }
}