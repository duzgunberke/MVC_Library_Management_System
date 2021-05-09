using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KütüphanePaneli.Models.Entity;
using System.Web.Security;

namespace KütüphanePaneli.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }

        }
    }
}