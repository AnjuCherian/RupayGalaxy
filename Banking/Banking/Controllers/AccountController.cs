using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class AccountController : Controller
    {

        BankingEntities db = new BankingEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
            dynamic logs = null;
            try
            {
                logs = db.Logins.Where(a => a.Username == log.Username && a.Password == log.Password && a.Isdeleted == false).ToList();
            }
            catch (Exception ex)
            {
            }

            if (logs != null && logs.Count > 0)
            {

                Session["LoginID"] = logs[0].LoginID;
                //if (logs[0].RoleID == 1)
                //    return RedirectToAction("AdminHome", "Admin");
                //else if (logs[0].RoleID == 2)
                    return RedirectToAction("UserHome", "User");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
            }

            return View(log);
        }
    }
}