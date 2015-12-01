using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;
using WebMatrix.WebData;

namespace PJ3ShopThoiTrang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                var user = db.KhachHangs.Where(a => a.TenDangNhap.Equals(kh.TenDangNhap) && a.MatKhau.Equals(kh.MatKhau)).FirstOrDefault();
                if (user != null)
                {
                    return RedirectToAction("HomeAdmin");
                }
            }
            return View(kh);
        }
        public ActionResult HomeAdmin()
        {
            var hd = db.HoaDons.ToList();
            var sp = db.SanPhams.ToList();
            return View(Tuple.Create(hd,sp));
        }

    }
}
