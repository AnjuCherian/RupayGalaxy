﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;

namespace Banking.Controllers
{
    public class AdminController : Controller
    {
       

        public ActionResult AdminHome()
        {          
            return View();
        }
    }
}