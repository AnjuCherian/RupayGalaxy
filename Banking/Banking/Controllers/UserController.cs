using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class UserController : Controller
    {
        BankingEntities db = new BankingEntities();
        
        public ActionResult UserHome()
        {
            var LoginID = Convert.ToInt32(Session["LoginID"]);
            var userDet = db.Registrations.Where(a => a.LoginID == LoginID).SingleOrDefault();
            if (userDet!=null)
            {
              return View(userDet);
            }
            else
            {
                var userDet1 = db.Registrations.Where(a => a.LoginID == 1).SingleOrDefault();
                return View(userDet1);
            }

        }
        public ActionResult emicalc()
        {

            return View();
        }
    }
}