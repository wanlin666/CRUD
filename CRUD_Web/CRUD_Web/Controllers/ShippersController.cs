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

        //讀取
        public JsonResult GetShippers()
        {
            return Json(db.Shippers,JsonRequestBehavior.AllowGet);
        }
        
        //新增
        [HttpPost]
        public JsonResult CreateShipper(Shippers shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            return Json(shipper,JsonRequestBehavior.AllowGet);
        }

        //修改
        [HttpPost]
        public JsonResult UpdateShipper(Shippers shipper)
        {
            var q = db.Shippers.Where(s => s.ShipperID == shipper.ShipperID).FirstOrDefault();
            try
            {
                q.CompanyName = shipper.CompanyName;
                q.Phone = shipper.Phone;
                db.SaveChanges();
                return Json("修改成功", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("修改失敗", JsonRequestBehavior.AllowGet);
            }
            
        }

        //刪除
        public JsonResult DeleteShipper(int id)
        {
            Shippers shipper = db.Shippers.Find(id);
            if(shipper == null)
            {
                return Json("NotFound",JsonRequestBehavior.AllowGet);
            }

            db.Shippers.Remove(shipper);
            db.SaveChanges();
            return Json(shipper.ShipperID, JsonRequestBehavior.AllowGet);               
        }
    }
}