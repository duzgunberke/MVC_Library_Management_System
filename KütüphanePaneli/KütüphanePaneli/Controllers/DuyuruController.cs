using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;
namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A,B")]
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_DUYURU.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(TBL_DUYURU t)
        {
            db.TBL_DUYURU.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBL_DUYURU.Find(id);
            db.TBL_DUYURU.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBL_DUYURU t)
        {
            var duyuru = db.TBL_DUYURU.Find(t.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBL_DUYURU t)
        {
            var duyuru = db.TBL_DUYURU.Find(t.ID);
            duyuru.KATEGORI = t.KATEGORI; 
            duyuru.ICERIK = t.ICERIK; 
            duyuru.TARIH = t.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}