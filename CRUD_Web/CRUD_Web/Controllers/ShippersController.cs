﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Web.Models;

namespace CRUD_Web.Controllers
{
    public class ShippersController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Shippers
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetShippers()
        {//4546548965
            return Json(db.Shippers,JsonRequestBehavior.AllowGet);
        }
    }
}