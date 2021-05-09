using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using KütüphanePaneli.Models.Entity;

namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A,B")]
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            var deger2 = db.TBL_KITAP.Count();
            var deger3 = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/Resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);

            }
            return RedirectToAction("Galeri");
        }


    }
}