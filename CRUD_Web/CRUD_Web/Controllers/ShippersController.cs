using System;
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
        {
            return Json(db.Shippers,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult CreateShipper(Shippers shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            return Json(shipper,JsonRequestBehavior.AllowGet);
        }
    }
}