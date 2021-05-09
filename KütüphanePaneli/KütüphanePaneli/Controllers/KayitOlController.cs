using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;

namespace KütüphanePaneli.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl

        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}