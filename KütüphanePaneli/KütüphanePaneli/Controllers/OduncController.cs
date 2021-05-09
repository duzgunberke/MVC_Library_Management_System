using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;

namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A,B")]
 
    public class OduncController : Controller
    {
        // GET: Odunc
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBL_UYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from y in db.TBL_KITAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.AD,
                                               Value = y.ID.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from z in db.TBL_PERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = z.PERSONEL,
                                               Value = z.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            var d1 = db.TBL_UYELER.Where(x => x.ID == p.TBL_UYELER.ID).FirstOrDefault();
            var d2 = db.TBL_KITAP.Where(y => y.ID == p.TBL_KITAP.ID).FirstOrDefault();
            var d3 = db.TBL_PERSONEL.Where(z => z.ID == p.TBL_PERSONEL.ID).FirstOrDefault();
            p.TBL_UYELER = d1;
            p.TBL_KITAP = d2;
            p.TBL_PERSONEL = d3;
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult OduncIade(TBL_HAREKET p)
        {
            var odn = db.TBL_HAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays; ;
            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBL_HAREKET p)
        {
            var hrk = db.TBL_HAREKET.Find(p.ID);
            hrk.UYEGETIRMETARIH = p.UYEGETIRMETARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}