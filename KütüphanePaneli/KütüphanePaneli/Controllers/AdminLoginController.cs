using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KütüphanePaneli.Models.Entity;

namespace KütüphanePaneli.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DboKütüphaneYönetimEntities db = new DboKütüphaneYönetimEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBL_ADMIN t)
        {
            var bilgiler = db.TBL_ADMIN.FirstOrDefault(x => x.KULLANICI == t.KULLANICI && x.SIFRE == t.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["Kullanici"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}