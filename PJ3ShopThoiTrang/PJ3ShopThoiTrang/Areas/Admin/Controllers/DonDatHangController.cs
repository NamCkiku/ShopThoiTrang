using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;
namespace PJ3ShopThoiTrang.Areas.Admin.Controllers
{
    public class DonDatHangController : Controller
    {
        public ActionResult Hien()
        {
            using(ShopThoiTrangEntities db=new ShopThoiTrangEntities())
            {
                var hd=db.HoaDons.ToList();
                return View(hd);
            }
        }

    }
}
