using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;


namespace KütüphanePaneli.Controllers
{
    [Authorize(Roles = "A,B")]
    public class IslemController : Controller
    {
        // GET: Islem
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}