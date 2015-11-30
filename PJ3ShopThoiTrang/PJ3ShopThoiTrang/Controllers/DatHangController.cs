using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;

namespace PJ3ShopThoiTrang.Controllers
{
    public class DatHangController : Controller
    {
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Index()
        {
            return View();
        }

    }
}
