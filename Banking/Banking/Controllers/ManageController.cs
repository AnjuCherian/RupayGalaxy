using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class ManageController : Controller
    {
        BankingEntities db = new BankingEntities();

        public ActionResult NewUser()
        {
            ViewBag.District = db.Districts.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(Registration reg)
        {
            ViewBag.District = db.Districts.ToList();
            if(ModelState.IsValid)
            {
                Login log = new Login();
                log.Username = reg.Username;
                log.Password = reg.Password;
                log.RoleID = 2;
                log.Isdeleted = false;
                log.CreatedOn = DateTime.Today.Date;

                db.Logins.Add(log);
                db.SaveChanges();
                reg.UserImg = "/Content/Photo/" + reg.Mobile + Path.GetExtension(reg.File.FileName);
                reg.LoginID = db.Logins.Max(a => a.LoginID);
                db.Registrations.Add(reg);
                db.SaveChanges();
                reg.UserImg = "~/Content/Photo/" + reg.Mobile + Path.GetExtension(reg.File.FileName);
                reg.File.SaveAs(Server.MapPath(reg.UserImg));
                return RedirectToAction("Login", "Account");
            }
            return View(reg);
        }

    }
}